using System;

public abstract class State : IObservableState
{
    public event Action entered;
    public event Action exited;

    public void Enter()
    {
        entered?.Invoke();
        OnEnter();
    }

    public void Exit() 
    {
        exited?.Invoke();
        OnExit();
    }

    public abstract void OnEnter();
    public virtual void OnExit() { }
}