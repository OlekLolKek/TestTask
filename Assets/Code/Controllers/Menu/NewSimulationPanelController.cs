using System;
using Code.Data;
using Code.Views.MainMenu;


namespace Code.Controllers.Menu
{
    public sealed class NewSimulationPanelController : IDisposable
    {
        private readonly NewSimulationPanelView _view;
        private readonly GameConfig _config;

        public NewSimulationPanelController(NewSimulationPanelView view, GameConfig config)
        {
            _view = view;
            _config = config;

            _view.FieldSizeSliderValueChanged += OnFieldSizeSliderValueChanged;
            _view.AnimalCountSliderValueChanged += OnAnimalCountSliderValueChanged;
            _view.AnimalSpeedSliderValueChanged += OnAnimalSpeedSliderValueChanged;
        }

        private void OnFieldSizeSliderValueChanged(int value)
        {
            _config.SetFieldSize(value);
            _view.SetAnimalCountSliderMaxValue(_config.GetMaxAnimalCount());
        }

        private void OnAnimalCountSliderValueChanged(int value)
        {
            _config.SetAnimalCount(value);
        }

        private void OnAnimalSpeedSliderValueChanged(int value)
        {
            _config.SetAnimalSpeed(value);
        }


        public void Dispose()
        {
            _view.FieldSizeSliderValueChanged -= OnFieldSizeSliderValueChanged;
            _view.AnimalCountSliderValueChanged -= OnAnimalCountSliderValueChanged;
            _view.AnimalSpeedSliderValueChanged -= OnAnimalSpeedSliderValueChanged;
        }
    }
}