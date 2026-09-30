using Game.GameStages.FirstStage.BaseMVC;
using Game.GameStages.FirstStage.Models;
using Game.GameStages.FirstStage.Views;
using Game.Shop.UpgradesBaseMVC.Interfaces;
using OtherUtils;
using System.Collections.Generic;

namespace Game.GameStages.FirstStage.GasCloud.Controllers
{
    public class GasCloudController : IStageController
    {
        private readonly GasCloudView _view;
        private readonly GameStageModelBase _model;

        private List<string> _cloudStats;

        public GasCloudController(GasCloudModel gasCloudModel, GasCloudView view)
        {
            _model = gasCloudModel;
            _view = view;

            InitializeMessages(gasCloudModel);
        }

        private void InitializeMessages(GasCloudModel model)
        {
            _cloudStats = new()
            {
                $"Масса: {NumberUtils.FormatNumber(model.Mass)} Мс / {model.CriticalMass}",
                $"Давление: {NumberUtils.FormatNumber(model.Pressure)} Ед / {model.CriticalPressure}"
            };
        }

        private void UpdateMasseges()
        {
            _cloudStats[0] = $"Масса: {NumberUtils.FormatNumber(_model.Mass)} Мс / {_model.CriticalMass}";
            _cloudStats[1] = $"Давление: {NumberUtils.FormatNumber(_model.Pressure)} Ед / {_model.CriticalPressure}";
        }

        public void ApplyMassUpgrade()
        {
            _model.TryMassUpgrade();
        }

        public void ApplyGravityUpgrade()
        {
            _model.TryGraviUpgrade();
        }

        public void ShowUpgradeDetails()
        {
            UpdateMasseges();
            _view.UpdateUI(_cloudStats);
        }

        public void UpdateGravitationView(IUpgradeModel model)
        {
            _view.OnPresureUpgradeApplied(model);
            _view.UpdateGravitationVisual();
        }

        public void UpdateMassView(IUpgradeModel model)
        {
            _view.OnMassUpgradeApplied(model);
            _view.UpdateMassVisual();
        }

        public GameStageModelBase GetModel()
        {
            return _model;
        }
    }
}