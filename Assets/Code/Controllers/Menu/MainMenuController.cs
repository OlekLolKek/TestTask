using System.Collections.Generic;
using Code.Data;
using Code.Interfaces;
using Code.Views.MainMenu;
using UnityEngine;


namespace Code.Controllers.Menu
{
    public sealed class MainMenuController : MonoBehaviour
    {
        #region Fields

        [SerializeField] private GameConfig _config;
        [SerializeField] private MainMenuView _view;

        private readonly List<IActivatable> _panelControllers = new();
        
        private NewSimulationPanelController _newSimulationPanelController;
        private StartButtonsPanelController _startButtonsPanelController;

        #endregion


        #region Mono
        
        private void Start()
        {
            _newSimulationPanelController = new NewSimulationPanelController(_view.NewSimulationPanel, _config);
            _startButtonsPanelController = new StartButtonsPanelController(_view.StartButtonsPanel);

            _newSimulationPanelController.BackButtonClick += SwitchToButtonsPanel;
            _startButtonsPanelController.NewSimulationButtonClick += SwitchToNewSimulationPanel;
            
            _panelControllers.Add(_newSimulationPanelController);
            _panelControllers.Add(_startButtonsPanelController);
            
            SwitchToPanel(_startButtonsPanelController);
        }

        private void OnDestroy()
        {
            _newSimulationPanelController.BackButtonClick -= SwitchToButtonsPanel;
            
            _startButtonsPanelController.NewSimulationButtonClick -= SwitchToNewSimulationPanel;
            
            foreach (var panelController in _panelControllers)
            {
                if (panelController.IsActive)
                    panelController.SetActive(false);
            }
        }

        #endregion


        #region Methods

        private void SwitchToButtonsPanel()
        {
            SwitchToPanel(_startButtonsPanelController);
        }

        private void SwitchToNewSimulationPanel()
        {
            SwitchToPanel(_newSimulationPanelController);
        }

        private void SwitchToPanel(IActivatable activePanel)
        {
            foreach (var panel in _panelControllers)
            {
                if (panel != activePanel)
                {
                    panel.SetActive(false);
                }
            }
            
            activePanel.SetActive(true);
        }

        #endregion
    }
}