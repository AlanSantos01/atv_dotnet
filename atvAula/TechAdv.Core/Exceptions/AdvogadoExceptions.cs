namespace TechAdv.Core.Exceptions;
public class AdvogadoAlreadyExistsException : Exception
{
   public AdvogadoAlreadyExistsException() :
      base("Já existe um advogado com esses dados.")
   {
   }
}

public class AdvogadoNotFoundException : Exception
{
   public AdvogadoNotFoundException() :
      base("Advogado não encontrado.")
   {
   }
}
