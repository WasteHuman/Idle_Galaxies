using Game.GameStages.Base;
using Game.GameStages.FirstStage.BaseMVC;

namespace Game.GameStages.FirstStage
{
    public abstract class GameStage : GameStageBase<IStageModel, IStageView, IStageController>
    {
        protected IStageModel StageModel => base.Model;
        protected IStageView StageView => base.View;
        protected IStageController StageController => base.Controller;

        public abstract override int GameStageIndex { get; }

        public abstract override void Enter();

        public abstract override void Exit();

        public abstract override void Tick();
    }
}