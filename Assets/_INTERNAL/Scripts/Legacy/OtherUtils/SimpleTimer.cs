using EventBus;
using System;
using UnityEngine;

namespace OtherUtils
{
    public class SimpleTimer
    {

        private float _time;
        private float _maxTime;

        private bool _isRunning;

        public event Action<float> OnProgressUpdated;
        public event Action OnCompleted;

        public SimpleTimer(float maxTime)
        {
            _maxTime = maxTime;
            ResetTimer();
        }

        private void OnTimerFinished()
        {
            OnCompleted?.Invoke();
        }

        public void UpdateTimer()
        {
            if (!_isRunning) return;

            _time -= Time.deltaTime;

            OnProgressUpdated?.Invoke(_time);

            if (_time <= 0f)
            {
                _time = _maxTime;
                _isRunning = false;
                OnTimerFinished();
            }
        }

        public void StartTimer()
        {
            _isRunning = true;
        }

        public void StopTimer()
        {
            _isRunning = false;
        }

        public void ResetTimer()
        {
            _time = _maxTime;
            _isRunning = false;
            OnProgressUpdated?.Invoke(_time);
        }
    }
}