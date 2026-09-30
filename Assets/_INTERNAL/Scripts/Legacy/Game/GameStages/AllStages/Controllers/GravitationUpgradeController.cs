using EventBus;
using Game.GameStages.FirstStage.BaseMVC;
using Game.GameStages.FirstStage.Models;
using Game.Resource.Models;
using Game.GameStages.AllStages.Models;
using Game.Shop.UpgradesBaseMVC.Interfaces;
using Game.GameStages.AllStages.Views;
using Game.Resource.BaseMVC;

namespace Game.GameStages.AllStages.Controllers
{
    public class GravitationUpgradeController : IUpgradeController
    {
        private readonly MatterResourceModel _resourceModel;
        private readonly GravitationUpgradeModel _upgradeModel;

        private readonly MassUpgradeModel _massUpgradeModel;
        private readonly GravitationUpgradeView _upgradeView;
        private readonly IStageController _gameStageController;

        public GravitationUpgradeController(
            IResourceModel resourceModel,
            IUpgradeModel graviUpgradeModel,
            IUpgradeModel massUpgradeModel,
            IUpgradeView upgradeView,
            IStageController gameStageController)
        {
            _resourceModel = (MatterResourceModel)resourceModel;
            _upgradeModel = (GravitationUpgradeModel)graviUpgradeModel;
            _massUpgradeModel = (MassUpgradeModel)massUpgradeModel;
            _upgradeView = (GravitationUpgradeView)upgradeView;
            _gameStageController = gameStageController;

            _upgradeView.SetController(this);
            ShowUpgradeDetails();

            _upgradeView.OnUpgradeButtonClicked += OnUpgradeButtonClicked;
            EventBus<GasCloudModel>.Subscribe(GameEventEnum.UpgradePurchased, (model) => _upgradeView.SetButtonState(model));
        }

        public void ApplyUpgrade()
        {
            if (_resourceModel.CurrentResourceAmount >= _upgradeModel.CurrentCost)
            {
                //Списываем ресурсы
                _resourceModel.SpendResource(_upgradeModel.CurrentCost);

                _upgradeModel.CheckDependentLevel(_massUpgradeModel);

                //Применяем улучшение к грави-полю
                _gameStageController.ApplyGravityUpgrade();
                _gameStageController.UpdateGravitationView(_upgradeModel);
                _gameStageController.ShowUpgradeDetails();
            }
        }

        public void ShowUpgradeDetails()
        {
            _upgradeView.UpdateUI(_upgradeModel.Level, _upgradeModel.CurrentCost);
        }

        public void OnUpgradeButtonClicked()
        {
            ApplyUpgrade();
            ShowUpgradeDetails();
        }
    }
}