using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{

    AudioSource newMusic;

    
    [Header("Select Music")]
    public AudioClip outsideMusic;
    public AudioClip templeMusic;

    [Header("Set Volume")]
    public float setVolume = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        newMusic = GetComponent<AudioSource>();
        newMusic.PlayOneShot(outsideMusic, setVolume);
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("MusicChange"))
        {
            newMusic.Stop();
            newMusic.PlayOneShot(templeMusic, setVolume);
        }
    }
}
