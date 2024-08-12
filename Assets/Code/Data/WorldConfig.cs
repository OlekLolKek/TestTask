using System;
using Code.Views.Game;
using UnityEngine;


namespace Code.Data
{
    [Serializable]
    public sealed class WorldConfig
    {
        [field: SerializeField] public int FieldSize { get; private set; }
        [field: SerializeField] public WorldView WorldPrefab { get; private set; }
        [field: SerializeField] public Vector3 WorldSpawnPosition { get; private set; } = Vector3.zero;

        public void SetFieldSize(int fieldSize)
        {
            FieldSize = fieldSize;
        }
    }
}