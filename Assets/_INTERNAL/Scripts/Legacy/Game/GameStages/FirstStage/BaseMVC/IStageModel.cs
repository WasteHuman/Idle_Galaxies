namespace Game.GameStages.FirstStage.BaseMVC
{
    public interface IStageModel
    {
        float MassIncreaseRate {  get; }
        float Mass { get; }
        float CriticalMass { get; }
        int TransformationProgress { get; }
        bool TryMassUpgrade();
        bool TryGraviUpgrade();
        void AddMass();
        void UpdateProgress();
    }
}