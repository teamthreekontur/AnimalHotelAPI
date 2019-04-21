using System;

namespace Models.Booking.Repository
{
    /// <summary>
    /// Интерфейс, описывающий хранилище броней
    /// </summary>
    interface IBookingRepository
    {
        /// <summary>
        /// Создать новую бронь
        /// </summary>
        /// <param name="createInfo">Данные для создания новой брони</param>
        /// <returns>Созданная бронь</returns>
        Booking Create(BookingCreateInfo createInfo);

        /// <summary>
        /// Получить бронь по идентификатору
        /// </summary>
        /// <param name="bookingId">Идентификатор брони</param>
        /// <returns>Бронь</returns>
        Booking Get(Guid bookingId);

        /// <summary>
        /// Получить список броней по фильтру
        /// </summary>
        /// <param name="bookingFilter">Фильтры</param>
        /// <returns>Список броней</returns>
        Booking[] Get(BookingFilterInfo bookingFilter);

        /// <summary>
        /// Изменить информацию о брони
        /// </summary>
        /// <param name="patchInfo">Информация для изменения</param>
        /// <returns>Бронь</returns>
        Booking Patch(BookingPatchInfo patchInfo);

        /// <summary>
        /// Удалить бронь
        /// </summary>
        /// <param name="bookingId">Идентификатор брони</param>
        /// <returns>Бронь</returns>
        Booking Remove(Guid bookingId);
    }
}
