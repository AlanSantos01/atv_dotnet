namespace TechAdv.Application.InputModels
{
   public class NewDocumentoInputModel
   {
      public required string Nome { get; set; }
      public DateTime DataHora { get; set; }
      public int CasoJuridicoId { get; set; }
   }
}
