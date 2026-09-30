using UnityEngine;

namespace Animations
{
    public class LightPulse : MonoBehaviour
    {
        [SerializeField] private AnimationCurve _intensityCurve;
        [SerializeField] private float _pulseDuration = 2f;

        private Light _targetLight;
        private float _timer;

        private void Start()
        {
            _targetLight = GetComponent<Light>();
        }

        private void Update()
        {
            if (_targetLight == null || _intensityCurve == null)
                return;

            _timer += Time.deltaTime;
            float time = (_timer % _pulseDuration) / _pulseDuration;

            _targetLight.intensity = _intensityCurve.Evaluate(time);
        }
    }
}