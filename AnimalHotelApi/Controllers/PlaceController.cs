namespace Notes.API.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Notes.API.Auth;
    using Notes.API.Errors;
    using Notes.Models.Converters.Notes;
    using Notes.Models.Notes.Repositories;
    using Model = global::Notes.Models;

    [Route("v1/places")]
    public sealed class PlaceController : ApiController
    {
        private readonly IPlaceRepository repository;
        private readonly IAuthenticator authenticator;

        public PlaceController(IPlaceRepository repository, IAuthenticator authenticator)
        {
            if (repository == null)
            {
                throw new ArgumentNullException(nameof(repository));
            }

            this.repository = repository;
            this.authenticator = authenticator;
        }

        [HttpPost]
        [Route("")]
        public IActionResult CreatePlace([FromBody]Client.Place.PlaceBuildInfo buildInfo)
        {
            if (buildInfo == null)
            {
                var error = ServiceErrorResponses.BodyIsMissing("PlaceBuildInfo");
                return this.BadRequest(error);
            }

            var session = this.authenticator.GetSession(this.HttpContext.Request.Headers["session-id"]);
            //this.HttpContext.User

            var userId = Guid.Empty.ToString();

            var creationInfo = PlaceBuildInfoConverter.Convert(userId, buildInfo);
            var modelPlaceInfo = this.repository.Create(creationInfo);

            var clientPlaceInfo = PlaceInfoConverter.Convert(modelPlaceInfo);

            var routeParams = new Dictionary<string, object>
            {
                { "placeId", clientPlaceInfo.Id }
            };

            return this.CreatedAtRoute("GetPlaceRoute", routeParams, clientPlaceInfo);
        }

        [HttpGet]
        [Route("{placeId}", Name = "GetPlaceRoute")]
        public IActionResult GetPlaceAsync([FromRoute]string noteId)
        {
            if (!Guid.TryParse(placeId, out var modelPlaceId))
            {
                var error = ServiceErrorResponses.NoteNotFound(placeId);
                return this.NotFound(error);
            }

            Model.Place.Place modelPlace = null;

            try
            {
                modelPlace = this.repository.Get(modelPlaceId);
            }
            catch (Model.Place.PlaceNotFoundException)
            {
                var error = ServiceErrorResponses.NoteNotFound(noteId);
                return this.NotFound(error);
            }

            var clientNote = NoteConverter.Convert(modelNote);

            return this.Ok(clientNote);
        }

        [HttpPatch]
        [Route("{noteId}")]
        public async Task<IActionResult> PatchNoteAsync([FromRoute]string noteId, [FromBody]Client.Notes.NotePatchInfo patchInfo, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (patchInfo == null)
            {
                var error = ServiceErrorResponses.BodyIsMissing("NotePatchInfo");
                return this.BadRequest(error);
            }

            if (!Guid.TryParse(noteId, out var noteIdGuid))
            {
                var error = ServiceErrorResponses.NoteNotFound(noteId);
                return this.NotFound(error);
            }

            var modelPathInfo = NotePathcInfoConverter.Convert(noteIdGuid, patchInfo);

            Model.Notes.Note modelNote = null;

            try
            {
                modelNote = await this.repository.PatchAsync(modelPathInfo, cancellationToken).ConfigureAwait(false);
            }
            catch (Model.Notes.NoteNotFoundExcepction)
            {
                var error = ServiceErrorResponses.NoteNotFound(noteId);
                return this.NotFound(error);
            }

            var clientNote = NoteConverter.Convert(modelNote);
            return this.Ok(clientNote);
        }

        [HttpDelete]
        [Route("{noteId}")]
        public async Task<IActionResult> DeleteNoteAsync([FromRoute]string noteId, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (!Guid.TryParse(noteId, out var noteIdGuid))
            {
                var error = ServiceErrorResponses.NoteNotFound(noteId);
                return this.NotFound(error);
            }

            try
            {
                await this.repository.RemoveAsync(noteIdGuid, cancellationToken).ConfigureAwait(false);
            }
            catch (Model.Notes.NoteNotFoundExcepction)
            {
                var error = ServiceErrorResponses.NoteNotFound(noteId);
                return this.NotFound(error);
            }

            return this.NoContent();
        }
    }
}
