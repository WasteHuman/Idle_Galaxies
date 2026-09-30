using Game.GameStages.FirstStage.BaseMVC;
using UnityEngine;

namespace Game.GameStages.Base
{
    public abstract class GameStageBase<TModel, TView, TController> : MonoBehaviour, IStage
        where TModel : IStageModel
        where TView : IStageView
        where TController : IStageController
    {
        protected TModel Model { get; private set; }
        protected TView View { get; private set; }
        protected TController Controller { get; private set; }

        public abstract int GameStageIndex {  get; }
        public abstract void Enter();
        public abstract void Exit();
        public abstract void Tick();

        protected void Initialize(TModel model, TView view, TController controller)
        {
            Model = model;
            View = view;
            Controller = controller;
        }
    }
}