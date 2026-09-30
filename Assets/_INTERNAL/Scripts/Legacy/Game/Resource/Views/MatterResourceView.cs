using Animations;
using EventBus;
using Game.Resource.BaseMVC;
using Game.Resource.Utils;
using OtherUtils;
using System;
using TMPro;
using UI;
using UI.Effects;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Resource.Views
{
    public class MatterResourceView : ViewUIBase, IResourceView
    {
        [SerializeField] private TextMeshProUGUI _resourceCount;
        [SerializeField] private Button _collectResourceButton;

        [Space(15), Header("Effects")]
        [SerializeField] private ProgressBar _progressBar;
        [SerializeField] private FloatingTextCreator _floatingTextCreator;
        
        private readonly float _collectionTime = 1.5f;
        private SimpleTimer _simpleTimer;
        private ResourceTimerHandler _timerHandler;

        public event Action OnCollectResourceRequested;

        private void OnEnable()
        {
            Initialize();

            EventBus<float>.Subscribe(GameEventEnum.ResourceCollected, CreateFloatingText);
            EventBus<float>.Subscribe(GameEventEnum.MatterChanged, UpdateResourceDisplay);
        }

        private void OnDisable()
        {
            EventBus<float>.Unsubscribe(GameEventEnum.ResourceCollected, CreateFloatingText);
            EventBus<float>.Unsubscribe(GameEventEnum.MatterChanged, UpdateResourceDisplay);

            _collectResourceButton.onClick.RemoveListener(StartCollection);
            _timerHandler?.Dispose();
        }

        private void Update()
        {
            _timerHandler.Update();
        }

        private void Initialize()
        {
            _simpleTimer = new(_collectionTime);
            _timerHandler = new(_simpleTimer, _progressBar);

            _progressBar.Initialization(_collectionTime);
            _progressBar.UpdateProgressBar(_collectionTime);

            _collectResourceButton.onClick.AddListener(StartCollection);
            _simpleTimer.OnCompleted += OnTimerFinished;
        }

        private void CreateFloatingText(float amount)
        {
            _floatingTextCreator.CreateFloatingText($"+{NumberUtils.FormatNumber(amount)} материи", Canvas);
        }

        private void OnTimerFinished()
        {
            OnCollectResourceRequested?.Invoke();
            _progressBar.UpdateProgressBar(_collectionTime);
            _collectResourceButton.interactable = true;
        }

        private void StartCollection()
        {
            _collectResourceButton.interactable = false;
            _timerHandler.StartTimer();
        }

        public void UpdateResourceDisplay(float amount)
        {
            _resourceCount.text = $"Материя: {NumberUtils.FormatNumber(amount)}";
        }
    }
}