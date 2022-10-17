using System;
using Content.CodeBase.Components;
using UnityEngine;

namespace Content.CodeBase.Data
{
    [CreateAssetMenu(fileName = "EnemyData", menuName = "StaticData/EnemyData")]
    public class EnemyData : ScriptableObject, IUnitStaticData
    {
        [SerializeField] private EnemyType _type;
        [SerializeField] private Enemy _enemy;

        public Enum Type => _type;
        public Unit Unit => _enemy;
    }
}

