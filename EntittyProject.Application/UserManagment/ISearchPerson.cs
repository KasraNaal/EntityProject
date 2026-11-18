using EntityProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntittyProject.Application.UserManagment
{
    public interface ISearchPerson
    {
        IQueryable<Person> Search(SearchPersonRequest request = null);
    }

    public class SearchPersonRequest
    {
        public int? Id { get; set; }
        public string KeyWord { get; set; }
    }
}
