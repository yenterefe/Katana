using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BladeScript : MonoBehaviour
{

    public bool stopObject = false;
    public bool stopObject2 = false;

    private void OnTriggerEnter(Collider other)
    {
        // Since the blade must rotate twice, it will have to hit two different triggers 
        if (other.gameObject.CompareTag("Stop2"))
        {
            stopObject = true;
        }

        if (other.gameObject.CompareTag("Stop3"))
        {
            stopObject2 = true;
        }
    }
}
