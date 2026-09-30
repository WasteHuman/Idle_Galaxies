using UnityEngine;

namespace UI
{
    public class ViewUIBase : MonoBehaviour, IViewUI
    {
        [SerializeField] private Canvas _canvas;

        public Canvas Canvas => _canvas;

        [ContextMenu("Show")]
        public void Show()
        {
            gameObject.SetActive(true);
        }

        [ContextMenu("Hide")]
        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}