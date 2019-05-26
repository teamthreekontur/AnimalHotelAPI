using System.ComponentModel.DataAnnotations;
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

        /// <summary>
        /// Описание передержки
        /// </summary>
        [DataMember(IsRequired = false)]
        public string Description { get; set; }

        /// <summary>
        /// Цена передержки
        /// </summary>
        [DataMember(IsRequired = false)]
        public decimal Price { get; set; }
    }
}
