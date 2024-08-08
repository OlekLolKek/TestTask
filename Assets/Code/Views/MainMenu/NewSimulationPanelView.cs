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

        public event Action<float> FieldSizeSliderValueChanged;
        public event Action<float> AnimalCountSliderValueChanged;
        public event Action<float> AnimalSpeedSliderValueChanged;
        public event Action CreateButtonClick;

        private void OnEnable()
        {
            _fieldSizeSlider.onValueChanged.AddListener(OnFieldSizeSliderValueChanged);
            _animalCountSlider.onValueChanged.AddListener(OnAnimalCountSliderValueChanged);
            _animalSpeedSlider.onValueChanged.AddListener(OnAnimalSpeedSliderValueChanged);
            _createButton.onClick.AddListener(OnCreateButtonClick);
        }

        private void OnDisable()
        {
            _fieldSizeSlider.onValueChanged.RemoveListener(OnFieldSizeSliderValueChanged);
            _animalCountSlider.onValueChanged.RemoveListener(OnAnimalCountSliderValueChanged);
            _animalSpeedSlider.onValueChanged.RemoveListener(OnAnimalSpeedSliderValueChanged);
            _createButton.onClick.RemoveListener(OnCreateButtonClick);
        }

        private void OnFieldSizeSliderValueChanged(float value)
        {
            FieldSizeSliderValueChanged?.Invoke(value);
        }

        private void OnAnimalCountSliderValueChanged(float value)
        {
            AnimalCountSliderValueChanged?.Invoke(value);
        }

        private void OnAnimalSpeedSliderValueChanged(float value)
        {
            AnimalSpeedSliderValueChanged?.Invoke(value);
        }

        private void OnCreateButtonClick()
        {
            CreateButtonClick?.Invoke();
        }
    }
}