using UnityEngine;
using System.Collections.Generic;

public class MusicManager : MonoBehaviour
{
    [SerializeField] private List<AudioClip> sound;
    [SerializeField] AudioSource audioSource;
    // Start is called before the first frame update
    
    public void PlaySE(SEType sEType)
    {
        AudioClip audioClip;

        switch (sEType)
        {
            case SEType.CommnadTap:
                audioClip = sound[0];
                audioSource.PlayOneShot(audioClip);
                break;
            case SEType.PutCup:
                audioClip = sound[1];
                audioSource.PlayOneShot(audioClip);
                break; 
            case SEType.ResultSe:
                audioClip = sound[2];
                audioSource.PlayOneShot(audioClip);
                break;
            case SEType.StartCount:
                audioClip = sound[3];
                audioSource.PlayOneShot(audioClip);
                break;
            case SEType.TimeUp:
                audioClip = sound[4];
                audioSource.PlayOneShot(audioClip);
                break;
        }
    }

    public enum SEType
    {
        CommnadTap,
        ResultSe,
        PutCup,
        StartCount,
        TimeUp,
    }
}
