namespace Exame.Models
{
    public class Comentario
    {
        public int Id { get; set; }
        public string User { get; set; }
        public string? Texto { get; set; }
        public DateTime Data { get; set; }
        public int ClubeId { get; set; }
        public Clube Clube { get; set; }
    }
}
