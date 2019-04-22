using System;

namespace Client.Models.Place
{
    /// <summary>
    /// Информация о передержке
    /// </summary>
    public class PlaceInfo
    {
        /// <summary>
        /// Идентификатор передержки
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Идентификатор пользователя, которому принадлежит передержка
        /// </summary>
        public string OwnerId { get; set; }

        /// <summary>
        /// Дата создания передержки
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Дата последнего изменения
        /// </summary>
        public DateTime LastUpdatedAt { get; set; }

        /// <summary>
        /// Название передержки
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Адрес передержки
        /// </summary>
        public string Address { get; set; }
    }
}
