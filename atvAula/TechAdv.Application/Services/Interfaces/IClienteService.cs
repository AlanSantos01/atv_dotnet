namespace TechAdv.Application.Services.Interfaces;
using TechAdv.Application.InputModels;
using TechAdv.Application.ViewModels;
public interface IClienteService
{
      public List<ClienteViewModel> GetAll();
      public ClienteViewModel? GetById(int id);
      public int Create(NewClienteInputModel cliente);
      public void Update(int id, NewClienteInputModel cliente);
      public void Delete(int id);
}
