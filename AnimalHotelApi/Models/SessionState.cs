namespace AnimalHotelApi.Models
{
    using System;

    public class SessionState
    {
        public SessionState(Guid sessionId, Guid userId)
        {
            SessionId = sessionId ?? throw new ArgumentNullException(nameof(sessionId));
            UserId = userId;
        }

        public Guid SessionId { get; }

        public Guid UserId { get; }
    }
}
