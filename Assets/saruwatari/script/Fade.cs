using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Fade : MonoBehaviour
{
    [SerializeField,Header("�t�F�[�h�C���ɂ����鎞��")] float fadeIn_time;
    [SerializeField, Header("���[�v��(�t�F�[�h�C��)")] float fadeInloop_count;

    [SerializeField, Header("�t�F�[�h�A�E�g�ɂ����鎞��")] float fadeOut_time;
    [SerializeField, Header("���[�v��(�t�F�[�h�A�E�g)")] float fadeOutloop_count;

    [SerializeField, Header("�ړ�����V�[���̂̔ԍ�")] int sceneNumber;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator Color_FadeIn()
    {
        // ��ʂ��t�F�[�h�C��������R�[���`��
        // �O��F��ʂ𕢂�Panel�ɃA�^�b�`���Ă���

        // �F��ς���Q�[���I�u�W�F�N�g����Image�R���|�[�l���g���擾
        Image fade = GetComponent<Image>();

        // �t�F�[�h���̐F��ݒ�i���j���ύX��
        fade.color = new Color((0.0f / 255.0f), (0.0f / 255.0f), (0.0f / 0.0f), (255.0f / 255.0f));

        // �t�F�[�h�C���ɂ����鎞�ԁi�b�j���ύX��
        //const float fade_time = 2.0f;

        // ���[�v�񐔁i0�̓G���[�j���ύX��
        //const int loop_count = 10;

        // �E�F�C�g���ԎZ�o
        float wait_time = fadeIn_time / fadeInloop_count;

        // �F�̊Ԋu���Z�o
        float alpha_interval = 255.0f / fadeInloop_count;

        // �F�����X�ɕς��郋�[�v
        for (float alpha = 255.0f; alpha >= 0.0f; alpha -= alpha_interval)
        {
            // �҂�����
            yield return new WaitForSeconds(wait_time);

            // Alpha�l��������������
            Color new_color = fade.color;
            new_color.a = alpha / 255.0f;
            fade.color = new_color;
        }
    }

    public IEnumerator Color_FadeOut()
    {
        // ��ʂ��t�F�[�h�C��������R�[���`��
        // �O��F��ʂ𕢂�Panel�ɃA�^�b�`���Ă���

        // �F��ς���Q�[���I�u�W�F�N�g����Image�R���|�[�l���g���擾
        Image fade = GetComponent<Image>();

        // �t�F�[�h��̐F��ݒ�i���j���ύX��
        fade.color = new Color((0.0f / 255.0f), (0.0f / 255.0f), (0.0f / 0.0f), (0.0f / 255.0f));

        // �t�F�[�h�C���ɂ����鎞�ԁi�b�j���ύX��
        //const float fade_time = 2.0f;

        // ���[�v�񐔁i0�̓G���[�j���ύX��
        //const int loop_count = 10;

        // �E�F�C�g���ԎZ�o
        float wait_time = fadeOut_time / fadeOutloop_count;

        // �F�̊Ԋu���Z�o
        float alpha_interval = 255.0f / fadeOutloop_count;

        // �F�����X�ɕς��郋�[�v
        for (float alpha = 0.0f; alpha <= 255.0f; alpha += alpha_interval)
        {
            // �҂�����
            yield return new WaitForSeconds(wait_time);

            // Alpha�l���������グ��
            Color new_color = fade.color;
            new_color.a = alpha / 255.0f;
            fade.color = new_color;
        }
        SceneManager.LoadScene(scenNumber);
    }
}
