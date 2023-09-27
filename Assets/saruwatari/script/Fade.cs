using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;
using Cysharp.Threading.Tasks;
using System.Threading.Tasks;

public class Fade : MonoBehaviour
{
    [SerializeField, Header("Image")]
    Image _image;
    [SerializeField, Header("フェイドインする時間")]
    float _fadeInTime;
    [SerializeField, Header("フェイドアウトする時間")]
    float _fadeOutTime;

    // Start is called before the first frame update
    void Start()
    {
        FadeIn();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void FadeIn()
    {
        _image.DOFade(0f, _fadeInTime);
    }

    public void FadeOut(int sceneNum)
    {
        _image.DOFade(1f, _fadeInTime).OnComplete(() => SceneManager.LoadScene(sceneNum));
        //await _image.DOFade(1f, _fadeInTime).AsyncWaitForCompletion();
        //SceneManager.LoadScene(sceneNum);
    }
}
