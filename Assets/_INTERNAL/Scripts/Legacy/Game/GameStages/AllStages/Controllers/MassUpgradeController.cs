using EventBus;
using Game.GameStages.FirstStage.BaseMVC;
using Game.GameStages.FirstStage.GasCloud.Controllers;
using Game.GameStages.FirstStage.Models;
using Game.Resource.BaseMVC;
using Game.Shop.UpgradesBaseMVC.Interfaces;

namespace Game.GameStages.AllStages.Controllers
{
    public class MassUpgradeContoller : IUpgradeController
    {
        private readonly IResourceModel _resourceModel;
        private readonly IUpgradeModel _upgradeModel;
        private readonly IUpgradeView _upgradeView;
        private readonly GasCloudController _gameStageController;

        public MassUpgradeContoller
            (IResourceModel resourceModel,
            IUpgradeModel upgradeModel,
            IUpgradeView upgradeView,
            IStageController gameStageController)
        {
            _resourceModel = resourceModel;
            _upgradeModel = upgradeModel;
            _upgradeView = upgradeView;
            _gameStageController = (GasCloudController)gameStageController;

            _upgradeView.SetController(this);
            ShowUpgradeDetails();

            _upgradeView.OnUpgradeButtonClicked += OnUpgradeButtonClicked;
        }

        public void ApplyUpgrade()
        {
            if (_resourceModel.CurrentResourceAmount >= _upgradeModel.CurrentCost)
            {
                //Списываем ресурсы
                _resourceModel.SpendResource(_upgradeModel.CurrentCost);

                //Применяем улучшение к модели улучшения
                _upgradeModel.ApplyUpgrade();

                _gameStageController.ApplyMassUpgrade();
                _gameStageController.UpdateMassView(_upgradeModel);
                _gameStageController.ShowUpgradeDetails();

                EventBus<GasCloudModel>.Publish(GameEventEnum.UpgradePurchased, (GasCloudModel)_gameStageController.GetModel());
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