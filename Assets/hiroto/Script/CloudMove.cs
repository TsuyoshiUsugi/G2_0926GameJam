using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CloudMove : MonoBehaviour
{
    [SerializeField]
    RectTransform _target = default;
    [SerializeField]
    float _animTime = 0f;
    [SerializeField]
    float _moveValue = 0f;

    public void MoveCloud()
    {
        _target.DOAnchorPosX(_target.localPosition.x - _moveValue, _animTime)
            .OnComplete(() => Destroy(this.gameObject));
    }
}
