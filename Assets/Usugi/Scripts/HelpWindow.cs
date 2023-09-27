using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpWindow : MonoBehaviour
{
    [SerializeField] GameObject _window;

    private void Start()
    {
        _window.gameObject.SetActive(false);
    }

    private void Update()
    {
        _window.transform.SetAsLastSibling();
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ActiveWindow();
        }
    }

    public void ActiveWindow()
    {
            _window.gameObject.SetActive(!_window.activeInHierarchy);
    }
}
