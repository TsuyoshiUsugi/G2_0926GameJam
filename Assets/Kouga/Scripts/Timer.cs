using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField]
    Text _text = default;
    [SerializeField]
    float _timer = default;

    void Update()
    {
        _timer -= Time.deltaTime;
        _text.text = $"TIME : {_timer.ToString("f2")}";
    }
}
