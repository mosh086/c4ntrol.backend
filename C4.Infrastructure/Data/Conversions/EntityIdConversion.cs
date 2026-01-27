using C4.Domain.Common;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace C4.Infrastructure.Data.Conversions;

public class EntityIdConversion : ValueConverter<EntityId, Guid>
{
    public EntityIdConversion() : base(c => c.Value, c => EntityId.FromGuid(c))
    {

    }
}