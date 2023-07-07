using UniRx;
using UniRx.Triggers;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] 
    private float _speed;

    [SerializeField]
    private Rigidbody2D _rb;

    [SerializeField]
    private GameManager _gameManager;
    private void Start()
    {
        this.UpdateAsObservable()
            .Subscribe(_ => Move())
            .AddTo(this);
    }


    private void Move()
    {
        if (_gameManager.PlayerType != GameManager.PlayerState.Action) return;
        
        var pos = transform.position;
        
        if (Input.GetKey(KeyCode.W))
            pos.y += _speed;
        
        if (Input.GetKey(KeyCode.A))
            pos.x -= _speed;
        
        if  (Input.GetKey(KeyCode.S))
            pos.y -= _speed;
        
        if  (Input.GetKey(KeyCode.D))
            pos.x += _speed;
        
        transform.position = pos;
    }
}
