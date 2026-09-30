using Game.GameStages.FirstStage.BaseMVC;
using Game.Shop.UpgradesBaseMVC.Interfaces;
using OtherUtils;
using System;
using TMPro;
using UI;
using UnityEngine;
using UnityEngine.UI;

namespace Game.GameStages.AllStages.Views
{
    public class GravitationUpgradeView : ViewUIBase, IUpgradeView
    {
        [Header("Upgrade Information")]
        [SerializeField] private TextMeshProUGUI _upgradeCost;
        [SerializeField] private TextMeshProUGUI _level;

        [Space(15)]
        [SerializeField] private Button _upgradeButton;

        private IUpgradeController _controller;

        public event Action OnUpgradeButtonClicked;

        private void OnEnable()
        {
            _upgradeButton.onClick.AddListener(OnButtonClicked);
        }

        private void OnDisable()
        {
            _upgradeButton.onClick.RemoveListener(OnButtonClicked);
        }

        private void OnButtonClicked()
        {
            OnUpgradeButtonClicked?.Invoke();
        }

        public void SetController(IUpgradeController upgradeController)
        {
            _controller = upgradeController;
        }

        public void UpdateUI(int level, float cost)
        {
            _level.text = $"Уровень: {level}";
            _upgradeCost.text = $"Цена: {NumberUtils.FormatNumber(cost)}";
        }

        public bool SetButtonState(IStageModel model)
        {
            if (model.Mass < model.CriticalMass * 0.2f)
            {
                return _upgradeButton.interactable = false;
            }

            return _upgradeButton.interactable = true;
        }
    }
}