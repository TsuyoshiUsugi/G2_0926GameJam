using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Bowl : MonoBehaviour
{


    public int X;
    
    public void Move()
    {
        this.transform.DOMove(new Vector3(0f, X, 0f), 3f);
        Destroy(this.gameObject,3f);
    }
}
