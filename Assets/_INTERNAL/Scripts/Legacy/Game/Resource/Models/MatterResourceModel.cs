using Game.Resource.BaseMVC;

namespace Game.Resource.Models
{
    public class MatterResourceModel : ResourceModelBase
    {
        private float _minMatterCollect;
        private float _maxMatterCollect;

        private float _matterCollectRateIncrease;

        public float MinMatterCollect => _minMatterCollect;
        public float MaxMatterCollect => _maxMatterCollect;

        public MatterResourceModel()
        {
            _minMatterCollect = 5f;
            _maxMatterCollect = 10f;

            _resourceAmount = 10000f;

            _matterCollectRateIncrease = 1f;
        }

        public override void UpdateResourceAmount(float amount)
        {
            _resourceAmount = amount;
        }

        public override void UpgradeResourceModel()
        {
            _minMatterCollect *= _matterCollectRateIncrease;
            _maxMatterCollect *= _matterCollectRateIncrease;

            _matterCollectRateIncrease += 0.2f;
        }
    }
}