using TechAdv.Application.InputModels;
using TechAdv.Application.Services.Interfaces;
using TechAdv.Application.ViewModels;
using TechAdv.Core.Entities;
using TechAdv.Infrastructure.Persistence.Interfaces;

namespace TechAdv.Application.Services;
public class DocumentoService : BaseService, IDocumentoService
{
   private readonly IDocumentoService _documentoService;
   public DocumentoService(ITechAdvContext context, IDocumentoService documentoService) : base(context)
   {
      _documentoService = documentoService;
   }

   public int Create(NewDocumentoInputModel documento)
   {
      return _context.DocumentosCollection.Create(new Documento
      {
         Nome = documento.Nome,
         DataHora = documento.DataHora,
         DocumentoId = documento.DocumentoId
      });
   }

   public List<DocumentoViewModel> GetAll()
   {

      return _context.DocumentosCollection.GetAll().Select(m => new DocumentoViewModel
      {
         DocumentoId = m.DocumentoId,
         Nome = m.Nome,
         DataHora = m.DataHora,
         Documento = _documentoService.GetById(m.DocumentoId)
      }).ToList();
   }
}
