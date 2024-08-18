public interface IReadOnlyStateMachine
{
    public IObservableState CurrentState { get; }
    public IObservableState GetState<T>() where T : State;
}