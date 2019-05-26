using AnimalHotelApi.Models;
using Client.Models.User;
using Models.User;
using Models.User.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;

namespace AnimalHotelApi.Controllers
{
    [RoutePrefix("api/auth")]
    public class AuthController : ApiController
    {
        private readonly IUserRepository userRepository;
        private readonly IAuthentificator authenticator;

        public AuthController(IUserRepository repository, IAuthentificator authenticator)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
            this.authenticator = authenticator ?? throw new ArgumentNullException(nameof(authenticator));
        }

        [HttpPost]
        public HttpResponseMessage Auth([FromBody] UserRegistrationInfo userRegisterInfo)
        {
            if (!ModelState.IsValid)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
            try
            {
                var session = authenticator.Authenticate(userRegisterInfo.Login, userRegisterInfo.Password);
                var cookie = new CookieHeaderValue("SessionId", session.SessionId.ToString());
                cookie.Expires = DateTimeOffset.Now.AddMonths(1);
                cookie.Domain = Request.RequestUri.Host;
                cookie.Path = "/"; 
                var response = Request.CreateResponse<SessionState>(HttpStatusCode.OK, session);
                response.Headers.AddCookies(new CookieHeaderValue[] { cookie });
                return response;
            }
            catch (UserNotFoundException)
            {
                return new HttpResponseMessage(HttpStatusCode.NotFound);
            }
            catch (Exception)
            {
                return new HttpResponseMessage(HttpStatusCode.Conflict);
            }
        }
    }
}