using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityProject.Persistence
{
    public class User
    {
        public int UserId { get; set; }
        [StringLength(20)]
        public string FirstName{ get; set; }
        [StringLength(20)]
        public string LastName { get; set; }
        [Required]
        [StringLength(50)]
        public string UserName { get; set; }
        [Required]
        [StringLength(100)]
        public string Password { get; set; }
        public DateTime Birthday { get; set; }
    }
}
