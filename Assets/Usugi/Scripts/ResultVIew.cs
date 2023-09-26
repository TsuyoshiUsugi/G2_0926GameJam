using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;

/// <summary>
/// 判定を受け取って、勝った方にWIN,Lose表示する
/// どんぶり表示
/// </summary>
public class ResultVIew : MonoBehaviour
{
    //何かのクラスの参照
    [SerializeField] List<GameObject> _p1Createfoods;
    [SerializeField] List<GameObject> _p2Createfoods;
    [SerializeField] GameObject _p1UIOffset;
    [SerializeField] GameObject _p2UIOffset;
    [SerializeField] float _foodUIDiff = 1;

    private void Start()
    {
        ResultRunAsync().Forget();
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
        ShowFoodAsync(_p2UIOffset.transform.position, _p2Createfoods).Forget();
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
        Debug.Log("dada");
        for (int i = 0; i < foods.Count; i++)
        {
            await UniTask.Delay(System.TimeSpan.FromSeconds(1));
            Instantiate(foods[i]);
            foods[i].transform.position = offset + new Vector3(_foodUIDiff * i, 0f, 0f);
        }
    }
}
