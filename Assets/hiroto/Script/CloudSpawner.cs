using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour
{
    [SerializeField]
    CloudMove cloudMove;
    [SerializeField]
    float time = 2f;
    [SerializeField]
    RectTransform SpawnPoint;
    [SerializeField]
    RectTransform canvas;
    [SerializeField]
    float maxVaule;
    [SerializeField]
    float minVaule;

    float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer > time)
        {
            timer = 0;
            var cloud = Instantiate(cloudMove, SpawnPoint);
            var y = Random.Range(minVaule, maxVaule);
            cloud.transform.SetParent(canvas);
            cloud.GetComponent<RectTransform>().DOAnchorPosY(y, 0f);
            cloud.MoveCloud();
        }
    }
}
