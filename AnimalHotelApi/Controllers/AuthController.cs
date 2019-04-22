using Models.User;
using Models.User.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AnimalHotelApi.Controllers
{
    public class AuthController : ApiController
    {
        private readonly IUserRepository repository;
        private readonly IAuthenticator authenticator;

        public AuthController(IUserRepository repository, IAuthenticator authenticator)
        {
            if (repository == null)
            {
                throw new ArgumentNullException(nameof(repository));
            }

            this.repository = repository;
            this.authenticator = authenticator;
        }

        public IActionResult Registration([FromBody] UserRegistrationInfo userRegistrationInfo)
        {
            var userInfo = this.repository.Create(new UserCreationInfo(userRegistrationInfo.Login, userRegistrationInfo.Password));
            return this.Ok();
        }

        public IActionResult Enter([FromBody] UserRegistrationInfo userRegistrationInfo)
        {
            var user = this.authenticator.AuthenticateAsync(userRegistrationInfo.Login, userRegistrationInfo.Password);
            return this.Ok();
        }
    }
}