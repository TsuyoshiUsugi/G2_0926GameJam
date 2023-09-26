using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cooking : MonoBehaviour
{
    [SerializeField, Header("出現する場所")]
    Vector3 pos;
    [SerializeField, Header("丼")]
    GameObject _bowl;
    [SerializeField, Header("ごはん")]
    GameObject _rice;
    [SerializeField, Header("あたま")] List<GameObject> _guzaiList = new List<GameObject>();


    [SerializeField, Header("できたリスト")] public List<Image> _cookingList = new List<Image>();
    [SerializeField, Header("できる予定のリスト")] List<Image> _cookkedList = new List<Image>();


    GameObject _Object;
    //シングルトンパターン（簡易型、呼び出される）
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
    //シングルトン（ここまで）
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