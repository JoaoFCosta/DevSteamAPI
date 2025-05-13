using Microsoft.AspNetCore.Identity;

namespace DevSteamAPI.Models
{
    public class Usuario : IdentityUser
    {

        public string? NomeCompleto { get; set; }
        public DateOnly DataNascimento { get; set; }
        public string Email { get; set; }

        public Usuario() : base()
        {
        }
    }
}

