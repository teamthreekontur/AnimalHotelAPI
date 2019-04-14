using System;
using System.Collections.Generic;

namespace Models.Place.Repository
{
    class MemoryPlaceRepository : IPlaceRepository
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
        public Place Delete(Guid placeId)
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

        public Place[] Get(PlaceFilterInfo placeFilter)
        {
            throw new NotImplementedException();
        }

        public Place Patch(PlaceCreateInfo patchInfo)
        {
            throw new NotImplementedException();
        }
    }
}
