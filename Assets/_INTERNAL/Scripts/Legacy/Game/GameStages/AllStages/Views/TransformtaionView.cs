using EventBus;
using TMPro;
using UnityEngine;

namespace Game.GameStages.AllStages.Views
{
    public class TransformtaionView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _progressText;

        private void OnEnable()
        {
            EventBus<int>.Subscribe(GameEventEnum.TransformationProgressInitialized, InitializeProgressText);
            EventBus<int>.Subscribe(GameEventEnum.TransformationProgressUpdated, UpdateProgress);
        }

        private void OnDisable()
        {
            EventBus<int>.Unsubscribe(GameEventEnum.TransformationProgressInitialized, InitializeProgressText);
            EventBus<int>.Unsubscribe(GameEventEnum.TransformationProgressUpdated, UpdateProgress);
        }

        private void InitializeProgressText(int progress)
        {
            string localization = "Прогресс";

            _progressText.text = $"{localization}: {progress}%";
        }

        private void UpdateProgress(int progress)
        {
            string localization = "Прогресс";

            _progressText.text = $"{localization}: {progress}%";
        }
    }
}