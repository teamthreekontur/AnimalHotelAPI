namespace Models.Converters.Places
{
    using System;
    using Client = Client.Models.Place;
    using Model = Place;

    /// <summary>
    /// Предоставляет методы конвертирования информации о передержке между серверной и клиентской моделями
    /// </summary>
    public static class PlaceInfoConverter
    {
        /// <summary>
        /// Переводит информацию о передержке из серверной модели в клиентскую
        /// </summary>
        /// <param name="modelPlaceInfo">Информация о передержке в серверной модели</param>
        /// <returns>Информация о передержке в клиентской модели</returns>
        public static Client.PlaceInfo Convert(Model.Place modelPlaceInfo)
        {
            if (modelPlaceInfo == null)
            {
                throw new ArgumentNullException(nameof(modelPlaceInfo));
            }

            var clientNoteInfo = new Client.PlaceInfo
            {
                Id = modelPlaceInfo.Id.ToString(),
                Name = modelPlaceInfo.Name,
                Address = modelPlaceInfo.Address,
                Price = modelPlaceInfo.Price,
                Description = modelPlaceInfo.Description,
                OwnerId = modelPlaceInfo.OwnerId.ToString()
            };

            return clientNoteInfo;
        }
    }
}