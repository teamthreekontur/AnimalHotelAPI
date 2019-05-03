namespace Models.Converters.Places
{
    using System;
    using Client = Client.Models.Place;
    using Model = Models.Place;

    /// <summary>
    /// Предоставляет методы конвертирования передержки между серверной и клиентской моделями
    /// </summary>
    public static class PlaceConverter
    {
        /// <summary>
        /// Переводит передержку из серверной модели в клиентскую
        /// </summary>
        /// <param name="modelPlace">Передержка в серверной модели</param>
        /// <returns>Передержка в клиентской модели</returns>
        public static Client.Place Convert(Model.Place modelPlace)
        {
            if (modelPlace == null)
            {
                throw new ArgumentNullException(nameof(modelPlace));
            }

            var clientNote = new Client.Place
            {
                Id = modelPlace.Id.ToString(),
                Name = modelPlace.Name,
                Address = modelPlace.Address,
                Price = modelPlace.Price,
                Description = modelPlace.Description,
                OwnerId = modelPlace.IdOwner.ToString()
            };

            return clientNote;
        }
    }
}
