namespace Exame.Models
{
    public class Clube
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Sigla { get; set; }
        public string? Foto { get; set; }

        public IEnumerable<Comentario>? Comentarios { get; set; }
    }
}
