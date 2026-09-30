using UnityEngine;
using UnityEngine.UI;

namespace NewArchitecture.UI.Common
{
    public class UILoadingView : MonoBehaviour
    {
        [SerializeField] private Slider _progressBar;
        [SerializeField] private GameObject _loadingScreen;

        public void ShowLoadingScreen()
        {
            _loadingScreen.SetActive(true);
        }

        public void SetLoadingProgress(float progress) => _progressBar.value = progress;

        public void HideLoadingScreen()
        {
            _loadingScreen.SetActive(false);
        }
    }
}