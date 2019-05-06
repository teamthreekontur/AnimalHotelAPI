using Models.User.Repository;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnimalHotelApi.Models
{
    public class MemoryAuthentificator : IAuthentificator
    {
        private readonly Dictionary<Guid, SessionState> sessions =
            new Dictionary<Guid, SessionState>();
        IUserRepository userRepository;

        public MemoryAuthentificator(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public SessionState Authenticate(string login, string password)
        {
            var user = userRepository.Get(login);
            if (user.PasswordHash != Helper.Hash(password))
            {
                throw new ArgumentException("Wrong password", nameof(password));
            }
            var sessionState = new SessionState(Guid.NewGuid(), user.Id);
            sessions.Add(sessionState.SessionId, sessionState);
            return sessionState;
        }

        public SessionState GetSession(Guid sessionId)
        {
            if (!sessions.TryGetValue(sessionId, out var sessionState))
            {
                throw new ArgumentException("Session not found", nameof(sessionId));
            }
            return sessionState;
        }

        public bool TryGetSession(Guid sessionId, out SessionState sessionState)
        {
            try
            {
                sessionState = GetSession(sessionId);
                return true;
            }
            catch(Exception)
            {
                sessionState = null;
                return false;
            }
        }

        public bool TryGetSession(string sessionId, out SessionState sessionState)
        {
            if (!Guid.TryParse(sessionId, out var sessionGuid))
            {
                sessionState = null;
                return false;
            }
            return TryGetSession(sessionGuid, out sessionState);
        }
    }
}