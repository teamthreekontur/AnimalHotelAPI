using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Booking.Repository
{
    class MemoryBookingRepository : IBookingRepository
    {
        private readonly Dictionary<Guid, Booking> primaryKeyIndex;

        /// <summary>
        /// Создает новый экземпляр хранилища броней в памяти
        /// </summary>
        public MemoryBookingRepository()
        {
            primaryKeyIndex = new Dictionary<Guid, Booking>();
        }

        /// <summary>
        /// Создать новую бронь
        /// </summary>
        /// <param name="creationInfo">Информация для создания брони</param>
        /// <returns>Информация о созданной брони</returns>
        public Booking Create(BookingCreateInfo createInfo)
        {
            if (createInfo == null)
            {
                throw new ArgumentNullException(nameof(createInfo));
            }

            var id = Guid.NewGuid();

            var booking = new Booking
            {
                Id = id,
                Date = createInfo.Date
            };

            primaryKeyIndex.Add(id, booking);

            return booking;
        }

        /// <summary>
        /// Удалить бронь по идентификатору
        /// </summary>
        /// <param name="bookingId">Идентификатор брони</param>
        /// <returns>Бронь</returns>
        public Booking Delete(Guid bookingId)
        {
            var booking = Get(bookingId);
            primaryKeyIndex.Remove(bookingId);

            return booking;
        }

        /// <summary>
        /// Получить бронь по идентификатору
        /// </summary>
        /// <param name="bookingId">Идентификатор брони</param>
        /// <returns>Бронь</returns>
        public Booking Get(Guid bookingId)
        {
            if (!primaryKeyIndex.TryGetValue(bookingId, out var booking))
            {
                throw new BookingNotFoundException(bookingId);
            }

            return booking;
        }

        public Booking[] Get(BookingFilterInfo bookingFilter)
        {
            throw new NotImplementedException();
        }

        public Booking Patch(BookingPatchInfo patchInfo)
        {
            throw new NotImplementedException();
        }
    }
}
