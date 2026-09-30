using UnityEngine;
using UnityEngine.UI;

namespace Animations
{
    public class ProgressBar : MonoBehaviour
    {
        [SerializeField] private Slider _slider;

        public void Initialization(float maxValue, float startValue = 0f)
        {
            _slider.maxValue = maxValue;
            _slider.value = startValue;
        }

        public void UpdateProgressBar(float value)
        {
            _slider.value = value;
        }

        public void Disable()
        {
            _slider.enabled = false;
        }

        public void Destroy()
        {
            Destroy(gameObject);
        }
    }
}