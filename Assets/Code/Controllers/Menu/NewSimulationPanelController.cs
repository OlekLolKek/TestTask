using System;
using Code.Data;
using Code.Interfaces;
using Code.Interfaces.MonoBehaviourCycle;
using Code.Models;
using Code.Views.MainMenu;


namespace Code.Controllers.Menu
{
    public sealed class NewSimulationPanelController : IActivatable, ICleanable
    {
        #region Events

        public event Action BackButtonClick;

        #endregion


        #region Properties

        public bool IsActive { get; private set; }

        #endregion
        
        
        #region Fields

        private readonly NewSimulationPanelView _view;
        private readonly SceneChangeModel _sceneChangeModel;
        private readonly GameConfig _config;

        #endregion
        

        #region CodeLife

        public NewSimulationPanelController(NewSimulationPanelView view, GameConfig config,
            SceneChangeModel sceneChangeModel)
        {
            _view = view;
            _config = config;
            _sceneChangeModel = sceneChangeModel;
        }

        public void Cleanup()
        {
            if (IsActive)
            {
                SubscribeToView(false);
            }
        }

        #endregion


        #region Methods

        private void SubscribeToView(bool subscribe)
        {
            if (subscribe)
            {
                _view.FieldSizeSliderValueChanged += OnFieldSizeSliderValueChanged;
                _view.AnimalCountSliderValueChanged += OnAnimalCountSliderValueChanged;
                _view.AnimalSpeedSliderValueChanged += OnAnimalSpeedSliderValueChanged;

                _view.BackButtonClick += OnBackButtonClick;
                _view.CreateButtonClick += OnCreateButtonClick;
            }
            else
            {
                _view.FieldSizeSliderValueChanged -= OnFieldSizeSliderValueChanged;
                _view.AnimalCountSliderValueChanged -= OnAnimalCountSliderValueChanged;
                _view.AnimalSpeedSliderValueChanged -= OnAnimalSpeedSliderValueChanged;
            
                _view.BackButtonClick -= OnBackButtonClick;
                _view.CreateButtonClick -= OnCreateButtonClick;
            }
            
        }

        public void SetActive(bool active)
        {
            IsActive = active;
            _view.SetActive(IsActive);
            
            SubscribeToView(IsActive);

            if (IsActive)
            {
                _view.SetFieldSize(_config.WorldConfig.FieldSize);
                _view.SetAnimalCount(_config.AnimalConfig.AnimalCount);
                _view.SetAnimalSpeed(_config.AnimalConfig.AnimalSpeed);
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

        private void OnAnimalSpeedSliderValueChanged(float value)
        {
            _config.SetAnimalSpeed(value);
            _view.SetAnimalSpeed(value);
        }

        private void OnBackButtonClick()
        {
            BackButtonClick?.Invoke();
        }

        private void OnCreateButtonClick()
        {
            _sceneChangeModel.RequestSceneChangeToGame();
        }

        #endregion
    }
}