using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tips : MonoBehaviour
{
    [SerializeField] GameObject _panel = default;
    bool _isTrue = false;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab) && !_isTrue)
        {
            _panel.SetActive(true);
            _isTrue = true;
        }
        else if (Input.GetKeyDown(KeyCode.Tab) && _isTrue)
        {
            _panel.SetActive(false);
            _isTrue = false;
        }
    }
}
