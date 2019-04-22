using System;
using System.Runtime.Serialization;

namespace Client.Models.Booking
{
    /// <summary>
    /// Информация для создания брони
    /// </summary>
    [DataContract]
    public class BookingBuildInfo
    {
        /// <summary>
        /// Начало брони
        /// </summary>
        [DataMember(IsRequired = true)]
        public DateTime DateFrom { get; set; }

        /// <summary>
        /// Конец брони
        /// </summary>
        [DataMember(IsRequired = true)]
        public DateTime DateTo { get; set; }
    }
}
