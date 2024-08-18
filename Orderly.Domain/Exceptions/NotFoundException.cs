using System.Security.AccessControl;

namespace Orderly.Domain.Exceptions;

public class NotFoundException(string entityType, string entityId) 
    : Exception($"{entityType} with id {entityId} does not exist.")
{

}
