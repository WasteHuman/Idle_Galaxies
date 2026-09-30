using Game.GameStages.FirstStage.BaseMVC;
using Game.Shop.UpgradesBaseMVC.Interfaces;
using System.Collections.Generic;
using UnityEngine;

namespace Game.GameStages.SecondStage.Protostar
{
    public class ProtostarView : GameStageViewBase
    {
        [SerializeField] private List<ParticleSystem> _clouds;

        private void Start()
        {
            OnGameStageStarted();
        }

        public override void OnGameStageStarted()
        {
            foreach (ParticleSystem cloud in _clouds)
            {
                cloud.Play();
            }
        }

        public override void OnMassUpgradeApplied(IUpgradeModel model)
        {
        }

        public override void OnPresureUpgradeApplied(IUpgradeModel model)
        {
        }

        public override void UpdateUI(List<string> stats)
        {
        }
    }
}