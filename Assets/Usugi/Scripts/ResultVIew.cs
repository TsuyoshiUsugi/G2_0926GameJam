using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cysharp.Threading.Tasks;

/// <summary>
/// 判定を受け取って、勝った方にWIN,Lose表示する
/// どんぶり表示
/// </summary>
public class ResultVIew : MonoBehaviour
{
    [SerializeField] List<GameObject> _p1Createfoods;   //ｐ１のできた食材リスト
    [SerializeField] List<GameObject> _p2Createfoods;   //ｐ２のできた食材リスト
    [SerializeField] GameObject _p1UIOffset;    //ｐ１の配置するオフセット
    [SerializeField] GameObject _p2UIOffset;
    /// <summary> 食材の幅 </summary>
    [SerializeField] float _foodUIDiff = 1;
    [SerializeField] Text _p1MessageText;
    [SerializeField] Text _p2MessageText;

    private void Start()
    {
        FieldInit();
        ResultRunAsync().Forget();
    }

    private void FieldInit()
    {
        _p1MessageText.gameObject.SetActive(false);
        _p2MessageText.gameObject.SetActive(false);
    }

    /// <summary>
    /// 非同期でゲームの状態を遷移します
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    private async UniTask ResultRunAsync()
    {
        //各プレイヤーのドンブリの表示
        ShowFoodAsync(_p1UIOffset.transform.position, _p1Createfoods).Forget();
        await ShowFoodAsync(_p2UIOffset.transform.position, _p2Createfoods);
        await UniTask.Delay(System.TimeSpan.FromSeconds(1));
        ShowResult().Forget();
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

    private async UniTask ShowFoodAsync(Vector3 offset, List<GameObject> foods)
    {
        for (int i = 0; i < foods.Count; i++)
        {
            await UniTask.Delay(System.TimeSpan.FromSeconds(1));
            var obj = Instantiate(foods[i]);
            obj.transform.position = offset + new Vector3(_foodUIDiff * i, 0f, 0f);
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
