using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    public static float CountDownTime;    // �J�E���g�_�E���^�C��
    public Text TextCountDown;              // �\���p�e�L�X�gUI
    [SerializeField] float Timersnumber = 50;

    // Use this for initialization
    void Start()
    {
        CountDownTime = Timersnumber;    // �ΐl��p�̃^�C�}�[
    }

    // Update is called once per frame
    void Update()
    {
        TextCountDown.text = String.Format("Time: {0:00}", CountDownTime);// �J�E���g�_�E���^�C���𐮌`���ĕ\��
        CountDownTime -= Time.deltaTime;// �o�ߎ����������Ă���

        if (CountDownTime <= 0.0F) // 0.0�b�ȉ��ɂȂ�����J�E���g�_�E���^�C����0.0�ŌŒ�i�~�܂����悤�Ɍ�����j
        {
            CountDownTime = 0.0F;
        }
        if (CountDownTime == 0)//�^�C���I�[�o�[���Aresult��ʂɔ�΂��B
        {
            SceneManager.LoadScene("result", LoadSceneMode.Single);
        }

    }
}