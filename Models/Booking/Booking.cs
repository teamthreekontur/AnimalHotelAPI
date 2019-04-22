using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Booking
{
    /// <summary>
    /// Бронь
    /// </summary>
    public class Booking
    {
        /// <summary>
        /// Идентификатор брони
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Начало брони
        /// </summary>
        public DateTime DateFrom { get; set; }

        /// <summary>
        /// Конец брони
        /// </summary>
        public DateTime DateTo { get; set; }
    }
}
