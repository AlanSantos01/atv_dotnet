using TechAdv.Application.InputModels;
using TechAdv.Application.ViewModels;

namespace TechAdv.Application.Services.Interfaces;
public interface IDocumentoService
{
   public List<DocumentoViewModel> GetAll();
   public int Create(NewDocumentoInputModel documento);
}
