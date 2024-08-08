using System;
using Code.Data;
using Code.Interfaces;
using Code.Views.MainMenu;


namespace Code.Controllers.Menu
{
    public sealed class NewSimulationPanelController : IActivatable
    {
        #region Events

        public event Action BackButtonClick;

        #endregion


        #region Properties

        public bool IsActive { get; private set; }

        #endregion
        
        
        #region Fields

        private readonly NewSimulationPanelView _view;
        private readonly GameConfig _config;

        #endregion
        

        #region CodeLife

        public NewSimulationPanelController(NewSimulationPanelView view, GameConfig config)
        {
            _view = view;
            _config = config;
        }

        #endregion


        #region Methods

        private void Subscribe()
        {
            _view.FieldSizeSliderValueChanged += OnFieldSizeSliderValueChanged;
            _view.AnimalCountSliderValueChanged += OnAnimalCountSliderValueChanged;
            _view.AnimalSpeedSliderValueChanged += OnAnimalSpeedSliderValueChanged;

            _view.BackButtonClick += OnBackButtonClick;
        }

        private void Unsubscribe()
        {
            _view.FieldSizeSliderValueChanged -= OnFieldSizeSliderValueChanged;
            _view.AnimalCountSliderValueChanged -= OnAnimalCountSliderValueChanged;
            _view.AnimalSpeedSliderValueChanged -= OnAnimalSpeedSliderValueChanged;
            
            _view.BackButtonClick -= OnBackButtonClick;
        }

        public void SetActive(bool active)
        {
            IsActive = active;
            _view.SetActive(IsActive);

            if (IsActive)
            {
                Subscribe();
                
                _view.SetFieldSize(_config.FieldSize);
                _view.SetAnimalCount(_config.AnimalCount);
                _view.SetAnimalSpeed(_config.AnimalSpeed);
            }
            else
            {
                Unsubscribe();
            }
        }

        private void OnFieldSizeSliderValueChanged(int value)
        {
            _config.SetFieldSize(value);
            _view.SetFieldSize(value);
            _view.SetAnimalCountSliderMaxValue(_config.GetMaxAnimalCount());
        }

        private void OnAnimalCountSliderValueChanged(int value)
        {
            _config.SetAnimalCount(value);
            _view.SetAnimalCount(value);
        }

        private void OnAnimalSpeedSliderValueChanged(int value)
        {
            _config.SetAnimalSpeed(value);
            _view.SetAnimalSpeed(value);
        }

        private void OnBackButtonClick()
        {
            BackButtonClick?.Invoke();
        }

        #endregion
    }
}