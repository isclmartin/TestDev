namespace DEV.Entities
{
    public class User
    {
        public string UserName { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public List<Role> Roles { get; set; }
    }
}
