using System;

namespace Models.Place
{
    /// <summary>
    /// Информация для изменения передержки
    /// </summary>
    class PlacePatchInfo
    {
        /// <summary>
        /// Создает новый экземпляр объекта, описывающего изменение передержки
        /// </summary>
        /// <param name="placeId">Идентификатор передержки, которую нужно изменить</param>
        /// <param name="name">Новый заголовок передержки</param>
        /// <param name="address">Новый адрес передержки</param>
        public PlacePatchInfo(Guid placeId, string name = null, string address = null)
        {
            PlaceId = placeId;
            Name = name;
            Address = address;
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
    }
}
