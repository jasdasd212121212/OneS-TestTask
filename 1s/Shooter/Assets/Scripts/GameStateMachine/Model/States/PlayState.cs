public class PlayState : State
{
    private PauseModel _pause;

    public PlayState(PauseModel pause)
    {
        _pause = pause;
    }

    public override void OnEnter()
    {
        _pause.SetPaused(false);
    }
}