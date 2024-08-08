using Code.Data;
using Code.Views.MainMenu;
using UnityEngine;


namespace Code.Controllers.Menu
{
    public sealed class MainMenuController : MonoBehaviour
    {
        [SerializeField] private GameConfig _config;
        [SerializeField] private MainMenuView _mainMenu;

        private NewSimulationPanelController _newSimulationPanelController;

        private void Start()
        {
            _newSimulationPanelController = new NewSimulationPanelController(_mainMenu.NewSimulationPanel, _config);
        }

        private void OnDestroy()
        {
            _newSimulationPanelController.Dispose();
        }
    }
}