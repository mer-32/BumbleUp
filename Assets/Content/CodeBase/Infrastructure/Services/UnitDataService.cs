using System;
using System.Collections.Generic;
using System.Linq;
using Content.CodeBase.Components;
using Content.CodeBase.Data;
using Content.CodeBase.Infrastructure.Assets;
using UnityEngine;

namespace Content.CodeBase.Infrastructure.Services
{
    public class UnitDataService : IUnitDataService
    {
        private readonly Dictionary<Type,Dictionary<Enum,Unit>> _unitsData = new Dictionary<Type, Dictionary<Enum, Unit>>();

        public void Load()
        {
            var enemiesData = Resources.LoadAll<EnemyData>(AssetPath.ENEMIES)
                .ToDictionary(x => x.Type, x => x.Unit);

            var playersData = Resources.LoadAll<PlayerData>(AssetPath.PLAYERS).
                ToDictionary(x => x.Type, x => x.Unit);

            _unitsData.Add(typeof(EnemyData), enemiesData);
            _unitsData.Add(typeof(PlayerData), playersData);
        }
        
        public Dictionary<Enum, Unit> GetDataUnits<T>()
        {
            return _unitsData.TryGetValue(typeof(T), out var data) ? data : null;
        }
    }
}