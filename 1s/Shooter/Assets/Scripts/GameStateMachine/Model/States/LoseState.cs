using Cysharp.Threading.Tasks;
using System;

public class LoseState : State
{
    private PauseModel _pause;
    private float _timeStopDelay;

    public LoseState(PauseModel pause, float timeStopDelay)
    {
        _pause = pause;
        _timeStopDelay = timeStopDelay;
    }

    public override void OnEnter()
    {
        StopTime().Forget();
    }

    private async UniTask StopTime()
    {
        await UniTask.Delay(TimeSpan.FromSeconds(_timeStopDelay));
        _pause.SetPaused(true);
    }
}