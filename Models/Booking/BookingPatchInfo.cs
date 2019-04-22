using System;

namespace Models.Booking
{
    /// <summary>
    /// Информация для изменения брони
    /// </summary>
    public class BookingPatchInfo
    {
        /// <summary>
        /// Создает новый экземпляр объекта, описывающего изменение брони
        /// </summary>
        /// <param name="bookingId">Идентификатор брони, которую нужно изменить</param>
        /// <param name="dateFrom">Новое начало брони</param>
        /// <param name="dateTo">Новый конец брони</param>
        public BookingPatchInfo(Guid bookingId, DateTime dateFrom, DateTime dateTo)
        {
            BookingId = bookingId;
            DateFrom = dateFrom;
            DateTo = dateTo;
        }

        /// <summary>
        /// Идентификатор передержки, которую нужно изменить
        /// </summary>
        public Guid BookingId { get; }

        /// <summary>
        /// Новый заголовок передержки
        /// </summary>
        public DateTime DateFrom { get; set; }

        /// <summary>
        /// Новый адрес передержки
        /// </summary>
        public DateTime DateTo { get; set; }
    }
}
