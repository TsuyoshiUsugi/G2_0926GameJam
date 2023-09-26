using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneSwitch : MonoBehaviour
{
    public Text p1Text;
    public Text p2Text;

   
    public int seconds = 3;

    private bool p1 = false;
    private bool p2 = false;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("P1　True");
            p1 = true;
            p1Text.text = "Ready";
            
        }
        if(Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            Debug.Log("P2 True");
            p2 = true;
            p2Text.text = "Ready";
            
        }
        if(p1 == true && p2 == true  )
        {
            StartCoroutine(ScSw());
            //SceneManager.LoadScene("hiroto");
        }

        IEnumerator ScSw()
        {
            yield return new WaitForSeconds(seconds);
            SceneManager.LoadScene("hiroto");
        }

        // ２つのボタンを押されてtureになったらシーンを切り替える
        // Ready
    }

}
