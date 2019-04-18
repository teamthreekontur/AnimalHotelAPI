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

        /// <summary>
        /// Получить пользователя по логину
        /// </summary>
        /// <param name="login">Логин пользователя</param>
        /// <returns>Пользователь</returns>
        User Get(string login);

        /// <summary>
        /// Изменить информацию о пользователе
        /// </summary>
        /// <param name="patchInfo">Информация для изменения</param>
        /// <returns>Пользователь</returns>
        User Patch(UserPatchInfo patchInfo);

        /// <summary>
        /// Удалить пользователя
        /// </summary>
        /// <param name="userId">Идентификатор пользователя</param>
        /// <returns>Пользователь</returns>
        User Remove(Guid userId);
    }
}
