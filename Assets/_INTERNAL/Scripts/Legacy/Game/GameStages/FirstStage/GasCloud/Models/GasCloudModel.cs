using EventBus;
using Game.GameStages.FirstStage.BaseMVC;
using System;
using UnityEngine;

namespace Game.GameStages.FirstStage.Models
{
    public class GasCloudModel : GameStageModelBase
    {
        private const float _criticalMass = 117.4f;
        private const float _criticalPressure = 10.7f;

        private readonly float _initialPressure = 100f * 0.001f;
        private readonly int _transformationProgressMax = 100;

        private float _massIncreaseRate;
        private float _mass;

        private float _pressureIncreaseRate;
        private float _pressure;

        private int _transformationIncreaseRate;
        private int _transformationProgress;

        public override float MassIncreaseRate
        {
            get => _massIncreaseRate;

            protected set
            {
                if (_massIncreaseRate != value)
                {
                    _massIncreaseRate = value;
                }
            }
        }
        public override float Mass 
        { 
            get => _mass;

            protected set
            {
                if(value < 0)
                    throw new ArgumentOutOfRangeException(nameof(Mass), "Mass cannot be negative");

                if(_mass != value)
                {
                    _mass = value;
                    EventBus<float>.Publish(GameEventEnum.MassChanged, _mass);
                }
            }
        }
        public override int TransformationProgress
        {
            get => _transformationProgress;

            protected set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(TransformationProgress), "Transformation progress cannot be negative");

                if (_transformationProgress != value)
                {
                    _transformationProgress = value;
                    EventBus<int>.Publish(GameEventEnum.TransformationProgressUpdated, TransformationProgress);
                }
            }
        }
        public int TransformationProgressMax
        {
            get => _transformationProgressMax;
        }
        public override float CriticalMass
        {
            get => _criticalMass;
        }
        public override float Pressure
        {
            get => _pressure;

            protected set
            {
                if(_pressure != value)
                {
                    _pressure = value;
                }
            }
        }
        public override float CriticalPressure
        {
            get => _criticalPressure;
        }
        public float PressureIncreaseRate
        {
            get => _pressureIncreaseRate;

            private set
            {
                if (_pressureIncreaseRate != value)
                {
                    _pressureIncreaseRate = value;
                }
            }
        }
        public int TransformationIncreaseRate
        {
            get => _transformationIncreaseRate;

            private set
            {
                if (_transformationIncreaseRate != value)
                {
                    _transformationIncreaseRate = value;
                }
            }
        }

        public GasCloudModel(float initialMass, int initialTransformProgress = 0)
        {
            Mass = initialMass * 0.01f;
            Pressure = _initialPressure;
            TransformationProgress = initialTransformProgress;

            TransformationIncreaseRate = 1;
            MassIncreaseRate = 0.11f;
            PressureIncreaseRate = 0.1f;
        }

        public override bool TryMassUpgrade()
        {
            if (Mass < CriticalMass)
            {
                AddMass();
                UpdateProgress();

                return true;
            }

            return false;
        }

        public override bool TryGraviUpgrade()
        {
            if(Pressure < CriticalMass)
            {
                AddPressure();
                UpdateProgress();

                return true;
            }

            return false;
        }

        public override void AddMass()
        {
            var newMass = Mass * (1f + MassIncreaseRate);

            if (newMass > CriticalMass)
                Mass = CriticalMass;
            else
                Mass = newMass;
        }

        public override void AddPressure()
        {
            var newPressure = Pressure * (1f + PressureIncreaseRate);

            if (newPressure > CriticalPressure)
                Pressure = CriticalPressure;
            else
                Pressure = newPressure;
        }

        public override void UpdateProgress()
        {
            TransformationProgress += TransformationIncreaseRate;
            TransformationProgress = Mathf.Min(TransformationProgress, _transformationProgressMax);
        }
    }
}