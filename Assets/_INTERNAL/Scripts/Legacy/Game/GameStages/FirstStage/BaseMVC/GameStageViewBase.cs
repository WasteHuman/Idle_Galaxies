using Game.Shop.UpgradesBaseMVC.Interfaces;
using System.Collections.Generic;
using UnityEngine;

namespace Game.GameStages.FirstStage.BaseMVC
{
    public abstract class GameStageViewBase : MonoBehaviour, IStageView
    {
        public abstract void UpdateUI(List<string> stats);
        public abstract void OnGameStageStarted();
        public abstract void OnPresureUpgradeApplied(IUpgradeModel model);
        public abstract void OnMassUpgradeApplied(IUpgradeModel model);
    }
}