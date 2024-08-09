using System;
using UnityEngine;


namespace Code.Data
{
    /// <summary>
    /// Config that stores the Scenes' indexes
    /// </summary>
    [Serializable]
    public sealed class SceneConfig
    {
        [field: SerializeField] public int MainMenuSceneIndex { get; private set; } = 0;
        [field: SerializeField] public int GameSceneIndex { get; private set; } = 1;
    }
}