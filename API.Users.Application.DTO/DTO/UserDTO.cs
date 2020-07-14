namespace API.Users.Application.DTO.DTO
{
    /// <summary>
    /// User
    /// </summary>
    public class UserDTO
    {
        /// <summary>
        /// id of the User
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// User FirstName
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// User LastName
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// User Username
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// User Email
        /// </summary>
        public string Email { get; set; }
    }
}
