using Code.Interfaces.MonoBehaviourCycle;
using Code.Models;
using Code.Views.Game;
using UnityEngine;


namespace Code.Controllers.Game
{
    public sealed class TimeController : ICleanable
    {
        #region Fields

        private readonly TimeControlView _view;
        private readonly TimeModel _timeModel;
        #endregion
        
        
        #region CodeLife

        public TimeController(TimeControlView view, TimeModel timeModel)
        {
            _view = view;
            _timeModel = timeModel;

            _view.TimeSpeedSliderValueChanged += OnTimeSpeedSliderValueChanged;
        }

        public void Cleanup()
        {
            _view.TimeSpeedSliderValueChanged -= OnTimeSpeedSliderValueChanged;
        }

        #endregion


        #region Methods

        private void OnTimeSpeedSliderValueChanged(float value)
        {
            _timeModel.SetTimeScale(value);
            _view.SetTimeSpeedText(value);
        }

        #endregion
    }
}