using TechAdv.Application.InputModels;
using TechAdv.Application.ViewModels;

namespace TechAdv.Application.Services.Interfaces;
public interface IAtendimentoService
{
   public List<CasoJuridicoViewModel> GetAll();
   public CasoJuridicoViewModel? GetById(int id);
   public List<CasoJuridicoViewModel> GetByClienteId(int clienteId);
   public List<CasoJuridicoViewModel> GetByAdvogadoId(int AdvogadoId);
   public int Create(NewCasoJuridicoInputModel casoJuridico);
}
