using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cysharp.Threading.Tasks;

/// <summary>
/// ������󂯎���āA����������WIN,Lose�\������
/// �ǂ�Ԃ�\��
/// </summary>
public class ResultVIew : MonoBehaviour
{
    [SerializeField] List<GameObject> _p1Createfoods;   //���P�̂ł����H�ރ��X�g
    [SerializeField] List<GameObject> _p2Createfoods;   //���Q�̂ł����H�ރ��X�g
    [SerializeField] GameObject _p1UIOffset;    //���P�̔z�u����I�t�Z�b�g
    [SerializeField] GameObject _p2UIOffset;
    /// <summary> �H�ނ̕� </summary>
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
    /// �񓯊��ŃQ�[���̏�Ԃ�J�ڂ��܂�
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    private async UniTask ResultRunAsync()
    {
        //�e�v���C���[�̃h���u���̕\��
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
        if (_p1Createfoods.Count < _p2Createfoods.Count)    //���Q�̏���
        {
            _p1MessageText.text = "Lose";
            _p2MessageText.text = "Win";
        }
        else if (_p1Createfoods.Count == _p2Createfoods.Count)  //��������
        {
            _p1MessageText.text = "Draw";
            _p2MessageText.text = "Draw";
        }
        else    //���P�̏���
        {
            _p1MessageText.text = "Win";
            _p2MessageText.text = "Lose";

        }
    }
}
