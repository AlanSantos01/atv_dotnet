using TechAdv.Application.Services.Interfaces;
using TechAdv.Application.InputModels;
using TechAdv.Application.ViewModels;
using TechAdv.Core.Entities;
using TechAdv.Infrastructure.Persistence;
using TechAdv.Core.Exceptions;

namespace TechAdv.Application.Services;
public class ClienteService : IClienteService
{
    private readonly TechAdvDbContext _context;
    public ClienteService(TechAdvDbContext context)
    {
        _context = context;
    }

    private Cliente GetByDbId(int id)
    {
        var _cliente = _context.Pacientes.Find(id);

        if (_cliente is null)
            throw new ClienteNotFoundException();
        
        return _cliente;
    }

    public int Create(NewClienteInputModel cliente)
    {
        var _cliente = new Cliente
        {
            Nome = cliente.Nome
        };
        _context.Clientes.Add(_cliente);

        _context.SaveChanges();

        return _cliente.ClienteId;
    }

    public void Delete(int id)
    {
        _context.Clientes.Remove(GetByDbId(id));

        _context.SaveChanges();
    }

    public List<ClienteViewModel> GetAll()
    {
        var _clientes = _context.Clientes.Select(m => new ClienteViewModel
        {
            ClienteId = m.ClienteId,
            Nome = m.Nome
        }).ToList();

        return _clientes;
    }

    public ClienteViewModel? GetById(int id)
    {
        var _cliente = GetByDbId(id);

        var ClienteViewModel = new ClienteViewModel
        {
            ClienteId = _cliente.ClienteId,
            Nome = _cliente.Nome
        };
        return ClienteViewModel;
    }

    public void Update(int id, NewPacienteInputModel Advogado)
    {
        var _paciente = GetByDbId(id);

        _paciente.Nome = Advogado.Nome;

        _context.Pacientes.Update(_paciente);

        _context.SaveChanges();
    }
}
