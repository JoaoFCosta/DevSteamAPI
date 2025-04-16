namespace DevSteamAPI.Models
{
    public class JogoMidia
    {
        public Guid JogoMidiaId { get; set; }
        public Guid JogoId { get; set; }
        public Jogo? Jogo { get; set; }
        public string Tipo { get; set; } // Trailer, Imagem, etc
        public string Url { get; set; } // URL do trailer ou imagema
    }
}
