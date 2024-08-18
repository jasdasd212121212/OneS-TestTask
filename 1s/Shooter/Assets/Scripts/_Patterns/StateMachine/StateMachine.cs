using System.Linq;
using UnityEngine;

public class StateMachine : IReadOnlyStateMachine
{
    private State[] _states;
    private State _currentState;

    public IObservableState CurrentState => _currentState;

    public StateMachine(params State[] states)
    {
        _states = states;
    }

    public void ChangeState(State state)
    {
        if (state == null)
        {
            Debug.LogError($"Critical error -> can`t set null state");
            return;
        }

        if (_states.Contains(state) == false)
        {
            Debug.LogError($"Critical error -> can`t set not existing state: {state}");
            return;
        }

        if (state == _currentState)
        {
            return;
        }

        ExitCurrentState();
        _currentState = state;
        _currentState.Enter();
    }

    public IObservableState GetState<T>() where T : State
    {
        foreach (State state in _states)
        {
            if (state.GetType() == typeof(T))
            {
                return state;
            }
        }

        Debug.LogError($"Critical error -> not existing state: {typeof(T)}");
        return null;
    }

    private void ExitCurrentState()
    {
        if (_currentState != null)
        {
            _currentState.Exit();
        }
    }
}