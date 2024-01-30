using TechAdv.Application.Services.Interfaces;
using TechAdv.Infrastructure.Persistence.Interfaces;

namespace TechAdv.Application.Services;
public abstract class BaseService
{
   protected readonly ITechAdvContext _context;
   protected BaseService(ITechAdvContext context){
      _context = context;
   }
}
