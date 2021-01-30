using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{

    //public Animation doorOpenAnim;

    void Start()
    {
        //doorOpenAnim = GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Door"))
        {
            Debug.Log("Door Open");
        }
    }
}
