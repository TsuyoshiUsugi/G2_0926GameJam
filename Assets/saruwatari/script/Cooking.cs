using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cooking : MonoBehaviour
{
    [SerializeField, Header("�o������ꏊ")]
    Vector3 pos;
    [SerializeField, Header("��")]
    GameObject _bowl;
    [SerializeField, Header("���͂�")]
    GameObject _rice;
    [SerializeField, Header("������")] List<GameObject> _guzaiList = new List<GameObject>();


    [SerializeField, Header("�ł������X�g")] public List<Image> _cookingList = new List<Image>();
    [SerializeField, Header("�ł���\��̃��X�g")] List<Image> _cookkedList = new List<Image>();

    [SerializeField, Header("���ł����ʒu")]
    Vector3 _vector;
    [SerializeField] Bowl _bow;

    GameObject _Object;
    
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Bowl()
    {
        _Object = Instantiate(_bowl, pos, Quaternion.identity);
    }

    public void Rice()
    {
       var obj = Instantiate(_rice);
        obj.transform.SetParent(_Object.transform);
    }

    public void Guzai()
    {
        int x = Random.Range(0, _guzaiList.Count);
        var obj = Instantiate(_guzaiList[x]);
        obj.transform.SetParent(_Object.transform);
        _cookingList.Add(_cookkedList[x]);
        _Object.GetComponent<Bowl>().Move(_vector);
    }
}