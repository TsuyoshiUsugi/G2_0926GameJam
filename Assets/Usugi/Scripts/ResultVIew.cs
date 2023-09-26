using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;

/// <summary>
/// ������󂯎���āA����������WIN,Lose�\������
/// �ǂ�Ԃ�\��
/// </summary>
public class ResultVIew : MonoBehaviour
{
    //�����̃N���X�̎Q��
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
    /// �񓯊��ŃQ�[���̏�Ԃ�J�ڂ��܂�
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    private async UniTask ResultRunAsync()
    {
        //�e�v���C���[�̃h���u���̕\��
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
