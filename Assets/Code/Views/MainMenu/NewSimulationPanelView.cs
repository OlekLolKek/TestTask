using System;
using UnityEngine;
using UnityEngine.UI;


namespace Code.Views.MainMenu
{
    public sealed class NewSimulationPanelView : BaseView
    {
        [SerializeField] private Slider _fieldSizeSlider;
        [SerializeField] private Slider _animalCountSlider;
        [SerializeField] private Slider _animalSpeedSlider;
        [SerializeField] private Button _createButton;
        [SerializeField] private Button _backButton;

        public event Action<int> FieldSizeSliderValueChanged;
        public event Action<int> AnimalCountSliderValueChanged;
        public event Action<int> AnimalSpeedSliderValueChanged;
        public event Action CreateButtonClick;
        public event Action BackButtonClick;

        public void SetAnimalCountSliderMaxValue(int maxValue)
        {
            _animalSpeedSlider.maxValue = maxValue;
        }

        private void OnEnable()
        {
            _fieldSizeSlider.onValueChanged.AddListener(OnFieldSizeSliderValueChanged);
            _animalCountSlider.onValueChanged.AddListener(OnAnimalCountSliderValueChanged);
            _animalSpeedSlider.onValueChanged.AddListener(OnAnimalSpeedSliderValueChanged);
            _createButton.onClick.AddListener(OnCreateButtonClick);
            _backButton.onClick.AddListener(OnBackButtonClick);
        }

        private void OnDisable()
        {
            _fieldSizeSlider.onValueChanged.RemoveListener(OnFieldSizeSliderValueChanged);
            _animalCountSlider.onValueChanged.RemoveListener(OnAnimalCountSliderValueChanged);
            _animalSpeedSlider.onValueChanged.RemoveListener(OnAnimalSpeedSliderValueChanged);
            _createButton.onClick.RemoveListener(OnCreateButtonClick);
            _backButton.onClick.RemoveListener(OnBackButtonClick);
        }

        private void OnFieldSizeSliderValueChanged(float value)
        {
            FieldSizeSliderValueChanged?.Invoke((int)value);
        }

        private void OnAnimalCountSliderValueChanged(float value)
        {
            AnimalCountSliderValueChanged?.Invoke((int)value);
        }

        private void OnAnimalSpeedSliderValueChanged(float value)
        {
            AnimalSpeedSliderValueChanged?.Invoke((int)value);
        }

        private void OnCreateButtonClick()
        {
            CreateButtonClick?.Invoke();
        }

        private void OnBackButtonClick()
        {
            BackButtonClick?.Invoke();
        }
    }
}