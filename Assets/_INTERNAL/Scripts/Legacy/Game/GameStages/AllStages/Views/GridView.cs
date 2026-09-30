using UnityEngine;
using UnityEngine.UI;

namespace Game.GameStages.AllStages.Views
{
    public class GridView : MonoBehaviour
    {
        [SerializeField] private Button _closeButton;

        public Button CloseButton => _closeButton;

        public void OpenGrid()
        {
            if (gameObject.activeSelf) return;

            gameObject.SetActive(true);
        }

        public void CloseGrid()
        {
            if (!gameObject.activeSelf) return;

            gameObject.SetActive(false);
        }
    }
}