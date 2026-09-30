using Game.Shop.UpgradesBaseMVC.Interfaces;
using UnityEngine;

namespace Game.GameStages.AllStages.Models
{
    public class MatterUpgradeModel : IUpgradeModel
    {
        private float _cost;
        private int _level;
        private float _costIncreaseRate;
        private int _maxLevel;

        private readonly float _initialCost = 10f;

        public string Name => "Улучшение материи";
        public float CostMultiplier
        {
            get => _costIncreaseRate;
            private set
            {
                if(_costIncreaseRate != value)
                {
                    _costIncreaseRate = value;
                }
            }
        }
        public float CurrentCost
        {
            get => _cost;

            private set
            {
                if (_cost != value)
                {
                    _cost = value;
                }
            }
        }
        public int Level
        {
            get => _level;
            private set
            {
                if (_level != value)
                {
                    _level = value;
                }
            }
        }
        public int MaxLevel
        {
            get => _maxLevel;

            private set
            {
                if (_maxLevel != value)
                    _maxLevel = value;
            }
        }

        public MatterUpgradeModel(int maxLevel = 100)
        {
            Level = 0;
            MaxLevel = maxLevel;
            CurrentCost = _initialCost;
            CostMultiplier = 1.2f;
        }

        public void ApplyUpgrade()
        {
            if(Level < MaxLevel)
            {
                LevelUp();
            }
            else
            {
                Debug.LogWarning($"Upgrade {Name} has a maximum level: {Level} ");
            }
        }

        public void LevelUp()
        {
            Level++;
            CurrentCost *= CostMultiplier;
            CostMultiplier += 0.2f;
        }

        public void StagePassing()
        {
            MaxLevel *= 2;
        }
    }
}