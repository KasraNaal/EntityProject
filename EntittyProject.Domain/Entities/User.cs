using EntittyProject.Domain.Interfaces;

namespace EntittyProject.Domain.Entities
{
    public class User : IEntity
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public Person Person { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
