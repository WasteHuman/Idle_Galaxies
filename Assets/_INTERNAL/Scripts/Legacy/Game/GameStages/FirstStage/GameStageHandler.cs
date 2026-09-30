using EventBus;
using Game.GameStages.Base;
using Game.GameStages.FirstStage.GasCloud.Controllers;
using Game.GameStages.FirstStage.Models;
using Game.GameStages.FirstStage.Views;
using Game.GameStages.SecondStage.Protostar;
using UnityEngine;

namespace Game.GameStages.FirstStage
{
    public class GameStageHandler : MonoBehaviour
    {
        //[SerializeField] private GasCloudStage _gasCloudStagePrefab;
        //[SerializeField] private ProtostarStage _protostarStagePrefab;

        [SerializeField] private GameStageBase<GasCloudModel, GasCloudView, GasCloudController> _gasCloudStagePrefab;
        [SerializeField] private GameStageBase<ProtostarModel, ProtostarView, ProtostarController> _protostarStagePrefab;

        private IStage _startStage;
        private IStage _nextStage;

        private GameStateMachine _gameStateMachine;

        public IStage GasCloudStage => _startStage;

        private void OnEnable()
        {
            EventBus<int>.Subscribe(GameEventEnum.GameStageCompleted, NextStage);
        }

        private void OnDisable()
        {
            EventBus<int>.Unsubscribe(GameEventEnum.GameStageCompleted, NextStage);
        }

        private void Update()
        {
            _gameStateMachine?.Update();
        }

        public void Initialize()
        {
            _gameStateMachine = new();
        }

        public void StartStage(IStage startStage)
        {
            _startStage = startStage;
            _gameStateMachine.SetState(startStage);
        }

        private void NextStage(int index)
        {
            var tempStage = Instantiate(_protostarStagePrefab);
            _nextStage = tempStage;
            _gameStateMachine.SetState(_nextStage);
        }
    }
}