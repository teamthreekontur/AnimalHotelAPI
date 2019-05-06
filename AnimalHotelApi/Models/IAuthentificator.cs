using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalHotelApi.Models
{
    public interface IAuthentificator
    {
        SessionState Authenticate(string login, string password);

        SessionState GetSession(Guid sessionId);

        bool TryGetSession(Guid sessionId, out SessionState sessionState);

        bool TryGetSession(string sessionId, out SessionState sessionState);
    }
}
