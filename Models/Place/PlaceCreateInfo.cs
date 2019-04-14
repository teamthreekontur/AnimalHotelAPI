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
        public PlaceCreateInfo(string name, string address)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Address = address ?? throw new ArgumentNullException(nameof(address));
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
        /// Id владельца передержки
        /// </summary>
        public Guid IdOwner { get; }
    }
}
