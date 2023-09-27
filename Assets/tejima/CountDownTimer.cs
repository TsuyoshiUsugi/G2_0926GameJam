using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    public static float CountDownTime;    // �J�E���g�_�E���^�C��
    public Text TextCountDown;              // �\���p�e�L�X�gUI
    [SerializeField] public float _timersnumber = 50;
    public float TimersNumber => _timersnumber;
    public AudioClip sound;
    AudioSource audioSource;

    // Use this for initialization
    void Start()
    {
        CountDownTime = _timersnumber;    // �ΐl��p�̃^�C�}�[
        audioSource = GetComponent<AudioSource>();
        InvokeRepeating("RepeatMsg",0f,1f);
    }

    // Update is called once per frame
    void Update()
    {
        TextCountDown.text = String.Format("{0:00}", CountDownTime);// �J�E���g�_�E���^�C���𐮌`���ĕ\��
        CountDownTime -= Time.deltaTime;// �o�ߎ����������Ă���

        if (CountDownTime <= 0.0F) // 0.0�b�ȉ��ɂȂ�����J�E���g�_�E���^�C����0.0�ŌŒ�i�~�܂����悤�Ɍ�����j
        {
            CountDownTime = 0.0F;
        }
        if (CountDownTime == 0)//�^�C���I�[�o�[���Aresult��ʂɔ�΂��B
        {
            //SceneManager.LoadScene("result", LoadSceneMode.Single);
        }
    }
    void RepeatMsg()
    {
        audioSource.PlayOneShot(sound);
    }
}