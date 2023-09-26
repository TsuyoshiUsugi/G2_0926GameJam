using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Bowl : MonoBehaviour
{


    public int X;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public void Move()
    {
        this.transform.DOMove(new Vector3(0f, X, 0f), 3f);
    }
}
