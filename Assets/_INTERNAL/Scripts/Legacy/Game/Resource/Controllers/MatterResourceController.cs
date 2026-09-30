using EventBus;
using Game.Resource.BaseMVC;
using Game.Resource.Models;
using Game.Resource.Views;
using UnityEngine;

namespace Game.Resource.Controllers
{
    public class MatterResourceController : IResourceController
    {
        private readonly MatterResourceModel _resourceModel;
        private readonly MatterResourceView _resourceView;

        public MatterResourceController(MatterResourceModel resourceModel, MatterResourceView resourceView)
        {
            _resourceModel = resourceModel;
            _resourceView = resourceView;

            _resourceView.OnCollectResourceRequested += HandleCollectResourceRequested;
        }

        private void HandleCollectResourceRequested()
        {
            float randomMatterCollected = Random.Range(_resourceModel.MinMatterCollect, _resourceModel.MaxMatterCollect);
            EventBus<float>.Publish(GameEventEnum.ResourceCollected, randomMatterCollected);
            CollectResource(randomMatterCollected);
            ShowResourceAmount();
        }

        public void CollectResource(float amount)
        {
            if (amount < 0)
                return;

            _resourceModel.AddResource(amount);
        }

        public void UpdateResource(float amount)
        {
            _resourceModel.UpdateResourceAmount(amount);
            ShowResourceAmount();
        }

        public void ShowResourceAmount()
        {
            _resourceView.UpdateResourceDisplay(_resourceModel.CurrentResourceAmount);
        }
    }
}