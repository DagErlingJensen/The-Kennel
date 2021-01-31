using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    private AudioSource currentMusicSource;
    
    public AudioClip musicOutside;
    public AudioClip musicTemple;
    public float setVolume = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        currentMusicSource = GetComponent<AudioSource>();

        currentMusicSource.PlayOneShot(musicOutside, setVolume);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Temple"))
        {
            currentMusicSource.Stop();
            currentMusicSource.PlayOneShot(musicTemple, setVolume);
            Debug.Log("Play new music");
        }        
    }

}
