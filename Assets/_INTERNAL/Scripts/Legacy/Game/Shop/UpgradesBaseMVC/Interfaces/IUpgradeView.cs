using System;

namespace Game.Shop.UpgradesBaseMVC.Interfaces
{
    public interface IUpgradeView
    {
        event Action OnUpgradeButtonClicked;
        void SetController(IUpgradeController upgradeController);
        void UpdateUI(int level, float cost);
    }
}