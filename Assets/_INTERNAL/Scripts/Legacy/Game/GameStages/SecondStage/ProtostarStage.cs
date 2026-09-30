using EventBus;
using Game.GameStages.Base;
using Game.GameStages.SecondStage.Protostar;
using OtherUtils;
using UnityEngine;

namespace Game.GameStages.SecondStage
{
    public class ProtostarStage : GameStageBase<ProtostarModel, ProtostarView, ProtostarController>
    {
        [SerializeField] private ProtostarView _view;

        [Space(15), Header("Settings")]
        [SerializeField] private float _initialMass;
        [SerializeField] private float _delayBeforeDestroy = 2.5f;

        private ObjectLifecycle _objectLifeCycle;

        public override int GameStageIndex => 1;

        public override void Enter()
        {
            EventBus<float>.Subscribe(GameEventEnum.GameStageCompleted, m => _initialMass = m);
            Initialize(new ProtostarModel(_initialMass), _view, new ProtostarController(Model, View));

            _objectLifeCycle = ObjectLifecycleFactory.Create(gameObject, _delayBeforeDestroy);
        }

        public override void Exit()
        {
            EventBus<float>.Unsubscribe(GameEventEnum.GameStageCompleted, m => _initialMass = m);

            _objectLifeCycle.DestroyObject();
        }

        public override void Tick()
        {
            if (Model.TransformationProgress == Model.TransformationProgressMax)
                EventBus<int>.Publish(GameEventEnum.GameStageCompleted, 2);
        }
    }
}