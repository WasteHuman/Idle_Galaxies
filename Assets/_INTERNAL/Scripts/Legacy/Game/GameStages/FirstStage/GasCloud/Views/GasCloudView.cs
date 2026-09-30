using EventBus;
using Game.GameStages.FirstStage.BaseMVC;
using Game.GameStages.FirstStage.GasCloud;
using Game.Shop.UpgradesBaseMVC.Interfaces;
using System.Collections.Generic;
using TMPro;
using UI;
using UnityEngine;

namespace Game.GameStages.FirstStage.Views
{
    public class GasCloudView : GameStageViewBase
    {
        [Header("Cloud particles")]
        [SerializeField] private List<ParticleSystem> _clouds = new();

        [Space(15), Header("Gas cloud UI information")]
        [SerializeField] private TextMeshProUGUI _massTextUIPrefab;
        [SerializeField] private TextMeshProUGUI _pressureTextUIPrefab;

        [SerializeField] private TextMeshProUGUI _massTextUI;
        private TextMeshProUGUI _pressureTextUI;
        private StatsUI _statsUI;

        private CalculationGasCloudView _cloudViewCalculator;

        private void OnEnable()
        {
            EventBus<bool>.Subscribe(GameEventEnum.GasCloudCreated, Initialize);
        }

        private void OnDestroy()
        {
            EventBus<bool>.Unsubscribe(GameEventEnum.GasCloudCreated, Initialize);
        }

        public override void OnGameStageStarted()
        {
            foreach (ParticleSystem cloud in _clouds)
            {
                cloud.Play();
            }
        }

        public override void UpdateUI(List<string> stats)
        {
            _massTextUI.text = stats[0];
            _pressureTextUI.text = stats[1];
        }

        public override void OnPresureUpgradeApplied(IUpgradeModel model)
        {
            _cloudViewCalculator.CalculatePressureRates(model);
            _cloudViewCalculator.CalculateCloudPressure();
        }

        public override void OnMassUpgradeApplied(IUpgradeModel model)
        {
            _cloudViewCalculator.CalculateMassRates(model);
            _cloudViewCalculator.CalculateCloudMass();
        }

        public void Initialize(bool isCreated)
        {
            if (!isCreated)
                return;

            OnGameStageStarted();

            _statsUI = FindObjectOfType<StatsUI>();

            CreateUI();
        }

        public void CreateCalculator(CalculationGasCloudView calculator)
        {
            _cloudViewCalculator = calculator;
        }

        public void CreateUI()
        {
            _massTextUI = Instantiate(_massTextUIPrefab, _statsUI.transform);
            _pressureTextUI = Instantiate(_pressureTextUIPrefab, _statsUI.transform);
        }

        public void UpdateGravitationVisual()
        {
            var shape = _clouds[2].shape;

            _cloudViewCalculator.UpdateCloudGravitation(shape);
        }

        public void UpdateMassVisual()
        {
            var main = _clouds[2].main;

            if (_clouds[2].isPlaying)
                _clouds[2].Stop(true, ParticleSystemStopBehavior.StopEmitting);

            _cloudViewCalculator.UpdateCloudVisual(main);
            _clouds[2].Play();
        }
    }
}