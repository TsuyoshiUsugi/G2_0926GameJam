using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneSwitch : MonoBehaviour
{
    //public Text p1Text;
    //public Text p2Text;

    public GameObject P1Image;
    public GameObject P2Image;

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
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D) && !p1)
        {
            Debug.Log("P1　True");
            p1 = true;
            //p1Text.text = "Ready";
            KeySE1.Play();
            P1Image.gameObject.SetActive(false);
            Ready1.gameObject.SetActive(true);

        }
        if(Input.GetKeyDown(KeyCode.K) || Input.GetKeyDown(KeyCode.I) || Input.GetKeyDown(KeyCode.J) || Input.GetKeyDown(KeyCode.L) && !p2)
        {
            Debug.Log("P2 True");
            p2 = true;
            //p2Text.text = "Ready";
            KeySE2.Play();
            P2Image.gameObject.SetActive(false);
            Ready2.gameObject.SetActive(true);


        }
        
        if(p1 == true && p2 == true  )
        {
            StartCoroutine(ScSw());
            //SceneManager.LoadScene("hiroto");
        }
        


        IEnumerator ScSw()
        {
            yield return new WaitForSeconds(0.5f);
            StartText.gameObject.SetActive(true);
            yield return new WaitForSeconds(seconds);
            SceneManager.LoadScene(1);
        }

        // ２つのボタンを押されてtureになったらシーンを切り替える
        // Ready
    }

}
