using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Client.Models.User
{
    [DataContract]
    public class UserPatchInfo
    {
        /// <summary>
        /// Логин пользователя
        /// </summary>
        [DataMember(IsRequired = false)]
        public string Login;

        /// <summary>
        /// Пароль пользователя
        /// </summary>
        [DataMember(IsRequired = false)]
        public string Password;

        /// <summary>
        /// Идентификатор сессии
        /// </summary>
        [DataMember(IsRequired = true)]
        [Required]
        public string SessionId { get; set; }
    }
}
