using Zenject;
using UnityEngine;
using Cysharp.Threading.Tasks;
using System;

public class GameStateMachine : MonoBehaviour
{
    [SerializeField] private PlayerHealth _player;

    [Space]

    [SerializeField][Min(0.00001f)] private float _stateChangeDelay;
    [SerializeField][Min(0.00001f)] private float _timeStopDelay;

    [Inject] private EnemyFactory _enemyFactory;
    [Inject] private PauseModel _pauseModel;

    private PlayState _playState;
    private LoseState _loseState;
    private WinState _winState;

    private StateMachine _stateMachine;

    public IReadOnlyStateMachine StateMachine => _stateMachine;

    [Inject]
    private void Construct()
    {
        _playState = new PlayState(_pauseModel);
        _loseState = new LoseState(_pauseModel, _timeStopDelay);
        _winState = new WinState(_pauseModel, _timeStopDelay);

        _stateMachine = new StateMachine(_playState, _loseState, _winState);

        _stateMachine.ChangeState(_playState);
    }

    private void Awake()
    {
        _enemyFactory.win += OnKillAll;
        _player.dead += OnDead;
    }

    private void OnDestroy()
    {
        _enemyFactory.win -= OnKillAll;
        _player.dead -= OnDead;
    }

    private void OnDead()
    {
        SetState(_loseState).Forget();
    }

    private void OnKillAll()
    {
        SetState(_winState).Forget();
    }

    private async UniTask SetState(State state)
    {
        await UniTask.Delay(TimeSpan.FromSeconds(_stateChangeDelay));
        _stateMachine.ChangeState(state);
    }
}