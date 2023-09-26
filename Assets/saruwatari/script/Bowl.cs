using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Bowl : MonoBehaviour
{
    
    public void Move(Vector3 pos)
    {
        this.transform.DOMove(pos, 3f);
        Destroy(this.gameObject,3f);
    }
}
