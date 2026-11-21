using EntittyProject.Domain.Interfaces;

namespace EntittyProject.Domain.Entities
{
    public class Person : IEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
