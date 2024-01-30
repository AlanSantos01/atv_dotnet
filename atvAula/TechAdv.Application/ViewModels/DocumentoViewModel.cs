using TechAdv.Core.Entities;

namespace TechAdv.Application.ViewModels
{
   public class DocumentoViewModel
   {
      public int DocumentoId { get; set; }
      public string Nome { get; set; } = null!;
      public DateTimeOffset DataHora { get; set; }
      public CasoJuridicoViewModel CasoJuridico { get; set; } = null!;
   }
}
