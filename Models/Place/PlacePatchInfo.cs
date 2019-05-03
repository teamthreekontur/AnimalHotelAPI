using System;

namespace Models.Place
{
    /// <summary>
    /// Информация для изменения передержки
    /// </summary>
    public class PlacePatchInfo
    {
        /// <summary>
        /// Создает новый экземпляр объекта, описывающего изменение передержки
        /// </summary>
        /// <param name="placeId">Идентификатор передержки, которую нужно изменить</param>
        /// <param name="name">Новый заголовок передержки</param>
        /// <param name="address">Новый адрес передержки</param>
        /// <param name="description">Новое описание передержки</param>
        /// <param name="price">Новая цена передержки</param>
        public PlacePatchInfo(Guid placeId, string name = null, string address = null, string description = null, decimal price = 0)
        {
            PlaceId = placeId;
            Name = name;
            Address = address;
            Description = description;
            Price = price;
        }

        /// <summary>
        /// Идентификатор передержки, которую нужно изменить
        /// </summary>
        public Guid PlaceId { get; }

        /// <summary>
        /// Новый заголовок передержки
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Новый адрес передержки
        /// </summary>
        public string Address { get; set; }

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
