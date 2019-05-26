﻿namespace AnimalHotelApi.Controllers
{
    using System;

    public class SessionState
    {
        public SessionState(string sessionId, Guid userId)
        {
            SessionId = sessionId ?? throw new ArgumentNullException(nameof(sessionId));
            UserId = userId;
        }

        public string SessionId { get; }

        public Guid UserId { get; }
    }
}