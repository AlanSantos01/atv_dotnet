namespace TechAdv.Core.Entities;
public class Documento : BaseEntity
{
   public int DocumentoId { get; set; }
   public string Nome { get; set; } = null!;
   public DateTimeOffset DataHora { get; set; }
}
