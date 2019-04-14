﻿using System;

namespace Models.Place.Repository
{
    /// <summary>
    /// Интерфейс, описывающий хранилище пользователей
    /// </summary>
    interface IPlaceRepository
    {
        /// <summary>
        /// Создать новую передержку
        /// </summary>
        /// <param name="createInfo">Данные для создания новой передержки</param>
        /// <returns>Созданный пользователь</returns>
        Place Create(PlaceCreateInfo createInfo);

        /// <summary>
        /// Получить передержку по идентификатору
        /// </summary>
        /// <param name="placeId">Идентификатор передержки</param>
        /// <returns>Передержка</returns>
        Place Get(Guid placeId);

        /// <summary>
        /// Получить список передержек по фильтру
        /// </summary>
        /// <param name="placeFilter">Фильтры</param>
        /// <returns>Список передержек</returns>
        Place[] Get(PlaceFilterInfo placeFilter);

        /// <summary>
        /// Изменить информацию о передержке
        /// </summary>
        /// <param name="patchInfo">Информация для изменения</param>
        /// <returns>Передержка</returns>
        Place Patch(PlacePatchInfo patchInfo);

        /// <summary>
        /// Удалить передержку
        /// </summary>
        /// <param name="placeId">Идентификатор передержки</param>
        /// <returns>Передержка</returns>
        Place Delete(Guid placeId);
    }
}