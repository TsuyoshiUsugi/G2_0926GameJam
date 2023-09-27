using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Cysharp.Threading.Tasks;
using DG.Tweening;

/// <summary>
/// ������󂯎���āA����������WIN,Lose�\������
/// �ǂ�Ԃ�\��
/// </summary>
public class ResultVIew : MonoBehaviour
{
    //�e�v���C���[�̐H�ރ��X�g
    [SerializeField] List<Image> _p1Createfoods;   //���P�̂ł����H�ރ��X�g
    [SerializeField] List<Image> _p2Createfoods;   //���Q�̂ł����H�ރ��X�g
    //�H�ޒu���I�t�Z�b�g
    [SerializeField] GameObject _canvas;
    /// <summary> �H�ނ̕� </summary>
    [SerializeField] float _foodUIDiff = 10;
    [SerializeField] float _p1Offset = -255;
    [SerializeField] float _p2Offset = 85;
    //�e�v���C���[�̌��ʂ�\��
    [SerializeField] Image _p1MessageText;
    [SerializeField] Image _p2MessageText;
    //���X�^�[�g�{�^��
    [SerializeField] Button _restartButton;
    [SerializeField] Cooking _p1cooking;
    [SerializeField] Cooking _p2cooking;
    //����������sprite
    [SerializeField] Sprite _win;
    [SerializeField] Sprite _lose;
    [SerializeField] Sprite _draw;
    private int _lineNum = 0;
    private int _foodLineLimit = 8; //��s�ɂǂꂾ���\������̂�
    private float _imageSize = 25;
    private float _foodImageStartPos = 54;

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
    /// �񓯊��ŃQ�[���̏�Ԃ�J�ڂ��܂�
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async UniTask ResultRunAsync()
    {
        _canvas.SetActive(true);
        FieldInit();
        //�e�v���C���[�̃h���u���̕\��
        SetScore();


        await ShowFoodAsync(Player.Player1, _p1Createfoods);
        await ShowFoodAsync(Player.Player2, _p2Createfoods);

        await UniTask.Delay(System.TimeSpan.FromSeconds(1));
        await ShowResult();
        _restartButton.gameObject.SetActive(true);
    }

    private void SetScore()
    {
        _p1Createfoods = _p1cooking._cookingList;
        _p2Createfoods = _p2cooking._cookingList;
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
            if (i != 0 && i % _foodLineLimit == 0)
            {
                _lineNum++;
            }

            var obj = Instantiate(foods[i]);
            //// Image�̈ʒu��ݒ�
            float xPosition = i % _foodLineLimit * _foodUIDiff;
            obj.transform.SetParent(_canvas.transform);
            if (player == Player.Player1)
            {
                obj.rectTransform.anchoredPosition = new Vector2(_p1Offset + xPosition, _foodImageStartPos - _lineNum * _imageSize);
            }
            else
            {
                obj.rectTransform.anchoredPosition = new Vector2(_p2Offset + xPosition, _foodImageStartPos - _lineNum * _imageSize);
            }
            await UniTask.Delay(System.TimeSpan.FromSeconds(0.1f));
        }
    }

    private async UniTask ShowResult()
    {
        _canvas.SetActive(true);
        _p1MessageText.gameObject.SetActive(true);
        _p2MessageText.gameObject.SetActive(true);
        _p1MessageText.transform.DOShakePosition(0.5f, 10f, 30, 1, false, true);
        _p2MessageText.transform.DOShakePosition(0.5f, 10f, 30, 1, false, true);
        if (_p1Createfoods.Count < _p2Createfoods.Count)    //���Q�̏���
        {
            _p1MessageText.sprite = _lose;
            _p2MessageText.sprite = _win;
        }
        else if (_p1Createfoods.Count == _p2Createfoods.Count)  //��������
        {
            _p1MessageText.sprite = _draw;
            _p2MessageText.sprite = _draw;
        }
        else    //���P�̏���
        {
            _p1MessageText.sprite = _win;
            _p2MessageText.sprite = _lose;
        }
    }
}
