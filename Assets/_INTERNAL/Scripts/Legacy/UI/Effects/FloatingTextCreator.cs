using UnityEngine;

namespace UI.Effects
{
    public class FloatingTextCreator : MonoBehaviour
    {
        [SerializeField] private FloatingText _textPrefab;

        public void CreateFloatingText(string textValue, Canvas canvas)
        {
            FloatingText text = Instantiate(_textPrefab, canvas.transform);
            text.SetText(textValue);
        }
    }
}