namespace TechAdv.Core.Entities;
public class CasoJuridico : BaseEntity
{
    public int CasoJuridicoId { get; set; }
    public DateTime DataHora { get; set; }
    public int AdvogadoId { get; set; }
    public required Advogado Advogado { get; set; }
    public int ClienteId { get; set; }
    public required Cliente Cliente {get; set;}
    public ICollection<CasoJuridico>? casoJuridicos { get; set; }
}
