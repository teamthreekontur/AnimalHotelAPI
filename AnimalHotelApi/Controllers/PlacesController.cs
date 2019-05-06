using AnimalHotelApi.Controllers;
using System.Web.Http;
using Models.Place.Repository;
using System;
using Client.Models.Place;
using System.Collections.Generic;
using AnimalHotelApi.Models;
using Models.Converters.Places;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Linq;

namespace Place.API.Controllers
{
    [RoutePrefix("api/places")]
    public sealed class PlacesController : ApiController
    {
        private readonly IPlaceRepository repository;
        private readonly IAuthentificator authenticator;

        public PlacesController(IPlaceRepository repository, IAuthentificator authenticator)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
            this.authenticator = authenticator;
        }

        [HttpPost]
        public IHttpActionResult CreatePlace([FromBody]PlaceBuildInfo buildInfo)
        {
            if (buildInfo == null)
            {
                return this.BadRequest();
            }

            string sessionId = "";
            CookieHeaderValue cookie = Request.Headers.GetCookies("SessionId").FirstOrDefault();
            if (cookie != null)
            {
                sessionId = cookie["SessionId"].Value;
            }

            if (!authenticator.TryGetSession(sessionId, out var sessionState))
            {
                return this.Unauthorized();
            }

            var creationInfo = PlaceBuildInfoConverter.Convert(sessionState.UserId, buildInfo);
            var modelPlaceInfo = repository.Create(creationInfo);
            var clientPlaceInfo = PlaceInfoConverter.Convert(modelPlaceInfo);

            var routeParams = new Dictionary<string, object>
            {
                { "placeId", clientPlaceInfo.Id }
            };

            return this.CreatedAtRoute("GetPlaceRoute", routeParams, clientPlaceInfo);
        }

        [HttpGet]
        public IHttpActionResult GetPlaces([FromUri]PlaceFilterInfo placeFilterInfo)
        {
            return this.Ok(new
            {
                Places = repository.Get(PlaceFilterInfoConverter.Convert(placeFilterInfo))
            });
        }

        [HttpGet]
        [Route("{placeId}", Name = "GetPlaceRoute")]
        public IHttpActionResult GetPlace([FromUri]string placeId)
        {

            if (!ModelState.IsValid)
            {
                return this.BadRequest();
            }

            if (!Guid.TryParse(placeId, out var modelPlaceId))
            {
                return this.BadRequest();
            }

            Models.Place.Place modelPlace = null;

            try
            {
                modelPlace = this.repository.Get(modelPlaceId);
            }
            catch (Models.Place.PlaceNotFoundException)
            {
                return this.NotFound();
            }

            return this.Ok(PlaceConverter.Convert(modelPlace));
        }

        [HttpPatch]
        [Route("{placeId}")]
        public IHttpActionResult PatchPlace([FromUri]string placeId, [FromBody]PlacePatchInfo patchInfo)
        {
            if (!ModelState.IsValid)
            {
                return this.BadRequest();
            }

            if (!Guid.TryParse(placeId, out var placeIdGuid))
            {
                return this.BadRequest();
            }

            string sessionId = "";
            CookieHeaderValue cookie = Request.Headers.GetCookies("SessionId").FirstOrDefault();
            if (cookie != null)
            {
                sessionId = cookie["SessionId"].Value;
            }

            if (!authenticator.TryGetSession(sessionId, out var sessionState))
            {
                return this.Unauthorized();
            }

            try
            {
                var place = this.repository.Get(placeIdGuid);
                if (sessionState.UserId != place.OwnerId)
                {
                    return this.Unauthorized();
                }
            }
            catch (Exception)
            {
                return this.Unauthorized();
            }

            var placePatchInfo = PlacePatchInfoConverter.Convert(placeIdGuid, patchInfo);
            Models.Place.Place modelPlace = null;

            try
            {
                modelPlace = this.repository.Patch(placePatchInfo);
            }
            catch (Models.Place.PlaceNotFoundException)
            {
                this.NotFound();
            }

            return Ok(PlaceConverter.Convert(modelPlace));
        }

        [HttpDelete]
        [Route("{placeId}")]
        public IHttpActionResult DeletePlace([FromUri]string placeId)
        {
            if (!ModelState.IsValid)
            {
                return this.BadRequest();
            }

            if (!Guid.TryParse(placeId, out var placeIdGuid))
            {
                return this.BadRequest();
            }
            try
            {
                repository.Remove(placeIdGuid);
            }
            catch (Models.Place.PlaceNotFoundException)
            {
                return this.NotFound();
            }

            return Ok();
        }
    }
}
