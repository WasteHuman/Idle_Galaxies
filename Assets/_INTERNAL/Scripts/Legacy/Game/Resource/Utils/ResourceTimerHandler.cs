using Animations;
using OtherUtils;

namespace Game.Resource.Utils
{
    public class ResourceTimerHandler
    {
        private readonly SimpleTimer _simpleTimer;
        private readonly ProgressBar _progressBar;

        public ResourceTimerHandler(SimpleTimer simpleTimer, ProgressBar progressBar)
        {
            _simpleTimer = simpleTimer;
            _progressBar = progressBar;

            _simpleTimer.OnProgressUpdated += UpdateProgress;
        }

        public void StartTimer() => _simpleTimer.StartTimer();
        public void Update() => _simpleTimer.UpdateTimer();
        public void Dispose() => _simpleTimer.OnProgressUpdated -= UpdateProgress;

        private void UpdateProgress(float progress)
        {
            _progressBar.UpdateProgressBar(progress);
        }
    }
}