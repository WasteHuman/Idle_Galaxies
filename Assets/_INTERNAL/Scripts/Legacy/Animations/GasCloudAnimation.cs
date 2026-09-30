using EventBus;
using UnityEngine;

namespace Animations
{
    public class GasCloudAnimation : MonoBehaviour
    {
        [Header("Pulsate settings")]
        [SerializeField] private float _pulsateSpeed = 1f;
        [SerializeField] private float _pulsateAmount = 0.1f;
        [SerializeField] private float _rotationSpeed = 10f;

        private Transform _cloudTransform;
        private Vector3 _initialScale;

        private bool _isCloudCreated = false;

        //private void OnEnable()
        //{
        //    EventBus<bool>.Subscribe(GameEventEnum.GasCloudCreated, OnGasCloudCreated);
        //}

        //private void OnDisable()
        //{
        //    EventBus<bool>.Unsubscribe(GameEventEnum.GasCloudCreated, OnGasCloudCreated);
        //}

        private void Start()
        {
            _cloudTransform = transform;
            _initialScale = _cloudTransform.localScale;

            _isCloudCreated = true;
        }

        private void Update()
        {
            if (_isCloudCreated)
            {
                ScalePulse();
                Rotation();
            }
        }

        private void Rotation()
        {
            _cloudTransform.Rotate(_rotationSpeed * Time.deltaTime * Vector3.forward);
        }

        private void ScalePulse()
        {
            float scaleOffset = Mathf.Sin(Time.time * _pulsateSpeed) * _pulsateAmount;
            _cloudTransform.localScale = _initialScale + Vector3.one * scaleOffset;
        }

        private void OnGasCloudCreated(bool isCreated)
        {
            _isCloudCreated = isCreated;
        }
    }
}