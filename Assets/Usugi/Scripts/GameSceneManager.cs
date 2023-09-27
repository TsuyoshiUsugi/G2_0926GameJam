using UnityEngine;
using UnityEngine.UI;
using Cysharp.Threading.Tasks;
using UniRx;
using System.Collections.Generic;

/// <summary>
/// ゲームシーンの管理を行う
/// </summary>
public class GameSceneManager : MonoBehaviour
{
    /// <summary> 現在のステートを管理する </summary>
    [SerializeField] ReactiveProperty<GameState> _currentGameState = new (GameState.Prepare);
    [SerializeField] Image _startCountImage;
    [SerializeField] List<Sprite> _startSprites;
    [SerializeField] ResultVIew _resultView;
    [SerializeField] P1Command _p1Command;
    [SerializeField] P2Command _p2Command;
    [SerializeField] GameObject _p1CommandObj;
    [SerializeField] GameObject _p2CommandObj;
    [SerializeField] AudioSource _bgm;
    TimeManager _timeManager;

    /// <summary> ステート一覧 </summary>
    public enum GameState
    {
        Prepare,
        Start,
        Playing,
        End,
    }
    private void Start()
    {
        InitField();
        GameRunAsync().Forget();
    }

    private void InitField()
    {
        _bgm.enabled = false;
        _timeManager = GetComponent<TimeManager>();
        _timeManager.enabled = false;
        _p1Command.enabled = false;
        _p2Command.enabled = false;
        _p1CommandObj.SetActive(false);
        _p2CommandObj.SetActive(false);
        _startCountImage.gameObject.SetActive(false);
    }

    /// <summary>
    /// 非同期でゲームの状態を遷移します
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    private async UniTask GameRunAsync()
    {
        Debug.Log("Prepare");
        _currentGameState.Value = GameState.Prepare;
        await UniTask.Delay(System.TimeSpan.FromSeconds(2));
        await StartCount();
        Debug.Log("Start");
        _currentGameState.Value = GameState.Start;
        _bgm.enabled = true;
        ActiveCommand();
        _timeManager.enabled = true;
        _currentGameState.Value = GameState.Playing;
        await UniTask.WaitUntil(() => TimeManager.CountDownTime <= 0);
        Debug.Log("End");
        _currentGameState.Value = GameState.End;
        _bgm.enabled = false;
        MusicManager.Instance.PlaySE(MusicManager.SEType.TimeUp);
        await DoBeforeEnd();
        EndSequence();
    }

    private async UniTask DoBeforeEnd()
    {
        _p1Command.enabled = false;
        _p2Command.enabled = false;
        _startCountImage.gameObject.SetActive(true);
        _startCountImage.sprite = _startSprites[4];
        await UniTask.Delay(System.TimeSpan.FromSeconds(3));
        _startCountImage.gameObject.SetActive(false);
    }

    private void ActiveCommand()
    {
        _p1Command.enabled = true;
        _p2Command.enabled = true;
        _p1CommandObj.SetActive(true);
        _p2CommandObj.SetActive(true);
    }

    /// <summary>
    /// スタート時のカウントを行う
    /// </summary>
    /// <returns></returns>
    private async UniTask StartCount()
    {
        _startCountImage.gameObject.SetActive(true);
        _startCountImage.sprite = _startSprites[3];
        MusicManager.Instance.PlaySE(MusicManager.SEType.StartCount);
        await UniTask.Delay(System.TimeSpan.FromSeconds(1));
        MusicManager.Instance.PlaySE(MusicManager.SEType.StartCount);
        _startCountImage.sprite = _startSprites[2];
        await UniTask.Delay(System.TimeSpan.FromSeconds(1));
        MusicManager.Instance.PlaySE(MusicManager.SEType.StartCount);
        _startCountImage.sprite = _startSprites[1];
        await UniTask.Delay(System.TimeSpan.FromSeconds(1));
        MusicManager.Instance.PlaySE(MusicManager.SEType.StartCount);
        _startCountImage.sprite = _startSprites[0];
        await UniTask.Delay(System.TimeSpan.FromSeconds(1));
        _startCountImage.gameObject.SetActive(false);
    }

    /// <summary>
    /// 終了時の処理を行う
    /// </summary>
    private void EndSequence()
    {
        MusicManager.Instance.PlaySE(MusicManager.SEType.ResultSe);

        _resultView.ResultRunAsync().Forget();
    }
}
