using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


namespace Code.Views.MainMenu
{
    /// <summary>
    /// Stores the components of the New Simulation window.
    /// </summary>
    public sealed class NewSimulationPanelView : ActivatableView
    {
        #region Events
        
        public event Action<int> FieldSizeSliderValueChanged;
        public event Action<int> AnimalCountSliderValueChanged;
        public event Action<float> AnimalSpeedSliderValueChanged;
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

        /// <summary>
        /// Changes the animal count slider's max value to restrict the animal count the user can choose.
        /// </summary>
        /// <param name="maxValue">The new maxValue for the slider</param>
        public void SetAnimalCountSliderMaxValue(int maxValue)
        {
            _animalCountSlider.maxValue = maxValue;
        }

        /// <summary>
        /// Changes the corresponding slider's and text's values to the specified number.
        /// </summary>
        /// <param name="value">The updated field size value.</param>
        public void SetFieldSize(int value)
        {
            _fieldSizeSlider.value = value;
            _fieldSizeText.text = value.ToString();
        }

        /// <summary>
        /// Changes the corresponding slider's and text's values to the specified number.
        /// </summary>
        /// <param name="value">The updated animal count value.</param>
        public void SetAnimalCount(int value)
        {
            _animalCountSlider.value = value;
            _animalCountText.text = value.ToString();
        }

        /// <summary>
        /// Changes the corresponding slider's and text's values to the specified number.
        /// </summary>
        /// <param name="value">The updated animal speed value.</param>
        public void SetAnimalSpeed(float value)
        {
            _animalSpeedSlider.value = value;
            _animalSpeedText.text = value.ToString();
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
            AnimalSpeedSliderValueChanged?.Invoke(value);
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