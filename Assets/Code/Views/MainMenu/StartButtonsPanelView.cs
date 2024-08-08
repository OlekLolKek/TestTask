using System;
using UnityEngine;
using UnityEngine.UI;


namespace Code.Views.MainMenu
{
    public sealed class StartButtonsPanelView : BaseView
    {
        [SerializeField] private Button _newSimulationButton;
        [SerializeField] private Button _loadSimulationButton;

        public event Action NewSimulationButtonClick;
        public event Action LoadSimulationButtonClick;
        
        private void OnEnable()
        {
            _newSimulationButton.onClick.AddListener(OnNewSimulationButtonClick);
            _loadSimulationButton.onClick.AddListener(OnLoadSimulationButtonClick);
        }

        private void OnDisable()
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
    }
}