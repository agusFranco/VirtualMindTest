namespace Domain
{
    public class User
    {
        /// <summary>
        /// Gets or sets the Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the LastName
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the Email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or set the password
        /// </summary>
        public string Password { get; set; }

        public void ApplyTo(User user)
        {
            user.Id = Id;
            user.Name = Name;
            user.Password = Password;
            user.Email = Email;
            user.LastName = LastName;
        }
    }
}
