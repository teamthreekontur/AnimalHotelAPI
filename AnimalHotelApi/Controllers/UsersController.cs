using Client.Models.User;
using Models.User.Repository;
using System.Web.Http;

namespace AnimalHotelApi.Controllers
{
    [RoutePrefix("api/users")]
    public class UsersController : ApiController
    {
        private readonly IUserRepository userRepository;

        public UsersController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        [HttpPatch]
        [Route("{id}")]
        public IHttpActionResult Patch(string id, [FromBody]UserPatchInfo value)
        {
            return this.BadRequest();
        }
    }
}