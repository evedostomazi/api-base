using Domain.Enum;

namespace Domain.DTOs.Output
{
    public class TokenOutput
    {
        public string token_acesso { get; set; } = null!;
        public PerfilUsuario perfil_usuario { get; set; }


    }
}
