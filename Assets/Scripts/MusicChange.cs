using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicChange : MonoBehaviour
{
    public AudioClip newMusic;
    
    // Start is called before the first frame update
    void Start()
    {
        newMusic = GetComponent<AudioClip>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        
    }

}
