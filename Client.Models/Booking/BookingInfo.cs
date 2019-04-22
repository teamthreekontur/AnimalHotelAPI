using System;

namespace Client.Models.Booking
{
    /// <summary>
    /// Информация о брони
    /// </summary>
    public class BookingInfo
    {
        /// <summary>
        /// Идентификатор брони
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Идентификатор пользователя, которому принадлежит бронь
        /// </summary>
        public string OwnerId { get; set; }

        /// <summary>
        /// Дата создания брони
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Дата последнего брони
        /// </summary>
        public DateTime LastUpdatedAt { get; set; }

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
