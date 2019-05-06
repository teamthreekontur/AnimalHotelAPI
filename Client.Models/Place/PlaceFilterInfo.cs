using System.Runtime.Serialization;

namespace Client.Models.Place
{
    /// <summary>
    /// Фильтр по передержкам
    /// </summary>
    [DataContract]
    public class PlaceFilterInfo
    {
        /// <summary>
        /// Фильтр по пользователю
        /// </summary>
        [DataMember(IsRequired = false)]
        public string UserId { get; set; }

        /// <summary>
        /// Фильтр по пользователю
        /// </summary>
        [DataMember(IsRequired = false)]
        public string Name { get; set; }
    }
}
