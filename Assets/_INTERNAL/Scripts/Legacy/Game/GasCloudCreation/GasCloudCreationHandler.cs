using Animations;
using EventBus;
using Game.GameStages.FirstStage;
using OtherUtils;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Game.GasCloudCreation
{
    public class GasCloudCreationHandler : MonoBehaviour
    {
        [SerializeField] private Button _createButton;
        [SerializeField] private GasCloudCreator _gasCloudCreator;
        [SerializeField] private ProgressBar _creationSlider;

        private ObjectLifecycle _objectLifecycle;

        private bool _isCreating = false;
        private float _cloudCreationTime = 0f;
        [SerializeField] private float _cloudCreationDuration = 10f;

        public event Action<GasCloudStage> GasCloudCreated;

        private void Awake()
        {
            _objectLifecycle = ObjectLifecycleFactory.Create(GetComponentInParent<Canvas>().gameObject);
            _creationSlider.Initialization(_cloudCreationDuration);
        }

        private void OnEnable()
        {
            _createButton.onClick.AddListener(StartCreation);
        }

        private void OnDestroy()
        {
            _createButton.onClick.RemoveListener(StartCreation);
        }

        private void Update()
        {
            if (_isCreating)
                CreatingCloud();
        }

        private void CreatingCloud()
        {
            _cloudCreationTime += Time.deltaTime;
            _creationSlider.UpdateProgressBar(_cloudCreationTime);

            if (_cloudCreationTime >= _cloudCreationDuration)
            {
                _isCreating = false;
                _cloudCreationTime = _cloudCreationDuration;

                GasCloudStage gasCloudStage = _gasCloudCreator.CreateGasCloud();

                GasCloudCreated?.Invoke(gasCloudStage);
                //EventBus<bool>.Publish(GameEventEnum.GasCloudCreated, true);

                _objectLifecycle.DestroyObject();
            }
        }

        private void StartCreation()
        {
            if (_isCreating)
                return;

            _isCreating = true;
            _createButton.interactable = false;
        }
    }
}