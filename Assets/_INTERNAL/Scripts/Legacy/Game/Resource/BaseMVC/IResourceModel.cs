namespace Game.Resource.BaseMVC
{
    public interface IResourceModel
    {
        float CurrentResourceAmount { get; }
        void UpdateResourceAmount(float amount);
        void AddResource(float amount);
        void UpgradeResourceModel();
        void SpendResource(float amount);
    }
}