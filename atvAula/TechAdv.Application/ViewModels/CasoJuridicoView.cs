namespace TechAdv.Application.ViewModels
{
   public class CasoJuridicoViewModel
   {
      public int CasoJuridicoId { get; set; }
      public DateTime DataHora { get; set; }
      public ClienteViewModel Paciente { get; set; } = null!;
      public AdvogadoViewModel Medico { get; set; } = null!;
   }
}