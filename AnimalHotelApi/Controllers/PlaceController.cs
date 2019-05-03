using AnimalHotelApi.Controllers;
using System.Web.Http;
using Models.Place.Repository;
using System;
using Client.Models.Place;
using System.Collections.Generic;
using AnimalHotelApi.Errors;

namespace Place.API.Controllers
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
        public IHttpActionResult CreatePlace([FromBody]PlaceBuildInfo buildInfo)
        {
            if (buildInfo == null)
            {
                var error = ServiceErrorResponses.BodyIsMissing("PlaceBuildInfo");
                return this.BadRequest(error);
            }

            //var session = this.authenticator.GetSession(this.HttpContext.Request.Headers["session-id"]);
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
        public IHttpActionResult GetPlace([FromUri]string placeId)
        {
            if (!Guid.TryParse(placeId, out var modelPlaceId))
            {
                if (placeId == null)
                {
                    throw new ArgumentNullException(nameof(placeId));
                    return this.NotFound();
                }
            }

            Models.Place.Place modelPlace = null;

            try
            {
                modelPlace = this.repository.Get(modelPlaceId);
            }
            catch (Models.Place.PlaceNotFoundException)
            {
                if (placeId == null)
                {
                    throw new ArgumentNullException(nameof(placeId));
                    return this.NotFound();
                }
            }

            var clientPlace = PlaceConverter.Convert(modelPlace);

            return this.Ok(clientPlace);
        }

        [HttpPatch]
        [Route("{placeId}")]
        public IHttpActionResult PatchPlace([FromUri]string placeId, [FromBody]Client.Models.Place.PlacePatchInfo patchInfo)
        {
            if (patchInfo == null)
            {
                var error = ServiceErrorResponses.BodyIsMissing("PlacePatchInfo");
                return this.BadRequest(error);
            }

            if (!Guid.TryParse(placeId, out var placeIdGuid))
            {
                if (placeId == null)
                {
                    throw new ArgumentNullException(nameof(placeId));
                    return this.NotFound();
                }
            }

            var placePathInfo = PlacePathcInfoConverter.Convert(placeIdGuid, patchInfo);

            Models.Place.Place modelPlace = null;

            try
            {
                modelPlace = this.repository.Patch(placePathInfo);
            }
            catch (Models.Place.PlaceNotFoundException)
            {
                if (placeId == null)
                {
                    throw new ArgumentNullException(nameof(placeId));
                    return this.NotFound();
                }
            }

            var clientPlace = PlaceConverter.Convert(modelPlace);
            return this.Ok(clientPlace);
        }

        [HttpDelete]
        [Route("{placeId}")]
        public IHttpActionResult DeletePlace([FromUri]string placeId)
        {
            if (!Guid.TryParse(placeId, out var placeIdGuid))
            {
                if (placeId == null)
                {
                    throw new ArgumentNullException(nameof(placeId));
                    return this.NotFound();
                }
            }

            try
            {
                this.repository.Remove(placeIdGuid);
            }
            catch (Models.Place.PlaceNotFoundException)
            {
                if (placeId == null)
                {
                    throw new ArgumentNullException(nameof(placeId));
                    return this.NotFound();
                }
            }

            return this.NotFound();
        }
    }
}
