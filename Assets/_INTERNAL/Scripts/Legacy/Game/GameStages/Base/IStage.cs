namespace Game.GameStages.Base
{
    public interface IStage
    {
        int GameStageIndex { get; }

        void Enter();
        void Exit();
        void Tick();
    }
}