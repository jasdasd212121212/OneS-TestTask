using UnityEngine;

public class GameStateUiView : MonoBehaviour
{
    [SerializeField] private GameStateMachine _stateMachine;

    [Space]

    [SerializeField] private RectTransform _losePanel;
    [SerializeField] private RectTransform _winPanel;

    private void Start()
    {
        _stateMachine.StateMachine.GetState<LoseState>().entered += OnLose;
        _stateMachine.StateMachine.GetState<WinState>().entered += OnWin;   
    }

    private void OnDestroy()
    {
        _stateMachine.StateMachine.GetState<LoseState>().entered -= OnLose;
        _stateMachine.StateMachine.GetState<WinState>().entered -= OnWin;
    }

    private void OnLose()
    {
        _losePanel.gameObject.SetActive(true);
        _winPanel.gameObject.SetActive(false);
    }

    private void OnWin()
    {
        _losePanel.gameObject.SetActive(false);
        _winPanel.gameObject.SetActive(true);
    }
}