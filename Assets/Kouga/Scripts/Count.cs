using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //追加

public class Count : MonoBehaviour
{
    [SerializeField] public Text BtnCount;
    private int count;
    private int UIcount;

    void Start()
    {
        count = 0;
    }

    public void CountBtn()
    {
        count++; //インクリメント：値を１増やす
        if (count == 3)
        {
            count = 0;
            UIcount++;
            BtnCount.text = UIcount.ToString();
        }
    }
}