using Models.User;
using System;

namespace Models.Place
{
    /// <summary>
    /// Информация для создания передержки
    /// </summary>
    class PlaceCreateInfo
    {
        /// <summary>
        /// Инициализирует новый экземпляр описания для создания передержки
        /// </summary>
        /// <param name="name">Название передержки</param>
        /// <param name="address">Адрес передержки</param>
        /// <param name="idOwner">Идентификатор владельца передержки</param>
        public PlaceCreateInfo(string name, string address, Guid idOwner)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Address = address ?? throw new ArgumentNullException(nameof(address));
            IdOwner = idOwner;
        }

        /// <summary>
        /// Название передержки
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Адрес передержки
        /// </summary>
        public string Address { get; }

        /// <summary>
        /// Идентификатор владельца передержки
        /// </summary>
        public Guid IdOwner { get; }
    }
}
