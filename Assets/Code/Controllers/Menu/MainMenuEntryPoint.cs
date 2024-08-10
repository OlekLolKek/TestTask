using System.Collections.Generic;
using Code.Data;
using Code.Interfaces;
using Code.Models;
using Code.Views.MainMenu;
using UnityEngine;


namespace Code.Controllers.Menu
{
    public sealed class MainMenuEntryPoint : MonoBehaviour
    {
        #region Fields

        [SerializeField] private GameConfig _config;
        [SerializeField] private MainMenuView _view;
        
        private readonly List<IActivatable> _panelControllers = new();
        
        private readonly Controllers _controllers = new();
        
        private NewSimulationPanelController _newSimulationPanelController;
        private StartButtonsPanelController _startButtonsPanelController;
        private SceneController _sceneController;

        #endregion


        #region Mono
        
        private void Start()
        {
            var sceneChangeModel = new SceneChangeModel(_config.SceneConfig);
            
            _newSimulationPanelController = new NewSimulationPanelController(_view.NewSimulationPanel, _config, sceneChangeModel);
            _startButtonsPanelController = new StartButtonsPanelController(_view.StartButtonsPanel);
            _sceneController = new SceneController(sceneChangeModel);

            _newSimulationPanelController.BackButtonClick += SwitchToButtonsPanel;
            _startButtonsPanelController.NewSimulationButtonClick += SwitchToNewSimulationPanel;
            
            _panelControllers.Add(_newSimulationPanelController);
            _panelControllers.Add(_startButtonsPanelController);
            
            _controllers.AddController(_newSimulationPanelController);
            _controllers.AddController(_startButtonsPanelController);
            
            SwitchToPanel(_startButtonsPanelController);
        }

        private void OnDestroy()
        {
            _newSimulationPanelController.BackButtonClick -= SwitchToButtonsPanel;
            _startButtonsPanelController.NewSimulationButtonClick -= SwitchToNewSimulationPanel;
            
            _controllers.Cleanup();
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