using AnimalHotelApi.Controllers;
using System.Web.Http;
using Models.Place.Repository;
using System;
using Client.Models.Place;
using System.Collections.Generic;
using AnimalHotelApi.Errors;
using Models.Converters.Places;

namespace Place.API.Controllers
{
    [Route("v1/places")]
    public sealed class PlaceController : ApiController
    {
        private readonly IPlaceRepository repository;
        private readonly IAuthenticator authenticator;

        public PlaceController(IPlaceRepository repository, IAuthenticator authenticator)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
            this.authenticator = authenticator ?? throw new ArgumentNullException(nameof(authenticator));
        }

        [HttpPost]
        [Route("")]
        public IHttpActionResult CreatePlace([FromBody]PlaceBuildInfo buildInfo)
        {
            if (buildInfo == null)
            {
                //var error = ServiceErrorResponses.BodyIsMissing("PlaceBuildInfo");
                return BadRequest();
            }

            //var session = this.authenticator.GetSession(this.HttpContext.Request.Headers["session-id"]);
            //this.HttpContext.User

            var userId = Guid.Empty.ToString();

            var creationInfo = PlaceBuildInfoConverter.Convert(userId, buildInfo);
            var modelPlaceInfo = repository.Create(creationInfo);
            var clientPlaceInfo = PlaceInfoConverter.Convert(modelPlaceInfo);

            var routeParams = new Dictionary<string, object>
            {
                { "placeId", clientPlaceInfo.Id }
            };

            return CreatedAtRoute("GetPlaceRoute", routeParams, clientPlaceInfo);
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
                }
            }

            Models.Place.Place modelPlace = null;

            try
            {
                modelPlace = repository.Get(modelPlaceId);
            }
            catch (Models.Place.PlaceNotFoundException)
            {
                if (placeId == null)
                {
                    throw new ArgumentNullException(nameof(placeId));
                }
            }

            var clientPlace = Models.Converters.Places.PlaceConverter.Convert(modelPlace);

            return Ok(clientPlace);
        }

        [HttpPatch]
        [Route("{placeId}")]
        public IHttpActionResult PatchPlace([FromUri]string placeId, [FromBody]Client.Models.Place.PlacePatchInfo patchInfo)
        {
            if (patchInfo == null)
            {
                //var error = ServiceErrorResponses.BodyIsMissing("PlacePatchInfo");
                return BadRequest();
            }

            if (!Guid.TryParse(placeId, out var placeIdGuid))
            {
                if (placeId == null)
                {
                    throw new ArgumentNullException(nameof(placeId));
                }
            }

            var placePathInfo = PlacePatchInfoConverter.Convert(placeIdGuid, patchInfo);

            Models.Place.Place modelPlace = null;

            try
            {
                modelPlace = repository.Patch(placePathInfo);
            }
            catch (Models.Place.PlaceNotFoundException)
            {
                if (placeId == null)
                {
                    throw new ArgumentNullException(nameof(placeId));
                }
            }

            var clientPlace = PlaceConverter.Convert(modelPlace);
            return Ok(clientPlace);
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
                }
            }

            try
            {
                repository.Remove(placeIdGuid);
            }
            catch (Models.Place.PlaceNotFoundException)
            {
                if (placeId == null)
                {
                    throw new ArgumentNullException(nameof(placeId));
                }
            }

            return NotFound();
        }
    }
}
