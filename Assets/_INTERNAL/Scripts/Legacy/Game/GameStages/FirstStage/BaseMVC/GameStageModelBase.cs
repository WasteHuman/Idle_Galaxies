namespace Game.GameStages.FirstStage.BaseMVC
{
    public abstract class GameStageModelBase : IStageModel
    {
        public virtual float MassIncreaseRate { get; protected set; }

        public virtual float Mass { get; protected set; }

        public virtual float CriticalMass { get; }

        public virtual float Pressure {  get; protected set; }

        public virtual float CriticalPressure { get; }

        public virtual int TransformationProgress { get; protected set; }

        public abstract void AddMass();

        public abstract void AddPressure();

        public abstract bool TryMassUpgrade();

        public abstract bool TryGraviUpgrade();

        public abstract void UpdateProgress();
    }
}
