using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Client.Models.User
{
    /// <summary>
    /// Информация для регистрации пользователя
    /// </summary>
    [DataContract]
    public class UserRegistrationInfo
    {
        /// <summary>
        /// Логин пользователя
        /// </summary>
        [DataMember(IsRequired = true)]
        [Required]
        public string Login { get; set; }

        /// <summary>
        /// Пароль пользователя
        /// </summary>
        [DataMember(IsRequired = true)]
        [Required]
        public string Password { get; set; }
    }
}
