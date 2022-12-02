using System.IdentityModel.Tokens.Jwt;

namespace Domain.Token
{

    public class TokenJwt
    {
        private JwtSecurityToken token;
        internal TokenJwt(JwtSecurityToken token)
        {
            this.token = token;
        }

        public DateTime ValidTo => token.ValidTo;

        public string value => new JwtSecurityTokenHandler().WriteToken(this.token);
    }
}
