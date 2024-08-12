using System;
using UnityEngine;


namespace Code.Models
{
    public sealed class TimeModel
    {
        #region Events

        public event Action<float> TimeScaleChanged;

        #endregion
        
        
        #region Properties

        public float TimeScale { get; private set; }

        #endregion


        #region Fields

        private const float MIN_TIME_SCALE = 0.0f;
        private const float MAX_TIME_SCALE = 1000.0f;

        #endregion


        #region Methods

        public void SetTimeScale(float value)
        {
            TimeScale = Mathf.Clamp(value, MIN_TIME_SCALE, MAX_TIME_SCALE);
            
            TimeScaleChanged?.Invoke(TimeScale);
        }

        #endregion
    }
}