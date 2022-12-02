using Domain.Enum;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Usuario : IdentityUser
    {
        [Column("USR_CPF")]
        public string CPF { get; set; } = null!;

        [Column("USR_TIPO")]
        public PerfilUsuario PermissaoUsuario { get; set; }
    }
}