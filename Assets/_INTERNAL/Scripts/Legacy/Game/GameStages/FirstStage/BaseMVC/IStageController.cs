using Game.Shop.UpgradesBaseMVC.Interfaces;

namespace Game.GameStages.FirstStage.BaseMVC
{
    public interface IStageController
    {
        void ApplyMassUpgrade();
        void ApplyGravityUpgrade();
        void UpdateGravitationView(IUpgradeModel model);
        void UpdateMassView(IUpgradeModel model);
        void ShowUpgradeDetails();
    }
}