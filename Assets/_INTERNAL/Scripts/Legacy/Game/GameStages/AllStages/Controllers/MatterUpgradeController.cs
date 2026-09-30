using Game.Resource.BaseMVC;
using Game.Shop.UpgradesBaseMVC.Interfaces;

namespace Game.GameStages.AllStages.Controllers
{
    public class MatterUpgradeController : IUpgradeController
    {
        private readonly IResourceModel _resourceModel;
        private readonly IUpgradeModel _upgradeModel;
        private readonly IUpgradeView _upgradeView;

        public MatterUpgradeController(IResourceModel resourceModel, IUpgradeModel upgradeModel, IUpgradeView upgradeView)
        {
            _resourceModel = resourceModel;
            _upgradeModel = upgradeModel;
            _upgradeView = upgradeView;

            _upgradeView.SetController(this);
            ShowUpgradeDetails();

            _upgradeView.OnUpgradeButtonClicked += OnUpgradeButtonClicked;
        }

        public void ApplyUpgrade()
        {
            if (_resourceModel.CurrentResourceAmount >= _upgradeModel.CurrentCost)
            {
                _resourceModel.SpendResource(_upgradeModel.CurrentCost);
                _resourceModel.UpgradeResourceModel();
                _upgradeModel.ApplyUpgrade();
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