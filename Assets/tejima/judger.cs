using System;
using UnityEngine;
using UnityEngine.UI;

public class judger : MonoBehaviour
{
    // Start is called before the first frame update
    public judgetext Winer = judgetext.None;
    [SerializeField] Text _p1Score;
    [SerializeField] Text _p2Score;
    void Start()
    {
        _p1Score = GetComponent<Text>();
        _p2Score = GetComponent<Text>();
        _p1Score.text.ToString();
        _p2Score.text.ToString();
        int n1 = int.Parse(_p1Score.text);
        int n2 = int.Parse(_p2Score.text);

        if (n1 > n2)
        {
            Winer = judgetext.player1;
        }
        else if (n1 < n2)
        {
            Winer = judgetext.player2;
        }
        else if (n1 == n2)
        {
            Winer = judgetext.draw;
        }

    }
    public enum judgetext
    {
        player1,
        player2,
        draw,
        None
    }
}
