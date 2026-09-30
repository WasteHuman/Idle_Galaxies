using EventBus;
using Game.GameStages.AllStages.Models;
using Game.GameStages.AllStages.Views;
using Game.GameStages.FirstStage.BaseMVC;
using Game.Resource.BaseMVC;
using Game.Shop.UpgradesBaseMVC.Interfaces;
using System.Collections.Generic;
using UI;
using UnityEngine;

namespace Game.GameStages.AllStages.Controllers
{
	public class ShopInitializer : MonoBehaviour
	{
        private List<IUpgradeController> _upgradeControllers;
        private List<IUpgradeModel> _upgradeModels;

        private void OnEnable()
        {
			EventBus<int>.Subscribe(GameEventEnum.GameStageCompleted, NextStage);
        }

        private void OnDisable()
        {
			EventBus<int>.Unsubscribe(GameEventEnum.GameStageCompleted, NextStage);
        }

        public void Initialize(List<IResourceModel> resourceModels, List<ViewUIBase> upgradeViews, IStageController gameStageController)
		{
			InitializeModels();
			InitializeControllers(resourceModels, upgradeViews, gameStageController);
		}

		public void NextStage(int stageID)
		{
			switch (stageID)
			{
				case 0:
				break;

				case 1:
					foreach(IUpgradeModel model in _upgradeModels)
					{
						model.StagePassing();
					}
				break;
			}
		}

		private void InitializeModels()
		{
			_upgradeModels = new()
			{
				new MatterUpgradeModel(),
				new MassUpgradeModel(),
				new GravitationUpgradeModel()
			};
		}

		private void InitializeControllers(List<IResourceModel> resourceModels, List<ViewUIBase> upgradeViews, IStageController gameStageController)
		{
			_upgradeControllers = new()
			{
				new MatterUpgradeController(resourceModels[0], _upgradeModels[0], (MatterUpgradeView)upgradeViews[0]),
				new MassUpgradeContoller(resourceModels[0], _upgradeModels[1], (MassUpgradeView)upgradeViews[1], gameStageController),
				new GravitationUpgradeController(resourceModels[0], _upgradeModels[2], _upgradeModels[1], (GravitationUpgradeView)upgradeViews[2], gameStageController)
			};
		}
	}
}