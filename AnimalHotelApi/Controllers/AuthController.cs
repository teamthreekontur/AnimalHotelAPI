using Client.Models.User;
using Models.User;
using Models.User.Repository;
using System;
using System.Web.Http;

namespace AnimalHotelApi.Controllers
{
    public class AuthController : ApiController
    {
        private readonly IUserRepository repository;
        private readonly IAuthenticator authenticator;

        public AuthController(IUserRepository repository, IAuthenticator authenticator)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
            this.authenticator = authenticator ?? throw new ArgumentNullException(nameof(authenticator));
        }

        public IHttpActionResult Registration([FromBody] UserRegistrationInfo userRegistrationInfo)
        {
            var userInfo = repository.Create(new UserCreateInfo(userRegistrationInfo.Login, userRegistrationInfo.Password, "user"));
            return Ok();
        }

        public IHttpActionResult Enter([FromBody] UserRegistrationInfo userRegistrationInfo)
        {
            var user = authenticator.Authenticate(userRegistrationInfo.Login, userRegistrationInfo.Password);
            return Ok();
        }
    }
}