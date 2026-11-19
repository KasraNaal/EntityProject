using EntittyProject.Application.Interface;
using EntityProject.Application.Interface;
using EntityProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntittyProject.Application.UserManagment
{
    public class SearchPerson(IDb db) : ISearchPerson
    {
        public IQueryable<Person> Search(SearchPersonRequest request = null)
        {
            var items = db.Query<Person>();

            if (request is null)
            {
                return items;
            }

            if(request.Id.HasValue)
            {
                items = items.Where(i => i.Id == request.Id);
            }

            if(!string.IsNullOrEmpty(request.KeyWord))
            {
                items = items.Where(i => i.FirstName.Contains(request.KeyWord)||
                                         i.LastName.Contains(request.KeyWord));
            }

            return items;
        }
    }
}
