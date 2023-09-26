using UnityEngine;
using UnityEngine.UI;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine.SceneManagement;

/// <summary>
/// ゲームシーンの管理を行う
/// </summary>
public class GameSceneManager : MonoBehaviour
{
    /// <summary> 現在のステートを管理する </summary>
    [SerializeField] ReactiveProperty<GameState> _currentGameState = new (GameState.Prepare);
    [SerializeField] Text _startCountText;
    [SerializeField] ResultVIew _resultView;
    [SerializeField] P1Command _p1Command;
    [SerializeField] P2Command _p2Command;
    [SerializeField] GameObject _p1CommandObj;
    [SerializeField] GameObject _p2CommandObj;

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
        _p1Command.enabled = false;
        _p2Command.enabled = false;
        _p1CommandObj.SetActive(false);
        _p2CommandObj.SetActive(false);
        _startCountText.gameObject.SetActive(false);
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
        await StartCount();
        Debug.Log("Start");
        _currentGameState.Value = GameState.Start;
        ActiveCommand();
        Debug.Log("Playing");
        _currentGameState.Value = GameState.Playing;
        Debug.Log("End");
        _currentGameState.Value = GameState.End;
        EndSequence();
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
        _startCountText.gameObject.SetActive(true);
        _startCountText.text = "3";
        await UniTask.Delay(System.TimeSpan.FromSeconds(1));
        _startCountText.text = "2";
        await UniTask.Delay(System.TimeSpan.FromSeconds(1));
        _startCountText.text = "1";
        await UniTask.Delay(System.TimeSpan.FromSeconds(1));
        _startCountText.text = "Start";
        await UniTask.Delay(System.TimeSpan.FromSeconds(1));
        _startCountText.gameObject.SetActive(false);
    }

    /// <summary>
    /// 終了時の処理を行う
    /// </summary>
    private void EndSequence()
    { 
        _resultView.ResultRunAsync().Forget();
    }
}
