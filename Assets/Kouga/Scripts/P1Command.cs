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
    //[SerializeField] public GameObject _dish = default;
    //[SerializeField] public GameObject _rice = default;
    //[SerializeField] public GameObject _ingredients = default;
    //�Q�[���I�u�W�F�N�g�p�ϐ�
    [SerializeField] Cooking _cooking;
    [SerializeField] public int _p1Count;
    List<KeyCode> _p1CommandList = new();
    KeyCode[] _p1Command = new[] {KeyCode.W, KeyCode.A, KeyCode.S, KeyCode.D};
    private void Start()
    {
        OrderCommand();
    }
    private void CheckCommand()
    {
        if (Input.anyKeyDown)
        {
            string GetKey = Input.inputString;
            if(GetKey.ToUpper() == _p1CommandList[0].ToString())
            {
                if (_p1CommandList.Count == 3)
                {
                    _cooking.Bowl();
                }
                else if (_p1CommandList.Count == 2)
                {
                    _cooking.Rice();
                }
                else if (_p1CommandList.Count == 1)
                {
                    _cooking.Guzai();
                }
                _p1CommandList.RemoveAt(0);
                IslastCommand();
            }
        }
    }

    private void IslastCommand()
    {
        if (_p1CommandList.Count <= 0)
        {
            _p1Count += 1;
            _p1Score.text = $"�~{_p1Count:00}";
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
    }
}
