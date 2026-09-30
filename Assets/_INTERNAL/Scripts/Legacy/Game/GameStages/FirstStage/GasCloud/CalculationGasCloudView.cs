using Game.Shop.UpgradesBaseMVC.Interfaces;
using UnityEngine;

namespace Game.GameStages.FirstStage.GasCloud
{
    public class CalculationGasCloudView
    {
        private readonly float _startParticleSize = 0.75f;
        private readonly float _finalParticleSize = 1f;
        private float _newParticleSize;
        private float _particleSizeIncreaseRate;

        private readonly float _startSpeed = 0.1f;
        private readonly float _finalSpeed = 1f;
        private float _newStartSpeed;
        private float _speedIncreaseRate;

        private readonly float _startRadius = 1.5f;
        private readonly float _finalRadius = 0.8f;
        private readonly float _startRadiusThickness = 0f;
        private readonly float _finalRadiusThickness = 1f;
        private float _newRadiusThickness;
        private float _newRadius;
        private float _radiusDecreaseRate;
        private float _radiusThicknessIncreaseRate;

        private readonly float _startLifeTime = 7.5f;
        private readonly float _finalLifeTime = 3f;
        private float _newLifeTime;
        private float _lifeTimeDecreaseRate;

        public CalculationGasCloudView()
        {
            _newParticleSize = _startParticleSize;
            _newStartSpeed = _startSpeed;
            _newRadius = _startRadius;
            _newLifeTime = _startLifeTime;
            _newRadiusThickness = _startRadiusThickness;
        }

        public void UpdateCloudVisual(ParticleSystem.MainModule main)
        {
            main.startSize = _newParticleSize;
            main.startSpeed = _newStartSpeed;
            main.startLifetime = _newLifeTime;
            //main.duration = _newLifeTime;
        }

        public void UpdateCloudGravitation(ParticleSystem.ShapeModule shape)
        {
            shape.radius = _newRadius;
            shape.radiusThickness = _newRadiusThickness;
        }

        public void CalculateCloudPressure()
        {
            _newRadius -= _radiusDecreaseRate;
            _newRadiusThickness += _radiusThicknessIncreaseRate;
        }

        public void CalculateCloudMass()
        {
            _newParticleSize += _particleSizeIncreaseRate;
            _newStartSpeed += _speedIncreaseRate;
            _newLifeTime -= _lifeTimeDecreaseRate;
        }

        public void CalculatePressureRates(IUpgradeModel model)
        {
            if (model.Level == model.MaxLevel)
            {
                _newRadius = _finalRadius;
            }
            
            CalculateRadius(model.MaxLevel);
        }

        public void CalculateMassRates(IUpgradeModel model)
        {
            if (model.Level == model.MaxLevel)
            {
                _newParticleSize = _finalParticleSize;
                _newStartSpeed = _finalSpeed;
                _newLifeTime = _finalLifeTime;
            }

            CalculatePatricleSize(model.MaxLevel);
            CalculateStartSpeed(model.MaxLevel);
            CalculateLifeTime(model.MaxLevel);
        }

        private void CalculateLifeTime(int levelCount)
        {
            float difference = _startLifeTime - _finalLifeTime;
            _lifeTimeDecreaseRate = difference / levelCount;
        }

        private void CalculateRadius(int levelCount)
        {
            float radiusDifference = _startRadius - _finalRadius;
            _radiusDecreaseRate = radiusDifference / levelCount;

            float radiusThicknessDifference = _finalRadiusThickness - _startRadiusThickness;
            _radiusThicknessIncreaseRate = radiusThicknessDifference / levelCount;
        }

        private void CalculateStartSpeed(int levelCount)
        {
            float difference = _finalSpeed - _startSpeed;
            _speedIncreaseRate = difference / levelCount;
        }

        private void CalculatePatricleSize(int levelCount)
        {
            float difference = _finalParticleSize - _startParticleSize;
            _particleSizeIncreaseRate = difference / levelCount;
        }
    }
}