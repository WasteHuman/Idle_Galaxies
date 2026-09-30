using Game.Shop.UpgradesBaseMVC.Interfaces;
using UnityEngine;

namespace Game.GameStages.AllStages.Models
{
    public class GravitationUpgradeModel : IUpgradeModel
    {
        private float _cost;
        private float _costIncreaceRate;

        private int _level;
        private int _maxLevel;

        private readonly float _initialCost = 15f;

        public string Name => "Улучшение грави-эффекта";
        public float CostMultiplier
        {
            get => _costIncreaceRate;
            
            private set
            {
                if (_costIncreaceRate != value)
                {
                    _costIncreaceRate = value;
                }
            }
        }
        public float CurrentCost
        {
            get => _cost;
            private set
            {
                if(_cost != value)
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
                if(_level != value)
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

        public GravitationUpgradeModel(int maxLevel = 50)
        {
            Level = 0;
            MaxLevel = maxLevel;
            CurrentCost = _initialCost;
            //CostMultiplier = 1.3f;
            CostMultiplier = 1f;
        }

        public void ApplyUpgrade()
        {
            if (Level < MaxLevel)
            {
                LevelUp();
            }
            else
            {
                Debug.LogWarning($"Upgrade {Name} has a maximum level: {Level} of {MaxLevel}");
            }
        }

        public void LevelUp()
        {
            Level++;
            CurrentCost *= CostMultiplier;
            //CostMultiplier += 0.4f;
        }

        public void StagePassing()
        {
            MaxLevel *= 2;
        }

        public void CheckDependentLevel(IUpgradeModel model)
        {
            if (Level > model.Level)
            {
                Level = model.Level;
            }
            else
                ApplyUpgrade();
        }
    }
}