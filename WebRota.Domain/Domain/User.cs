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

        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "E-mail invalido!")]

        public string Email { get; set; }

        [Required(ErrorMessage = "A senha é obrigatoria!")]
        public string Password { get; set; }

        public string Role { get; set; }

        public string Phone { get; set; }

        [RegularExpression(@"^\d{11}$", ErrorMessage = "CPF inválido. Deve conter 11 dígitos numéricos.")]
        public string CPF { get; set; }

    }
}
