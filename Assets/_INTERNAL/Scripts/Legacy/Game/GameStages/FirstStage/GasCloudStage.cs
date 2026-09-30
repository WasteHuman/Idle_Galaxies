using EventBus;
using Game.GameStages.Base;
using Game.GameStages.FirstStage.GasCloud.Controllers;
using Game.GameStages.FirstStage.Models;
using Game.GameStages.FirstStage.Views;
using OtherUtils;
using UnityEngine;

namespace Game.GameStages.FirstStage
{
    public class GasCloudStage : GameStageBase<GasCloudModel, GasCloudView, GasCloudController>
    {
        [SerializeField] private GasCloudView _view;

        [Space(15), Header("Settings")]
        [SerializeField] private float _initialMass = 100f;
        [SerializeField] private float _delayBeforeDestoy = 2.5f;

        private ObjectLifecycle _objectLifeCycle;

        public override int GameStageIndex => 0;

        public GasCloudModel GasCloudModel => Model;
        public GasCloudController GasCloudController => Controller;

        public override void Enter()
        {
            GasCloudModel model = new(_initialMass);
            GasCloudController controller = new(model, _view);

            Initialize(model, _view, controller);
            InitializeGasCloudComponents();

            _objectLifeCycle = ObjectLifecycleFactory.Create(gameObject, _delayBeforeDestoy);
        }

        public override void Exit()
        {
            EventBus<float>.Publish(GameEventEnum.GameStageCompleted, Model.Mass);
            _objectLifeCycle.DestroyObject();
        }

        public override void Tick()
        {
            if (Model.TransformationProgress == Model.TransformationProgressMax)
            {
                EventBus<int>.Publish(GameEventEnum.GameStageCompleted, 1);
            }
        }

        private void InitializeGasCloudComponents()
        {
            View.CreateCalculator(new());
        }
    }
}