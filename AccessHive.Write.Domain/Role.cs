using SharedKernel;

namespace AccessHive.Write.Domain
{
    public class Role : Entity
    {
        public string Name { get; set; } = null!;

        public List<User> Users { get; set; } = null!;
    }
}