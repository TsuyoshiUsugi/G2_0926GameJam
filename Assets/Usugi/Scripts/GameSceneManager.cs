using UnityEngine;
using UnityEngine.UI;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine.SceneManagement;

/// <summary>
/// �Q�[���V�[���̊Ǘ����s��
/// </summary>
public class GameSceneManager : MonoBehaviour
{
    /// <summary> ���݂̃X�e�[�g���Ǘ����� </summary>
    [SerializeField] ReactiveProperty<GameState> _currentGameState = new (GameState.Prepare);
    [SerializeField] Text _startCountText;
    [SerializeField] ResultVIew _resultVIew;

    /// <summary> �X�e�[�g�ꗗ </summary>
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
        _startCountText.gameObject.SetActive(false);
    }

    /// <summary>
    /// �񓯊��ŃQ�[���̏�Ԃ�J�ڂ��܂�
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
        Debug.Log("Playing");
        _currentGameState.Value = GameState.Playing;
        Debug.Log("End");
        _currentGameState.Value = GameState.End;
        EndSequence();
    }

    /// <summary>
    /// �X�^�[�g���̃J�E���g���s��
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
    /// �I�����̏������s��
    /// </summary>
    private void EndSequence()
    { 
        _resultVIew.ResultRunAsync().Forget();
    }
}
