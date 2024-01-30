using TechAdv.Application.InputModels;
using TechAdv.Application.Services.Interfaces;
using TechAdv.Application.ViewModels;
using TechAdv.Core.Entities;
using TechAdv.Core.Exceptions;
using TechAdv.Infrastructure.Persistence.Interfaces;

namespace TechAdv.Application.Services;
public class CasoJuridicoService : BaseService, ICasoJuridicoService
{
   private readonly IAdvogadoService _advogadoService;
   private readonly IClienteService _clienteService;
   public CasoJuridicoService(ITechAdvContext context, IAdvogadoService advogadoService, IClienteService clienteService) : base(context)
   {
      _advogadoService = advogadoService;
      _clienteService = clienteService;
   }
   public int Create(NewCasoJuridicoInputModel casoJuridico)
   {
      return _medicoService.CreateAtendimento(atendimento.MedicoId, atendimento);
   }
   public List<CasoJuridicoViewModel> GetAll()
   {
      return _context.AtendimentosCollection.GetAll().Select(a => new CasoJuridicoViewModel
      {
         AtendimentoId = a.AtendimentoId,
         DataHora = a.DataHora,
         Medico = new MedicoViewModel
         {
            MedicoId = a.Medico.MedicoId,
            Nome = a.Medico.Nome
         },
         Paciente = new PacienteViewModel
         {
            PacienteId = a.Paciente.PacienteId,
            Nome = a.Paciente.Nome
         }
      }).ToList();
   }

   public CasoJuridicoViewModel? GetById(int id)
   {
      var casoJuridicoDB = _context.CasosJuridicosCollection.GetById(id);
      if (CasoJuridicoDB is null)
         throw new CasoJuridicoNotFoundException();
      
      var advogadoVM = _advogadoService.GetById(CasoJuridicoDB.Advogado.AdvogadoId);
      var clienteVM = _clienteService.GetById(casoJuridicoDB.Cliente.ClienteId);
      
      if (AdvogadoVM is null || clienteVM is null)
         return null;

      return new CasoJuridicoViewModel{
         CasoJuridicoId = casoJuridicoDB.CasoJuridicoId,
         DataHora = CasoJuridicoDB.DataHora,
         Advogado = advogadoVM,
         Cliente = clienteVM
      };
      
   }
    public List<CasoJuridicoViewModel> GetByAdvogadoId(int advogadoId)
    {
        throw new NotImplementedException();
    }

    public List<CasoJuridicoViewModel> GetByClienteId(int clienteId)
    {
        throw new NotImplementedException();
    }
}
