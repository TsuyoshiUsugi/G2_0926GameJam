using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Cysharp.Threading.Tasks;

/// <summary>
/// 判定を受け取って、勝った方にWIN,Lose表示する
/// どんぶり表示
/// </summary>
public class ResultVIew : MonoBehaviour
{
    //各プレイヤーの食材リスト
    [SerializeField] List<Image> _p1Createfoods;   //ｐ１のできた食材リスト
    [SerializeField] List<Image> _p2Createfoods;   //ｐ２のできた食材リスト
    //食材置くオフセット
    [SerializeField] GameObject _canvas;
    /// <summary> 食材の幅 </summary>
    [SerializeField] float _foodUIDiff = 10;
    [SerializeField] float _p1Offset = -255;
    [SerializeField] float _p2Offset = 85;
    //各プレイヤーの結果を表示
    [SerializeField] Text _p1MessageText;
    [SerializeField] Text _p2MessageText;
    //リスタートボタン
    [SerializeField] Button _restartButton;

    private void Start()
    {
        _canvas.SetActive(false);
    }

    private void FieldInit()
    {
        _p1MessageText.gameObject.SetActive(false);
        _p2MessageText.gameObject.SetActive(false);
        _restartButton.onClick.AddListener(() => SceneManager.LoadScene(0));
        _restartButton.gameObject.SetActive(false);
    }

    /// <summary>
    /// 非同期でゲームの状態を遷移します
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async UniTask ResultRunAsync()
    {
        _canvas.SetActive(true);
        FieldInit();
        //各プレイヤーのドンブリの表示
        ShowFoodAsync(Player.Player1, _p1Createfoods).Forget();
        await ShowFoodAsync(Player.Player2, _p2Createfoods);
        await UniTask.Delay(System.TimeSpan.FromSeconds(1));
        await ShowResult();
        _restartButton.gameObject.SetActive(true);
        //Debug.Log("Prepare");
        //_currentGameState.Value = GameState.Prepare;
        //await StartCount();
        //Debug.Log("Start");
        //_currentGameState.Value = GameState.Start;
        //Debug.Log("Playing");
        //_currentGameState.Value = GameState.Playing;
        //Debug.Log("End");
        //_currentGameState.Value = GameState.End;
        //EndSequence();
    }

    private enum Player
    {
        Player1,
        Player2,
    }

    private async UniTask ShowFoodAsync(Player player, List<Image> foods)
    {
        for (int i = 0; i < foods.Count; i++)
        {
            await UniTask.Delay(System.TimeSpan.FromSeconds(0.5f));
            var obj = Instantiate(foods[i]);
            //// Imageの位置を設定
            float xPosition = i * _foodUIDiff;
            obj.transform.SetParent(_canvas.transform);
            if (player == Player.Player1)
            {
                obj.rectTransform.anchoredPosition = new Vector2(_p1Offset + xPosition, 3);
            }
            else
            {
                obj.rectTransform.anchoredPosition = new Vector2(_p2Offset + xPosition, 3);
            }
        }
    }

    private async UniTask ShowResult()
    {
        _p1MessageText.gameObject.SetActive(true);
        _p2MessageText.gameObject.SetActive(true);
        if (_p1Createfoods.Count < _p2Createfoods.Count)    //ｐ２の勝ち
        {
            _p1MessageText.text = "Lose";
            _p2MessageText.text = "Win";
        }
        else if (_p1Createfoods.Count == _p2Createfoods.Count)  //引き分け
        {
            _p1MessageText.text = "Draw";
            _p2MessageText.text = "Draw";
        }
        else    //ｐ１の勝ち
        {
            _p1MessageText.text = "Win";
            _p2MessageText.text = "Lose";
        }
    }
}
