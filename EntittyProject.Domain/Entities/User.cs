using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using EntittyProject.Domain.Interfaces;

namespace EntityProject.Domain.Entities
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
