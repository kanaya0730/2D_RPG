using UniRx;
using UniRx.Triggers;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PlayerState PlayerType => _playerState;

    public enum PlayerState
    {
        Action,
        Command,
    }

    [SerializeField]
    private PlayerState _playerState;
    
    private void Start()
    {
        this.UpdateAsObservable()
            .Subscribe(_ => Test())
            .AddTo(this);
    }

    private void Test()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            ChangePlayerType(_playerState);
        }
    }

    /// <summary>ステートを変更</summary>
    /// <param name="type">このステートに変更</param>
    public void ChangePlayerType(PlayerState type)
    {
        _playerState = type == PlayerState.Action ? PlayerState.Command : PlayerState.Action;
        Debug.Log($"{_playerState}に変更");
    }
}
