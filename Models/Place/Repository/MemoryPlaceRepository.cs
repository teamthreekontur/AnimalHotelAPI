using System;
using System.Collections.Generic;

namespace Models.Place.Repository
{
    public class MemoryPlaceRepository : IPlaceRepository
    {
        private readonly Dictionary<Guid, Place> primaryKeyIndex;

        /// <summary>
        /// Создает новый экземпляр хранилища передержек в памяти
        /// </summary>
        public MemoryPlaceRepository()
        {
            primaryKeyIndex = new Dictionary<Guid, Place>();
        }

        /// <summary>
        /// Создать новую передержку
        /// </summary>
        /// <param name="creationInfo">Информация для создания передержки</param>
        /// <returns>Информация о созданной передержке</returns>
        public Place Create(PlaceCreateInfo createInfo)
        {
            if (createInfo == null)
            {
                throw new ArgumentNullException(nameof(createInfo));
            }

            var id = Guid.NewGuid();

            var place = new Place
            {
                Id = id,
                Name = createInfo.Name,
                Address = createInfo.Address,
                IdOwner = createInfo.IdOwner
            };

            primaryKeyIndex.Add(id, place);

            return place;
        }

        /// <summary>
        /// Удалить передержку по идентификатору
        /// </summary>
        /// <param name="placeId">Идентификатор передержки</param>
        /// <returns>Передержка</returns>
        public Place Remove(Guid placeId)
        {
            var place = Get(placeId);
            primaryKeyIndex.Remove(placeId);

            return place;
        }

        /// <summary>
        /// Получить передержку по идентификатору
        /// </summary>
        /// <param name="placeId">Идентификатор передержки</param>
        /// <returns>Передержка</returns>
        public Place Get(Guid placeId)
        {
            if (!primaryKeyIndex.TryGetValue(placeId, out var place))
            {
                throw new PlaceNotFoundException(placeId);
            }

            return place;
        }

        /// <summary>
        /// Получить список передержек по значениям полей фильтра
        /// </summary>
        /// <param name="placeFilter">Поля по которым нужно искать передержки</param>
        /// <returns>Список передержек</returns>
        public List<Place> Get(PlaceFilterInfo placeFilter)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Изменить передержку
        /// </summary>
        /// <param name="patchInfo">Описание изменений передержки</param>
        /// <returns>Измененная передержка</returns>
        public Place Patch(PlacePatchInfo patchInfo)
        {
            if (patchInfo == null)
            {
                throw new ArgumentNullException(nameof(patchInfo));
            }

            if (!primaryKeyIndex.TryGetValue(patchInfo.PlaceId, out var place))
            {
                throw new PlaceNotFoundException(patchInfo.PlaceId);
            }

            if (patchInfo.Name != null)
            {
                place.Name = patchInfo.Name;
            }

            if (patchInfo.Address != null)
            {
                place.Address = patchInfo.Address;
            }

            return place;
        }
    }
}
