using TechAdv.Application.Services.Interfaces;
using TechAdv.Application.InputModels;
using TechAdv.Application.ViewModels;
using TechAdv.Infrastructure.Persistence.Interfaces;
using TechAdv.Core.Entities;
using TechAdv.Core.Exceptions;

namespace TechAdv.Application.Services;
public class AdvogadoService : IAdvogadoService
{
    
  private readonly ITechAdvContext _context;
  public AdvogadoService(ITechAdvContext context)
  {
    _context = context;
  }

  public int Create(NewAdvogadoInputModel advogado)
  {
    return _context.AdvogadosCollection.Create(new Advogado
    {
      Nome = advogado.Nome
    });

  }

  public int CreateAtendimento(int advogadoId, NewCasoJuridicoInputModel casoJuridico)
  {
    var advogado = _context.AdvogadosCollection.GetById(advogadoId);
    if (advogado is null)
      throw new AdvogadoNotFoundException();

    var cliente = _context.ClientesCollection.GetById(casoJuridico.ClienteId);
    if (cliente is null)
      throw new ClienteNotFoundException();

    return _context.AtendimentosCollection.Create(new CasoJuridico
    {
      DataHora = casoJuridico.DataHora,
      Advogado = advogado,
      Cliente = cliente
    });
  }

  public void Delete(int id)
  {
    _context.AdvogadosCollection.Delete(id);
  }

  public List<AdvogadoViewModel> GetAll()
  {
    var advogados = _context.AdvogadosCollection.GetAll().Select(m => new AdvogadoViewModel
    {
      AdvogadoId = m.AdvogadoId,
      Nome = m.Nome
    }).ToList();

    return advogados;

  }

  public AdvogadoViewModel? GetByOAB(string oab)
  {
    throw new NotImplementedException();
  }

  public AdvogadoViewModel? GetById(int id)
  {
    var advogado = _context.AdvogadosCollection.GetById(id);

    if (advogado is null)
      return null;

    var AdvogadoViewModel = new AdvogadoViewModel
    {
      AdvogadoId = advogado.AdvogadoId,
      Nome = advogado.Nome
    };
    return AdvogadoViewModel;
  }

  public void Update(int id, NewAdvogadoInputModel advogado)
  {
    _context.AdvogadosCollection.Update(id, new Advogado
    {
      Nome = advogado.Nome
    });
  }
}

