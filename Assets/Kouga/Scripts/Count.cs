using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //�ǉ�

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
        count++; //�C���N�������g�F�l���P���₷
        if (count == 3)
        {
            count = 0;
            UIcount++;
            BtnCount.text = UIcount.ToString();
        }
    }
}