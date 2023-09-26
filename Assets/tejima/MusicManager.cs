using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioClip sound;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.AddComponent<AudioSource>();
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(sound);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
