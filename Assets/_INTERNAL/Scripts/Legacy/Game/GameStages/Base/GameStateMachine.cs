namespace Game.GameStages.Base
{
    public class GameStateMachine
    {
        private IStage _currentStage;

        public void SetState(IStage newStage)
        {
            if (_currentStage != newStage)
            {
                _currentStage?.Exit();
                _currentStage = newStage;
                _currentStage.Enter();
            }
        }

        public void Update()
        {
            _currentStage?.Tick();
        }
    }
}