using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class P1Command : MonoBehaviour
{
    [SerializeField] public Text _p1Score;
    [SerializeField] public Text _p1Command1Text;
    [SerializeField] public Text _p1Command2Text;
    [SerializeField] public Text _p1Command3Text;
    [SerializeField] public GameObject _command1Back;
    [SerializeField] public GameObject _command2Back;
    [SerializeField] public GameObject _command3Back;
    //[SerializeField] public GameObject _dish = default;
    //[SerializeField] public GameObject _rice = default;
    //[SerializeField] public GameObject _ingredients = default;
    //ゲームオブジェクト用変数
    [SerializeField] Cooking _cooking;
    [SerializeField] public int _p1Count;
    List<KeyCode> _p1CommandList = new();
    KeyCode[] _p1Command = new[] {KeyCode.W, KeyCode.A, KeyCode.S, KeyCode.D, KeyCode.Q, KeyCode.E};
    private void Start()
    {
        OrderCommand();
        _p1Command1Text.color = Color.red;
        _p1Command2Text.color = Color.red;
        _p1Command3Text.color = Color.red;
    }
    private void CheckCommand()
    {
        if (Input.anyKeyDown)
        {
            string GetKey = Input.inputString;
            if(GetKey.ToUpper() == _p1CommandList[0].ToString())
            {
                MusicManager.Instance.PlaySE(MusicManager.SEType.CommnadTap);
                if (_p1CommandList.Count == 3)
                {
                    _command1Back.SetActive(true);
                    _cooking.Bowl();
                    MusicManager.Instance.PlaySE(MusicManager.SEType.PutCup);
                }
                else if (_p1CommandList.Count == 2)
                {
                    _command2Back.SetActive(true);
                    _cooking.Rice();
                }
                else if (_p1CommandList.Count == 1)
                {
                    _command3Back.SetActive(true);
                    _cooking.Guzai();
                }
                _p1CommandList.RemoveAt(0);
                IslastCommand();
            }
            else
            {
                MusicManager.Instance.PlaySE(MusicManager.SEType.Miss);
            }
        }
    }

    private void IslastCommand()
    {
        if (_p1CommandList.Count <= 0)
        {
            _p1Count += 1;
            _p1Score.text = $"×{_p1Count:00}";
            OrderCommand();
        }
    }

    private void Update()
    {
        CheckCommand();
    }
    private void OrderCommand()
    {
        KeyCode _p1Command1 = _p1Command[Random.Range(0, _p1Command.Length)];
        KeyCode _p1Command2 = _p1Command[Random.Range(0, _p1Command.Length)];
        KeyCode _p1Command3 = _p1Command[Random.Range(0, _p1Command.Length)];
        _p1Command1Text.text = _p1Command1.ToString();
        _p1Command2Text.text = _p1Command2.ToString();
        _p1Command3Text.text = _p1Command3.ToString();
        _p1CommandList.Add(_p1Command1);
        _p1CommandList.Add(_p1Command2);
        _p1CommandList.Add(_p1Command3);
        _command1Back.SetActive(false);
        _command2Back.SetActive(false);
        _command3Back.SetActive(false);
    }
}
