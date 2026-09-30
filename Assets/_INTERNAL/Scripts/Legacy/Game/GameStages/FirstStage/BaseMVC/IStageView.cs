using Game.Shop.UpgradesBaseMVC.Interfaces;

namespace Game.GameStages.FirstStage.BaseMVC
{
    public interface IStageView
    {
        void OnGameStageStarted();
        void OnPresureUpgradeApplied(IUpgradeModel model);
        void OnMassUpgradeApplied(IUpgradeModel model);
    }
}