using System;
using UnityEngine;
using UnityEngine.UI;


namespace Code.Views.MainMenu
{
    public sealed class StartButtonsPanelView : BaseView
    {
        #region Events

        public event Action NewSimulationButtonClick;
        public event Action LoadSimulationButtonClick;

        #endregion
        
        
        #region Fields

        [SerializeField] private Button _newSimulationButton;
        [SerializeField] private Button _loadSimulationButton;

        #endregion


        #region Mono

        private void OnEnable()
        {
            Subscribe();
        }

        private void OnDisable()
        {
            Unsubscribe();
        }

        #endregion


        #region Methods

        private void Subscribe()
        {
            _newSimulationButton.onClick.AddListener(OnNewSimulationButtonClick);
            _loadSimulationButton.onClick.AddListener(OnLoadSimulationButtonClick);
        }

        private void Unsubscribe()
        {
            _newSimulationButton.onClick.RemoveListener(OnNewSimulationButtonClick);
            _loadSimulationButton.onClick.RemoveListener(OnLoadSimulationButtonClick);
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