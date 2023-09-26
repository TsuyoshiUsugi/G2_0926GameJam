using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{ 
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            Debug.Log("‰Ÿ‚³‚ê‚Ä‚¢‚é");
            SceneManager.LoadScene("hiroto");
        }
    }
}
