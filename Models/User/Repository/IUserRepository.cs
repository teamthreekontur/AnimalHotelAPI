using System;

namespace Models.User.Repository
{
    /// <summary>
    /// Интерфейс, описывающий хранилище пользователей
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// Создать нового пользователя
        /// </summary>
        /// <param name="createInfo">Данные для создания нового пользователя</param>
        /// <returns>Созданный пользователь</returns>
        User Create(UserCreateInfo createInfo);

        /// <summary>
        /// Получить пользователя по идентификатору
        /// </summary>
        /// <param name="userId">Идентификатор пользователя</param>
        /// <returns>Пользователь</returns>
        User Get(Guid userId);


        User Patch(UserPatchInfo patchInfo);
    }
}
