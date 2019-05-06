using Models.User.Repository;
using MongoDB.Driver;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnimalHotelApi.Models
{
    public class DbAuthentificator : IAuthentificator
    {
        private readonly IMongoCollection<SessionState> sessions;
        IUserRepository userRepository;

        public DbAuthentificator(IMongoClient mongoClient, IUserRepository userRepository)
        {
            var database = mongoClient.GetDatabase("AnimalHotel");
            sessions = database.GetCollection<SessionState>("Sessions");
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
            sessions.InsertOne(sessionState);
            return sessionState;
        }

        public SessionState GetSession(Guid sessionId)
        {
            var searchResult = sessions.Find(x => x.SessionId == sessionId);
            if (!searchResult.Any())
            {
                throw new ArgumentException("Session not found", nameof(sessionId));
            }
            searchResult.First();
            throw new NotImplementedException();
        }

        public bool TryGetSession(Guid sessionId, out SessionState sessionState)
        {
            try
            {
                sessionState = GetSession(sessionId);
                return true;
            }
            catch (Exception)
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