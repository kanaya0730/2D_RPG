using System.Collections.Generic;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using Image = UnityEngine.UI.Image;

public class Command : MonoBehaviour
{
    [SerializeField] 
    private List<Image> _images = new();
    
    [SerializeField]
    private int _num;
    
    [SerializeField]
    private GameManager _gameManager;
    private void Start()
    {
        foreach (var t in _images)
        {
            t.gameObject.SetActive(false);
        }

        this.UpdateAsObservable()
            .Subscribe(_ => SelectCommand())
            .AddTo(this);
    }

    private void SelectCommand()
    {
        if (_gameManager.PlayerType != GameManager.PlayerState.Command)
        {
            foreach (var t in _images)
            {
                t.gameObject.SetActive(false);
            }
            return;
        }
        
        if (Input.GetKeyDown(KeyCode.A)) 
            _num--;

        if (Input.GetKeyDown(KeyCode.D)) 
            _num++;
        
        if (Input.GetKeyDown(KeyCode.Space))
            PlayCommand(_num);

        if (_num <= 0)
            _num = 0;

        if (_num >= _images.Count)
            _num = _images.Count - 1;
        
        for (var i = 0; i < _images.Count; i++)
        {
            if (i == _num) _images[_num].gameObject.SetActive(true);
            else _images[i].gameObject.SetActive(false);
        }
    }

    private void PlayCommand(int num)
    {
        switch (num)
        {
            case 0:
                Debug.Log("たたかう");
                break;
            case 1:
                Debug.Log("こうどう");
                break;
            case 2:
                Debug.Log("アイテム");
                break;
            case 3:
                Debug.Log("みのがす");
                break;
            default:
                Debug.Log("範囲外");
                break;
        }
        
        _gameManager.ChangePlayerType(GameManager.PlayerState.Command);
    }
}
