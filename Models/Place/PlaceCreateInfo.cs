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
        /// <param name="nameOwner">Имя владельца передержки</param>
        public PlaceCreateInfo(string name, string address, string nameOwner)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Address = address ?? throw new ArgumentNullException(nameof(address));
            NameOwner = nameOwner ?? throw new ArgumentNullException(nameof(nameOwner));
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
        /// Имя владельца передержки
        /// </summary>
        public string NameOwner { get; }
    }
}
