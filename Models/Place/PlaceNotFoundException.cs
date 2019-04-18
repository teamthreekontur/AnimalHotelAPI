using System;

namespace Models.Place
{
    /// <summary>
    /// Исключение, которое возникает при попытке получить несуществующую передержку
    /// </summary>
    public class PlaceNotFoundException : Exception
    {
        /// <summary>
        /// Инициализировать экземпляр исключения по идентификатору передержки
        /// </summary>
        /// <param name="placeId"></param>
        public PlaceNotFoundException(Guid placeId)
            : base($"A user by id \"{placeId}\" is not found.")
        {
        }
    }
}
