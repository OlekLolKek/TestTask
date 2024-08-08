using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


namespace Code.Views.MainMenu
{
    public sealed class NewSimulationPanelView : BaseView
    {
        #region Events

        public event Action<int> FieldSizeSliderValueChanged;
        public event Action<int> AnimalCountSliderValueChanged;
        public event Action<int> AnimalSpeedSliderValueChanged;
        public event Action CreateButtonClick;
        public event Action BackButtonClick;

        #endregion
        
        
        #region Fields

        [Header("Field Size")]
        [SerializeField] private Slider _fieldSizeSlider;
        [SerializeField] private TMP_Text _fieldSizeText;
        
        [Header("Animal Count")]
        [SerializeField] private Slider _animalCountSlider;
        [SerializeField] private TMP_Text _animalCountText;
        
        [Header("Animal Speed")]
        [SerializeField] private Slider _animalSpeedSlider;
        [SerializeField] private TMP_Text _animalSpeedText;
        
        [Header("Buttons")]
        [SerializeField] private Button _createButton;
        [SerializeField] private Button _backButton;

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
            _fieldSizeSlider.onValueChanged.AddListener(OnFieldSizeSliderValueChanged);
            _animalCountSlider.onValueChanged.AddListener(OnAnimalCountSliderValueChanged);
            _animalSpeedSlider.onValueChanged.AddListener(OnAnimalSpeedSliderValueChanged);
            _createButton.onClick.AddListener(OnCreateButtonClick);
            _backButton.onClick.AddListener(OnBackButtonClick);
        }

        private void Unsubscribe()
        {
            _fieldSizeSlider.onValueChanged.RemoveListener(OnFieldSizeSliderValueChanged);
            _animalCountSlider.onValueChanged.RemoveListener(OnAnimalCountSliderValueChanged);
            _animalSpeedSlider.onValueChanged.RemoveListener(OnAnimalSpeedSliderValueChanged);
            _createButton.onClick.RemoveListener(OnCreateButtonClick);
            _backButton.onClick.RemoveListener(OnBackButtonClick);
        }

        public void SetAnimalCountSliderMaxValue(int maxValue)
        {
            _animalCountSlider.maxValue = maxValue;
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

        public void SetFieldSize(int value)
        {
            _fieldSizeSlider.value = value;
            _fieldSizeText.text = value.ToString();
        }

        public void SetAnimalCount(int value)
        {
            _animalCountSlider.value = value;
            _animalCountText.text = value.ToString();
        }

        public void SetAnimalSpeed(int value)
        {
            _animalSpeedSlider.value = value;
            _animalSpeedText.text = value.ToString();
        }

        private void OnCreateButtonClick()
        {
            CreateButtonClick?.Invoke();
        }

        private void OnBackButtonClick()
        {
            BackButtonClick?.Invoke();
        }

        #endregion
    }
}