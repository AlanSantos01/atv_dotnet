namespace TechAdv.Core.Exceptions;
public class CasoJuridicoNotFoundException : Exception
{
   public CasoJuridicoNotFoundException() :
      base("Caso não encontrado")
   {
   }
}
