using System;
using System.Collections.Generic;
using Content.CodeBase.Components;

namespace Content.CodeBase.Infrastructure.Services
{
    public interface IUnitDataService : IStaticDataService
    {
        Dictionary<Enum, Unit> GetDataUnits<T>();
    }
}