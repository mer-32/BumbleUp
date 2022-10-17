using System;
using Content.CodeBase.Components;

namespace Content.CodeBase.Data
{
    public interface IUnitStaticData
    {
        Enum Type { get; }
        Unit Unit { get; }
    }
}