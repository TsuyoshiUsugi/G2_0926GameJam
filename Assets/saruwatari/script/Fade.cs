using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Fade : MonoBehaviour
{
    [SerializeField,Header("フェードインにかかる時間")] float fadeIn_time;
    [SerializeField, Header("ループ回数(フェードイン)")] float fadeInloop_count;

    [SerializeField, Header("フェードアウトにかかる時間")] float fadeOut_time;
    [SerializeField, Header("ループ回数(フェードアウト)")] float fadeOutloop_count;

    [SerializeField, Header("移動するシーンのの番号")] int sceneNumber;

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
        // 画面をフェードインさせるコールチン
        // 前提：画面を覆うPanelにアタッチしている

        // 色を変えるゲームオブジェクトからImageコンポーネントを取得
        Image fade = GetComponent<Image>();

        // フェード元の色を設定（黒）★変更可
        fade.color = new Color((0.0f / 255.0f), (0.0f / 255.0f), (0.0f / 0.0f), (255.0f / 255.0f));

        // フェードインにかかる時間（秒）★変更可
        //const float fade_time = 2.0f;

        // ループ回数（0はエラー）★変更可
        //const int loop_count = 10;

        // ウェイト時間算出
        float wait_time = fadeIn_time / fadeInloop_count;

        // 色の間隔を算出
        float alpha_interval = 255.0f / fadeInloop_count;

        // 色を徐々に変えるループ
        for (float alpha = 255.0f; alpha >= 0.0f; alpha -= alpha_interval)
        {
            // 待ち時間
            yield return new WaitForSeconds(wait_time);

            // Alpha値を少しずつ下げる
            Color new_color = fade.color;
            new_color.a = alpha / 255.0f;
            fade.color = new_color;
        }
    }

    public IEnumerator Color_FadeOut()
    {
        // 画面をフェードインさせるコールチン
        // 前提：画面を覆うPanelにアタッチしている

        // 色を変えるゲームオブジェクトからImageコンポーネントを取得
        Image fade = GetComponent<Image>();

        // フェード後の色を設定（黒）★変更可
        fade.color = new Color((0.0f / 255.0f), (0.0f / 255.0f), (0.0f / 0.0f), (0.0f / 255.0f));

        // フェードインにかかる時間（秒）★変更可
        //const float fade_time = 2.0f;

        // ループ回数（0はエラー）★変更可
        //const int loop_count = 10;

        // ウェイト時間算出
        float wait_time = fadeOut_time / fadeOutloop_count;

        // 色の間隔を算出
        float alpha_interval = 255.0f / fadeOutloop_count;

        // 色を徐々に変えるループ
        for (float alpha = 0.0f; alpha <= 255.0f; alpha += alpha_interval)
        {
            // 待ち時間
            yield return new WaitForSeconds(wait_time);

            // Alpha値を少しずつ上げる
            Color new_color = fade.color;
            new_color.a = alpha / 255.0f;
            fade.color = new_color;
        }
        SceneManager.LoadScene(scenNumber);
    }
}
