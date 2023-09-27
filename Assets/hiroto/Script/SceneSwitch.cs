using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneSwitch : MonoBehaviour
{
    //public Text p1Text;
    //public Text p2Text;
    [SerializeField] Fade _fade;
    [SerializeField] int Nuber;
    [SerializeField,Header("30")] int _scenNuber;
    [SerializeField, Header("60")] int _scenNuber2;

    public GameObject P1_30sImage;
    public GameObject P2_30sImage;
    public GameObject P1_60sImage;
    public GameObject P2_60sImage;

    public int seconds = 3;

    private bool p1 = false;
    private bool p2 = false;

    public AudioSource KeySE1;
    public AudioSource KeySE2;

    public GameObject StartText;

    public GameObject Ready1;
    public GameObject Ready2;

    private void Start()
    {
        KeySE1 = GetComponent<AudioSource>();
        KeySE2 = GetComponent<AudioSource>();

        
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) && !p1)
        {
            Debug.Log("30sP1　True");
            p1 = true;
            //p1Text.text = "Ready";
            KeySE1.Play();
            P1_30sImage.gameObject.SetActive(false);
            Ready1.gameObject.SetActive(true);
            Nuber = _scenNuber;
        }
        if(Input.GetKeyDown(KeyCode.J) && !p2)
        {
            Debug.Log("30sP2 True");
            p2 = true;
            //p2Text.text = "Ready";
            KeySE2.Play();
            P2_30sImage.gameObject.SetActive(false);
            Ready2.gameObject.SetActive(true);
            Nuber = _scenNuber;
        }
        if (Input.GetKeyDown(KeyCode.D) && !p1)
        {
            Debug.Log("60sP1　True");
            p1 = true;
            //p1Text.text = "Ready";
            KeySE1.Play();
            P1_60sImage.gameObject.SetActive(false);
            Ready1.gameObject.SetActive(true);
            Nuber = _scenNuber2;
        }
        if (Input.GetKeyDown(KeyCode.L) && !p2)
        {
            Debug.Log("30sP2 True");
            p2 = true;
            //p2Text.text = "Ready";
            KeySE2.Play();
            P2_60sImage.gameObject.SetActive(false);
            Ready2.gameObject.SetActive(true);
            Nuber = _scenNuber2;
        }
        if (p1 == true && p2 == true  )
        {
            StartCoroutine(ScSw());
            //SceneManager.LoadScene("hiroto");
            P1_30sImage.gameObject.SetActive(false);
            P2_30sImage.gameObject.SetActive(false);
            P1_60sImage.gameObject.SetActive(false);
            P2_60sImage.gameObject.SetActive(false);
        }

        IEnumerator ScSw()
        {
            Debug.Log(Nuber);
            yield return new WaitForSeconds(0.5f);
            StartText.gameObject.SetActive(true);
            yield return new WaitForSeconds(seconds);

            _fade.StartCoroutine(nameof(_fade.FadeOut), Nuber);
            //SceneManager.LoadScene(1);
        }

        // ２つのボタンを押されてtureになったらシーンを切り替える
        // Ready
    }

}
