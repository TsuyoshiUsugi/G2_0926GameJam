using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class P2Command : MonoBehaviour
{
    [SerializeField] public Text _p2Score;
    [SerializeField] public Text _p2Command1Text;
    [SerializeField] public Text _p2Command2Text;
    [SerializeField] public Text _p2Command3Text;
    [SerializeField] public GameObject _command1Dark;
    [SerializeField] public GameObject _command2Dark;
    [SerializeField] public GameObject _command3Dark;
    [SerializeField] TimeManager timeManager;
    //[SerializeField] public GameObject _dish = default;
    //[SerializeField] public GameObject _rice = default;
    //[SerializeField] public GameObject _ingredients = default;
    //ゲームオブジェクト用変数
    [SerializeField] Cooking _cooking;
    [SerializeField] public int _p2Count;
    [SerializeField] public int _endTimer;
    List<KeyCode> _p2CommandList = new();
    KeyCode[] _p2Command = new[] { KeyCode.I, KeyCode.J, KeyCode.K, KeyCode.L, KeyCode.U, KeyCode.O};
    private void Start()
    {
        OrderCommand();
        _p2Command1Text.color = Color.blue;
        _p2Command2Text.color = Color.blue;
        _p2Command3Text.color = Color.blue;
    }
    private void CheckCommand()
    {
        if (Input.anyKeyDown)
        {
            string GetKey = Input.inputString;
            Debug.Log(GetKey);
            if (GetKey.ToUpper() == _p2CommandList[0].ToString())
            {
                MusicManager.Instance.PlaySE(MusicManager.SEType.CommnadTap);
                if (_p2CommandList.Count == 3)
                {
                    _command1Dark.SetActive(true);
                    _cooking.Bowl();
                    MusicManager.Instance.PlaySE(MusicManager.SEType.PutCup);
                }
                else if (_p2CommandList.Count == 2)
                {
                    _command2Dark.SetActive(true);
                    _cooking.Rice();
                }
                else if (_p2CommandList.Count == 1)
                {
                    _command3Dark.SetActive(true);
                    _cooking.Guzai();
                }
                _p2CommandList.RemoveAt(0);
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
        if (_p2CommandList.Count <= 0)
        {
            _p2Count += 1;
            if (timeManager._timersnumber > _endTimer)
            {
                _p2Score.text = $"×{_p2Count:00}";
            }
            else if (timeManager._timersnumber <= _endTimer)
            {
                _p2Score.text = $"× ??";
            }
            OrderCommand();
        }
    }

    private void Update()
    {
        CheckCommand();
    }
    private void OrderCommand()
    {
        KeyCode _p2Command1 = _p2Command[Random.Range(0, _p2Command.Length)];
        KeyCode _p2Command2 = _p2Command[Random.Range(0, _p2Command.Length)];
        KeyCode _p2Command3 = _p2Command[Random.Range(0, _p2Command.Length)];
        _p2Command1Text.text = _p2Command1.ToString();
        _p2Command2Text.text = _p2Command2.ToString();
        _p2Command3Text.text = _p2Command3.ToString();
        _p2CommandList.Add(_p2Command1);
        _p2CommandList.Add(_p2Command2);
        _p2CommandList.Add(_p2Command3);
        _command1Dark.SetActive(false);
        _command2Dark.SetActive(false);
        _command3Dark.SetActive(false);
    }
}
