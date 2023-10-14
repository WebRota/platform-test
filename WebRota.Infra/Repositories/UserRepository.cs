using Microsoft.EntityFrameworkCore;
using WebRota.Domain.Entities;
using WebRota.Domain.Interfaces;
using WebRota.Infra.Context;

namespace WebRota.Infra.Repositories
{
    public class UserRepository : IUserRepository
    {
        protected readonly WebRotaContext _context;

        public UserRepository(WebRotaContext context) 
        {  
            _context = context; 
        }
        public User Get(long id)
        {
            try
            {
                var User = _context.Users.FirstOrDefault(x => x.Id == id);
                return User;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public List<User> GetAll(int page = 0, int pageSize = 10)
        {
            try
            {
                var Users = _context.Users.ToList();
                return Users;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public User Save(User user)
        {
            try
            {
                var Users = _context.Users.Add(user);
                _context.SaveChanges();
                return user;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public User Update(User user)
        {
            try
            {
                var Users = _context.Users.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
                return user;
            }
            catch (Exception ex)
            {
                throw ex;
            };
        }

        public string Delete(long id)
        {
            try
            {
                var User = _context.Users.FirstOrDefault(x => x.Id == id);
                if (User == null)
                {
                    return "Usuario não encontrado";
                }
                _context.Users.Remove(User);
                _context.SaveChanges();
                return "Sucesso ao remover usuario";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public User login(string email, string password)
        {
            try
            {
                var user = _context.Users
                    .FirstOrDefault(x => x.Email == email && x.Password == password);
                return user;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
