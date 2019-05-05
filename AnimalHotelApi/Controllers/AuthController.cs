using Client.Models.User;
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

        public IHttpActionResult Registration([FromBody] UserRegistrationInfo userRegistrationInfo)
        {
            var userInfo = this.repository.Create(new UserCreateInfo(userRegistrationInfo.Login, userRegistrationInfo.Password, "user"));
            return this.Ok();
        }

        public IHttpActionResult Enter([FromBody] UserRegistrationInfo userRegistrationInfo)
        {
            var user = this.authenticator.Authenticate(userRegistrationInfo.Login, userRegistrationInfo.Password);
            return this.Ok();
        }
    }
}