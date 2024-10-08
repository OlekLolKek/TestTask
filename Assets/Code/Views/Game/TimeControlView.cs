﻿using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


namespace Code.Views.Game
{
    public sealed class TimeControlView : MonoBehaviour
    {
        #region Events

        public event Action<float> TimeSpeedSliderValueChanged;

        #endregion
        
        
        #region Fields

        [SerializeField] private TMP_Text _timeSpeedText;
        [SerializeField] private Slider _timeSpeedSlider;

        #endregion


        #region Mono

        private void OnEnable()
        {
            _timeSpeedSlider.onValueChanged.AddListener(OnTimeSpeedSliderValueChanged);
        }

        private void OnTimeSpeedSliderValueChanged(float value)
        {
            TimeSpeedSliderValueChanged?.Invoke(value);
        }

        private void OnDisable()
        {
            _timeSpeedSlider.onValueChanged.RemoveListener(OnTimeSpeedSliderValueChanged);
        }

        #endregion


        #region Methods

        /// <summary>
        /// Used to update the timescale text when the slider is moved.
        /// </summary>
        /// <param name="timeScale"></param>
        public void SetTimeSpeedText(float timeScale)
        {
            _timeSpeedText.text = timeScale.ToString();
        }

        #endregion
    }
}