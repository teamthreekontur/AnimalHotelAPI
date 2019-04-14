using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Booking
{
    /// <summary>
    /// Информация для создания брони
    /// </summary>
    class BookingCreateInfo
    {
        /// <summary>
        /// Инициализирует новый экземпляр описания для создания брони
        /// </summary>
        /// <param name="date">Период брони</param>
        public BookingCreateInfo(DateTime date)
        {
            //Date = date ?? throw new ArgumentNullException(nameof(date));
        }

        /// <summary>
        /// Период брони
        /// </summary>
        public DateTime Date { get; }
    }
}
