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


    GameObject _Object;
    //�V���O���g���p�^�[���i�ȈՌ^�A�Ăяo�����j
    public static Cooking Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
    //�V���O���g���i�����܂Łj
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Bowl();
        Rice();
        Guzai();
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
    }
}