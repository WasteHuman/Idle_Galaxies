using TMPro;
using UnityEngine;

namespace UI
{
    public class FloatingText : MonoBehaviour
    {
        [SerializeField] private float _moveSpeed = 50f;
        [SerializeField] private float _fadeDuration = 1f;

        private TextMeshProUGUI _resourceText;
        private Color _originalColor;

        private void Awake()
        {
            _resourceText = GetComponent<TextMeshProUGUI>();
            _originalColor = _resourceText.color;
        }

        private void Start()
        {
            Destroy(gameObject, _fadeDuration);
        }

        private void Update()
        {
            transform.Translate(_moveSpeed * Time.deltaTime * Vector3.up);

            float fadeStep = Time.deltaTime / _fadeDuration;
            _resourceText.color = new(_originalColor.r, _originalColor.g, _originalColor.b, _resourceText.color.a - fadeStep);
        }

        public void SetText(string text)
        {
            _resourceText.text = text;
        }
    }
}