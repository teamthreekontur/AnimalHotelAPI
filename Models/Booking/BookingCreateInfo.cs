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
    public class BookingCreateInfo
    {
        /// <summary>
        /// Инициализирует новый экземпляр описания для создания брони
        /// </summary>
        /// <param name="dateFrom">Начало брони</param>
        /// <param name="dateTo">Конец брони</param>
        public BookingCreateInfo(DateTime dateFrom, DateTime dateTo)
        {
            DateFrom = dateFrom;
            DateTo = dateTo;
        }

        /// <summary>
        /// Начало брони
        /// </summary>
        public DateTime DateFrom { get; }

        /// <summary>
        /// Конец брони
        /// </summary>
        public DateTime DateTo { get; }
    }
}
