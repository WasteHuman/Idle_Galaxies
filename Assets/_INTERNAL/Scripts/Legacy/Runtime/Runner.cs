using EventBus;
using Game.GameStages.AllStages.Controllers;
using Game.GameStages.AllStages.Views;
using Game.GameStages.FirstStage;
using Game.GameStages.FirstStage.BaseMVC;
using Game.GasCloudCreation;
using Game.Resource.BaseMVC;
using Game.Resource.Controllers;
using Game.Resource.Models;
using Game.Resource.Views;
using Game.Shop.UpgradesBaseMVC.Interfaces;
using System.Collections.Generic;
using UI;
using UnityEngine;

namespace Runtime
{
    public class Runner : MonoBehaviour
    {
        [Header("Cloud Creation")]
        [SerializeField] private GasCloudCreator _gasCloudCreator;
        [SerializeField] private GasCloudCreationHandler _gasCloudCreationHandler;

        [Space(15), Header("Game stage controller")]
        [SerializeField] private GameStageHandler _gameStageHandler;

        [Space(15), Header("Shop controllers handler")]
        [SerializeField] private ShopInitializer _shopHandler;

        [Space(15), Header("UI")]
        [SerializeField] private UIHolder _uiHolder;
        [SerializeField] private FirstStageUI _firstStageUIPrefab;

        [SerializeField] private FirstStageUI _firstStageUI;

        private List<IResourceController> _resourceControllers;
        private List<IUpgradeController> _upgradeControllers;
        private List<IStageController> _gameStageControllers;

        private List<IResourceModel> _resourceModels;
        private List<IUpgradeModel> _upgradeModels;
        private List<IStageModel> _gameStageModels;

        private void OnEnable()
        {
            _gasCloudCreationHandler.GasCloudCreated += OnGasCloudCreated;
        }

        private void OnDisable()
        {
            _gasCloudCreationHandler.GasCloudCreated -= OnGasCloudCreated;
        }

        private void Awake()
        {
            InitializeUI();
            _gameStageHandler.Initialize();
        }

        private void InitializeUI()
        {
            _firstStageUI = Instantiate(_firstStageUIPrefab);
            _uiHolder.Initialize(_firstStageUI.Views);
        }

        private void CreateModelsAndControllers()
        {
            CreateResourceModels();
            InitializeResourceControllers();

            CreateGameStageModels();
            InitializeGameStageControllers();
        }

        private void SetUIState()
        {
            _uiHolder.TryShowUIPanel(typeof(MatterResourceView));
            _uiHolder.TryShowUIPanel(typeof(ShopView));
            _uiHolder.TryShowUIPanel(typeof(StatsUI));
        }

        private void CreateGameStageModels()
        {
            GasCloudStage gasCloudStage = (GasCloudStage)_gameStageHandler.GasCloudStage;
            _gameStageModels = new()
            {
                gasCloudStage.GasCloudModel
            };
        }

        private void CreateResourceModels()
        {
            _resourceModels = new()
            {
                new MatterResourceModel()
            };
        }

        private void InitializeGameStageControllers()
        {
            GasCloudStage gasCloudStage = (GasCloudStage)_gameStageHandler.GasCloudStage;
            _gameStageControllers = new()
            {
                gasCloudStage.GasCloudController
            };
        }

        private void InitializeResourceControllers()
        {
            _resourceControllers = new()
            {
                new MatterResourceController((MatterResourceModel)_resourceModels[0], (MatterResourceView)_firstStageUI.ResourceViews[0])
            };
        }

        private void OnGasCloudCreated(GasCloudStage gasCloudStage)
        {
            SetUIState();
            _gameStageHandler.StartStage(gasCloudStage);

            EventBus<bool>.Publish(GameEventEnum.GasCloudCreated, true);

            CreateModelsAndControllers();
            _shopHandler.Initialize(_resourceModels, _firstStageUI.UpgradeViews, _gameStageControllers[0]);
        }
    }
}