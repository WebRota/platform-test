using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebRota.Domain.Entities;

namespace WebRota.Domain.Interfaces
{
    public interface IUserRepository
    {
        User Save(User user);
        User Update(User user);
        User Get(long id);
        List<User> GetAll(int page = 0,int pageSize = 10 );
        public string Delete(long id);
    }
}
