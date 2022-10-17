using System;
using Content.CodeBase.Components;
using UnityEngine;

namespace Content.CodeBase.Data
{
    [CreateAssetMenu(fileName = "PlayerData", menuName = "StaticData/PlayerData")]
    public class PlayerData : ScriptableObject, IUnitStaticData
    {
        [SerializeField] private PlayerType _type;
        [SerializeField] private Player _enemy;

        public Enum Type => _type;
        public Unit Unit => _enemy;
    }
}