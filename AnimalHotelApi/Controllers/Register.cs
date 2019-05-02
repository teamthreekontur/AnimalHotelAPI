using Client.Models.User;
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
            if (userRegisterInfo == null)
            {
                return this.BadRequest();
            }
            var uci = new UserCreateInfo(userRegisterInfo.Login, userRegisterInfo.Password, "user");
            try
            {
                var user = userRepository.Create(uci);
                return this.Ok(user);
            }
            catch (Exception)
            {
                return this.Conflict();
            }
        }
    }
}