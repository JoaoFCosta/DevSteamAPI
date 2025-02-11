using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace DevSteamAPI.Models
{
    public class ItemCarrinho
    {
        public Guid ItemCarrinhoId { get; set; }
        public Guid CarrinhoId { get; set; }
        public Guid JogoId { get; set; }

        [Required(ErrorMessage = "O Campo é Obrigatorio")]
        [Range(1, int.MaxValue, ErrorMessage = "A Quantidade deve ser maior que 0")]
        public int Quantidade { get; set; }
        [Required(ErrorMessage = "O Campo é Obrigatorio")]
        [Range(0.01, 9999.99, ErrorMessage = "O Valor deve ser maior que 0 e menor que R$9.999,99")]
        public decimal Valor { get; set; }
        public decimal Total { get; set; }
    }
}
