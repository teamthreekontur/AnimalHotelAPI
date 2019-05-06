using AnimalHotelApi.Models;
using Models.User;
using Models.User.Repository;
using System;
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
        public IHttpActionResult Post([FromBody] UserRegisterInfo userRegisterInfo)
        {
            if (userRegisterInfo == null)
            {
                return BadRequest();
            }
            var uci = new UserCreateInfo(userRegisterInfo.Username, userRegisterInfo.Password, "user");
            try
            {
                var user = userRepository.Create(uci);
                return Ok(user);
            }
            catch (Exception)
            {
                return Conflict();
            }
        }
    }
}