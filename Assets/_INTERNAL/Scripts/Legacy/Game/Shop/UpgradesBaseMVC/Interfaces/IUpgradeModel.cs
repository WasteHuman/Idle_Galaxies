namespace Game.Shop.UpgradesBaseMVC.Interfaces
{
    public interface IUpgradeModel
    {
        string Name { get; }
        float CostMultiplier { get; }
        float CurrentCost { get; }
        int Level { get; }
        int MaxLevel { get; }
        void ApplyUpgrade();
        void LevelUp();
        void StagePassing();
    }
}