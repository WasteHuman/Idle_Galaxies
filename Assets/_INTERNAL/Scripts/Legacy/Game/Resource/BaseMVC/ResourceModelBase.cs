using EventBus;
using System;

namespace Game.Resource.BaseMVC
{
    public abstract class ResourceModelBase : IResourceModel
    {
        protected float _resourceAmount;

        public float CurrentResourceAmount
        {
            get => _resourceAmount;

            private set
            {
                if (_resourceAmount != value)
                {
                    _resourceAmount = value;
                }
            }
        }

        public abstract void UpgradeResourceModel();
        public abstract void UpdateResourceAmount(float amount);

        public void AddResource(float amount)
        {
            if(amount < 0f)
            {
                throw new ArgumentException("Amount cannot be negative");
            }

            _resourceAmount += amount;
        }

        public void SpendResource(float amount)
        {
            if(amount < 0f)
            {
                throw new ArgumentException("Amount cannot be negative");
            }

            _resourceAmount -= amount;
            EventBus<float>.Publish(GameEventEnum.MatterChanged, _resourceAmount);

            if (_resourceAmount < 0f)
            {
                _resourceAmount = 0f;
            }
        }
    }
}