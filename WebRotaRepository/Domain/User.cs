using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebRotaRepository.Domain
{
    public class User
    {

        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public string CPF { get; set; }
        public long Id { get; set; }
    }
}
