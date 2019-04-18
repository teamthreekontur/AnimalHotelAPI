using System.Runtime.Serialization;

namespace Client.Models.Place
{
    /// <summary>
    /// Информация для изменения передержки
    /// </summary>
    [DataContract]
    public class PlacePatchInfo
    {
        /// <summary>
        /// Новое название передержки
        /// </summary>
        [DataMember(IsRequired = false)]
        public string Name { get; set; }

        /// <summary>
        /// Новый адрес передержки
        /// </summary>
        [DataMember(IsRequired = false)]
        public string Address { get; set; }
    }
}
