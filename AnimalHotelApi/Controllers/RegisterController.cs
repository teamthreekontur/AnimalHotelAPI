using Client.Models.User;
using Models.Converters.Users;
using Models.User;
using Models.User.Repository;
using System;
using System.Web.Http;

namespace AnimalHotelApi.Controllers
{
    [RoutePrefix("api/register")]
    public class RegisterController : ApiController
    {
        private readonly IUserRepository userRepository;
        public RegisterController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        [HttpPost]
        public IHttpActionResult Post([FromBody] UserRegistrationInfo userRegisterInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                var user = userRepository.Create(UserConverter.Convert(userRegisterInfo));
                return this.Ok(user);
            }
            catch (UserDuplicationException)
            {
                return Conflict();
            }
        }
    }
}