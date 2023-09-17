using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebRota.Domain.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }


        public string Email { get; set; }

        [Required(ErrorMessage = "Este Campo é Obrigatorio!")]
        public string Password { get; set; }

        public string Role { get; set; }

        public string Phone { get; set; }

        public string cpf { get; set; }

    }
}
