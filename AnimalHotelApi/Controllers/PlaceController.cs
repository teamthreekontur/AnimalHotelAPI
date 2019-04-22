namespace Notes.API.Controllers
{
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
        public IActionResult GetPlace([FromRoute]string placeId)
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
                var error = ServiceErrorResponses.NoteNotFound(placeId);
                return this.NotFound(error);
            }

            var clientNote = NoteConverter.Convert(modelNote);

            return this.Ok(clientNote);
        }

        [HttpPatch]
        [Route("{placeId}")]
        public IActionResult PatchPlace([FromRoute]string placeId, [FromBody]Client.Place.PlacePatchInfo patchInfo)
        {
            if (patchInfo == null)
            {
                var error = ServiceErrorResponses.BodyIsMissing("PlacePatchInfo");
                return this.BadRequest(error);
            }

            if (!Guid.TryParse(placeId, out var placeIdGuid))
            {
                var error = ServiceErrorResponses.PlaceNotFound(placeId);
                return this.NotFound(error);
            }

            var modelPathInfo = PlacePathcInfoConverter.Convert(placeIdGuid, patchInfo);

            Model.Place.Place modelPlace = null;

            try
            {
                modelPlace = this.repository.Patch(modelPathInfo);
            }
            catch (Model.Place.PlaceNotFoundExcepction)
            {
                var error = ServiceErrorResponses.PlaceNotFound(placeId);
                return this.NotFound(error);
            }

            var clientPlace = PlaceConverter.Convert(modelPlace);
            return this.Ok(clientPlace);
        }

        [HttpDelete]
        [Route("{placeId}")]
        public async Task<IActionResult> DeletePlaceAsync([FromRoute]string placeId)
        {
            if (!Guid.TryParse(placeId, out var placeIdGuid))
            {
                var error = ServiceErrorResponses.NoteNotFound(placeId);
                return this.NotFound(error);
            }

            try
            {
                this.repository.Remove(placeIdGuid);
            }
            catch (Model.Place.PlaceNotFoundExcepction)
            {
                var error = ServiceErrorResponses.PlaceNotFound(placeId);
                return this.NotFound(error);
            }

            return this.NoContent();
        }
    }
}
