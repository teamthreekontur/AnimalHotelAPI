using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Booking
{
    /// <summary>
    /// Исключение, которое возникает при попытке получить несуществующую бронь
    /// </summary>
    public class BookingNotFoundException : Exception
    {
        /// <summary>
        /// Инициализировать экземпляр исключения по идентификатору брони
        /// </summary>
        /// <param name="bookingId"></param>
        public BookingNotFoundException(Guid bookingId)
            : base($"A user by id \"{bookingId}\" is not found.")
        {
        }
    }
}
