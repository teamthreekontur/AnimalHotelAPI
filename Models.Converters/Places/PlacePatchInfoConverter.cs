namespace Models.Converters.Places
{
    using System;
    using Client = Client.Models.Place;
    using Model = Place;

    /// <summary>
    /// Предоставляет методы конвертирования запроса на изменение передержки между клиентской и серверной моделями
    /// </summary>
    public static class PlacePatchInfoConverter
    {
        /// <summary>
        /// Переводит запрос на изменение передержки из клиентской модели в серверную
        /// </summary>
        /// <param name="placeId">Идентификатор передержки</param>
        /// <param name="clientPatchInfo">Запрос на изменение передержки в клиентской модели</param>
        /// <returns>Запрос на изменение передержки в серверной модели</returns>
        public static Model.PlacePatchInfo Convert(Guid placeId, Client.PlacePatchInfo clientPatchInfo)
        {
            if (clientPatchInfo == null)
            {
                throw new ArgumentNullException(nameof(clientPatchInfo));
            }

            var modelPatchInfo = new Model.PlacePatchInfo(placeId)
            {
                Name = clientPatchInfo.Name,
                Address = clientPatchInfo.Address,
                Description = clientPatchInfo.Description,
                Price = clientPatchInfo.Price
            };

            return modelPatchInfo;
        }
    }
}
