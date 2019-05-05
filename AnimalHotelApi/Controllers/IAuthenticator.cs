namespace AnimalHotelApi.Controllers
{
    using System.Threading;
    using System.Threading.Tasks;

    public interface IAuthenticator
    {
        SessionState Authenticate(string login, string password);

        SessionState GetSession(string sessionId);
    }
}
