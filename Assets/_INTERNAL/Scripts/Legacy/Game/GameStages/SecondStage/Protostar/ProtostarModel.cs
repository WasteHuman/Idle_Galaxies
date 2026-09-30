using EventBus;
using Game.GameStages.FirstStage.BaseMVC;
using System;

namespace Game.GameStages.SecondStage.Protostar
{
    public class ProtostarModel : GameStageModelBase
    {
        private const float _criticalMass = 99f;
        private const float _criticalPressure = 99f;

        private float _mass;
        private float _massIncreaseRate;

        private float _pressure;
        private float _pressureIncreaseRate;

        private int _transformationProgress;
        private int _transformationProgressIncreaseRate = 1;
        private int _transformationProgressMax = 100;

        public override float Mass
        {
            get => _mass;

            protected set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(Mass), "Mass cannot be negative");

                if (_mass != value)
                {
                    _mass = value;
                    EventBus<float>.Publish(GameEventEnum.MassChanged, _mass);
                }
            }
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
                if (value < 0f)
                    throw new ArgumentOutOfRangeException(nameof(Pressure), "Pressure cannot be negative");

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

        public ProtostarModel(float initialMass, int transformationProgress = 0)
        {
            Mass = initialMass * 0.01f;
            _transformationProgress = transformationProgress;
        }

        public override void AddMass()
        {
        }

        public override void AddPressure()
        {
        }

        public override bool TryGraviUpgrade()
        {
            return false;
        }

        public override bool TryMassUpgrade()
        {
            return false;
        }

        public override void UpdateProgress()
        {
        }
    }
}
