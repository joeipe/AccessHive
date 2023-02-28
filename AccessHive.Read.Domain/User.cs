namespace AccessHive.Read.Domain
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public int Weight { get; set; }
        public int RoleId { get; set; }

        public Role Role { get; set; } = null!;
    }
}