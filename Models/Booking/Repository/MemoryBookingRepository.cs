using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Booking.Repository
{
    public class MemoryBookingRepository : IBookingRepository
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
                DateFrom = createInfo.DateFrom,
                DateTo = createInfo.DateTo
            };

            primaryKeyIndex.Add(id, booking);

            return booking;
        }

        /// <summary>
        /// Удалить бронь по идентификатору
        /// </summary>
        /// <param name="bookingId">Идентификатор брони</param>
        /// <returns>Бронь</returns>
        public Booking Remove(Guid bookingId)
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

        /// <summary>
        /// Изменить бронь
        /// </summary>
        /// <param name="patchInfo">Описание изменений брони</param>
        /// <returns>Измененная бронь</returns>
        public Booking Patch(BookingPatchInfo patchInfo)
        {
            if (patchInfo == null)
            {
                throw new ArgumentNullException(nameof(patchInfo));
            }

            if (!primaryKeyIndex.TryGetValue(patchInfo.BookingId, out var booking))
            {
                throw new BookingNotFoundException(patchInfo.BookingId);
            }

            if (patchInfo.DateFrom != null)
            {
                booking.DateFrom = patchInfo.DateFrom;
            }

            if (patchInfo.DateTo != null)
            {
                booking.DateTo = patchInfo.DateTo;
            }

            return booking;
        }
    }
}
