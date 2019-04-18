using System;
using System.Runtime.Serialization;

namespace Client.Models.Booking
{
    /// <summary>
    /// Информация для изменения брони
    /// </summary>
    [DataContract]
    class BookingPatchInfo
    {
        /// <summary>
        /// Начало брони
        /// </summary>
        [DataMember(IsRequired = false)]
        public DateTime DateFrom { get; set; }

        /// <summary>
        /// Конец брони
        /// </summary>
        [DataMember(IsRequired = false)]
        public DateTime DateTo { get; set; }
    }
}
