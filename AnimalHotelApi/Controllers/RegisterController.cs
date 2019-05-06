using Client.Models.User;
using Models.Converters.Users;
using Models.User;
using Models.User.Repository;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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
                return this.BadRequest();
            }

            try
            {
                var user = userRepository.Create(UserConverter.Convert(userRegisterInfo));
                return this.Ok(user);
            }
            catch (UserDuplicationException)
            {
                return this.Conflict();
            }
        }
    }
}