using Models.User.Repository;
using System.Web.Http;

namespace AnimalHotelApi.Controllers
{
    public class UsersController : ApiController
    {
        private readonly IUserRepository userRepository;

        public UsersController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        [HttpPatch]
        public IHttpActionResult Patch(string guid, [FromBody]string value)
        {
            return this.BadRequest();
        }
    }
}