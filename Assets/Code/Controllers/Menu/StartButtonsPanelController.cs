using System;
using Code.Interfaces;
using Code.Views.MainMenu;


namespace Code.Controllers.Menu
{
    public sealed class StartButtonsPanelController : IActivatable
    {
        #region Events

        public event Action NewSimulationButtonClick;
        public event Action LoadSimulationButtonClick;

        #endregion


        #region Properties

        public bool IsActive { get; private set; }

        #endregion
        
        
        #region Fields

        private readonly StartButtonsPanelView _view;

        #endregion


        #region CodeLife

        public StartButtonsPanelController(StartButtonsPanelView view)
        {
            _view = view;
        }

        #endregion


        #region Methods

        public void SetActive(bool active)
        {
            IsActive = active;
            _view.SetActive(IsActive);

            if (IsActive)
            {
                _view.NewSimulationButtonClick += OnNewSimulationButtonClick;
                _view.LoadSimulationButtonClick += OnLoadSimulationButtonClick;
            }
            else
            {
                _view.NewSimulationButtonClick -= OnNewSimulationButtonClick;
                _view.LoadSimulationButtonClick -= OnLoadSimulationButtonClick;
            }
        }

        private void OnNewSimulationButtonClick()
        {
            NewSimulationButtonClick?.Invoke();
        }

        private void OnLoadSimulationButtonClick()
        {
            LoadSimulationButtonClick?.Invoke();
        }

        #endregion
    }
}