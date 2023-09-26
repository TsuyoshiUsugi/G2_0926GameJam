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
    //[SerializeField] public GameObject _dish = default;
    //[SerializeField] public GameObject _rice = default;
    //[SerializeField] public GameObject _ingredients = default;
    //ゲームオブジェクト用変数
    [SerializeField] public int _p2Count;
    List<KeyCode> _p2CommandList = new();
    KeyCode[] _p2Command = new[] { KeyCode.I, KeyCode.J, KeyCode.K, KeyCode.L };
    private void Start()
    {
        OrderCommand();
    }
    private void CheckCommand()
    {
        if (Input.anyKeyDown)
        {
            string GetKey = Input.inputString;
            Debug.Log(GetKey);
            if (GetKey.ToUpper() == _p2CommandList[0].ToString())
            {
                _p2CommandList.RemoveAt(0);
                IslastCommand();
            }
        }
    }

    private void IslastCommand()
    {
        if (_p2CommandList.Count <= 0)
        {
            _p2Count += 1;
            _p2Score.text = _p2Count.ToString();
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
    }
}
