namespace AnimalHotelApi.Controllers
{
    public interface IAuthenticator
    {
        SessionState Authenticate(string login, string password);
        SessionState GetSession(string sessionId);
    }
}
