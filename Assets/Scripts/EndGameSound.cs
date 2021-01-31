using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameSound : MonoBehaviour
{ 
    AudioSource heroSpeaks;

    public AudioClip heroGreeting;
    public float setVolume = 1f;


    // Start is called before the first frame update
    void Start()
    {
        heroSpeaks = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Win game!");
            heroSpeaks.PlayOneShot(heroGreeting, setVolume);
        }
    }
}
