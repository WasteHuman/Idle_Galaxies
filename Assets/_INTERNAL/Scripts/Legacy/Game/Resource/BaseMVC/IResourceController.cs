namespace Game.Resource.BaseMVC
{
    public interface IResourceController
    {
        void CollectResource(float amount);
        void UpdateResource(float amount);
        void ShowResourceAmount();
    }
}