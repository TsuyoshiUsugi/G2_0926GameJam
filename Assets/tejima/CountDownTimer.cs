using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    public static float CountDownTime;    // カウントダウンタイム
    public Text TextCountDown;              // 表示用テキストUI
    [SerializeField] float Timersnumber = 50;

    // Use this for initialization
    void Start()
    {
        CountDownTime = Timersnumber;    // 対人戦用のタイマー
    }

    // Update is called once per frame
    void Update()
    {
        TextCountDown.text = String.Format("Time: {0:00}", CountDownTime);// カウントダウンタイムを整形して表示
        CountDownTime -= Time.deltaTime;// 経過時刻を引いていく

        if (CountDownTime <= 0.0F) // 0.0秒以下になったらカウントダウンタイムを0.0で固定（止まったように見せる）
        {
            CountDownTime = 0.0F;
        }
        if (CountDownTime == 0)//タイムオーバー時、result画面に飛ばす。
        {
            SceneManager.LoadScene("result", LoadSceneMode.Single);
        }

    }
}