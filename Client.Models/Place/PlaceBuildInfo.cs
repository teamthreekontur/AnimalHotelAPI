using System.Runtime.Serialization;

namespace Client.Models.Place
{
    /// <summary>
    /// Информация для создания передержки
    /// </summary>
    [DataContract]
    public class PlaceBuildInfo
    {
        /// <summary>
        /// Название передержки
        /// </summary>
        [DataMember(IsRequired = true)]
        public string Name { get; set; }

        /// <summary>
        /// Адрес передержки
        /// </summary>
        [DataMember(IsRequired = true)]
        public string Address { get; set; }
    }
}
