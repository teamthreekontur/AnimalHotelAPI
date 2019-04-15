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

        /// <summary>
        /// Изменить заметку
        /// </summary>
        /// <param name="patchInfo">Описание изменений заметки</param>
        /// <param name="cancelltionToken">Токен отмены операции</param>
        /// <returns>Задача, представляющая асинхронный запрос на изменение заметки. Результат выполнения - актуальное состояние заметки</returns>
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

            var updated = false;

            if (patchInfo.Name != null)
            {
                place.Name = patchInfo.Name;
                updated = true;
            }

            if (patchInfo.Address != null)
            {
                place.Address = patchInfo.Address;
                updated = true;
            }

            //if (patchInfo.Favorite != null)
            //{
            //    note.Favorite = patchInfo.Favorite.Value;
            //    updated = true;
            //}

            if (updated)
            {
                //place.LastUpdatedAt = DateTime.UtcNow;
            }

            return place;
        }
    }
}
