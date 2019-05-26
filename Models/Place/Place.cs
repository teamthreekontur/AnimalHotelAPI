using System;

namespace Models.Place
{
    /// <summary>
    /// Передержка
    /// </summary>
    public class Place
    {
        /// <summary>
        /// Идентификатор передержки
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Название передержки
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Адрес передержки
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Идентификатор владельца передержки
        /// </summary>
        public Guid OwnerId { get; set; }

        /// <summary>
        /// Описание передержки
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Цена передержки
        /// </summary>
        public decimal Price { get; set; }
    }
}
