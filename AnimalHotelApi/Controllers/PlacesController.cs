using Models.Place;
using Models.Place.Repository;
using ClientPlace = Client.Models.Place;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AnimalHotelApi.Controllers
{
    public class PlacesController : ApiController
    {
        private readonly IPlaceRepository placeRepository;
        public PlacesController(IPlaceRepository placeRepository)
        {
            this.placeRepository = placeRepository;
        }
        
        [HttpGet]
        public IHttpActionResult Get([FromBody]ClientPlace.PlaceFilterInfo placeFilterInfo)
        {
            return this.Ok(placeRepository.Get(new PlaceFilterInfo())
                .Select(x => new ClientPlace.Place()
                {
                    Address = x.Address,
                    Id = x.Id.ToString(),
                    OwnerId = x.IdOwner.ToString(),
                    Name = x.Name
                }));
        }

        [HttpGet]
        public IHttpActionResult Get(string id)
        {
            if (!Guid.TryParse(id, out var guid))
            {
                return this.BadRequest();
            }
            try
            {
                return this.Ok(placeRepository.Get(guid));
            }
            catch
            {
                return this.NotFound();
            }
        }

        //[HttpPost]
        //public IHttpActionResult Post([FromBody]ClientPlace.PlaceBuildInfo placeBuildInfo)
        //{
            
        //    var placeCreateInfo = new PlaceCreateInfo(placeBuildInfo.Name, placeBuildInfo.Address);
        //}
        
        //[HttpPatch]
        //public IHttpActionResult Patch(string id, [FromBody]ClientPlace.PlacePatchInfo placePatchInfo)
        //{
        //}

        //[HttpDelete]
        //public IHttpActionResult Delete(string id)
        //{
        //}
    }
}