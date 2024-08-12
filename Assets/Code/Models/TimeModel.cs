using System;
using UnityEngine;


namespace Code.Models
{
    /// <summary>
    /// Stores the timescale used to speed up and down the game's pace
    /// </summary>
    public sealed class TimeModel
    {
        #region Events

        /// <summary>
        /// Called when the player changes the timescale value.
        /// </summary>
        public event Action<float> TimeScaleChanged;

        #endregion
        
        
        #region Properties

        public float TimeScale { get; private set; } = STARTING_TIME_SCALE;

        #endregion


        #region Fields

        private const float MIN_TIME_SCALE = 0.0f;
        private const float MAX_TIME_SCALE = 1000.0f;
        
        private const float STARTING_TIME_SCALE = 1.0f;

        #endregion


        #region Methods

        /// <summary>
        /// Used to change the timescale value after the player moves the corresponding slider
        /// </summary>
        /// <param name="value">The new timescale value</param>
        public void SetTimeScale(float value)
        {
            TimeScale = Mathf.Clamp(value, MIN_TIME_SCALE, MAX_TIME_SCALE);
            
            TimeScaleChanged?.Invoke(TimeScale);
        }

        #endregion
    }
}