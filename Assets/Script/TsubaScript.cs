using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TsubaScript : MonoBehaviour
{
    public bool stopObject = false; 
    public int numberOfhits=0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Stop"))
        {
            stopObject = true;
            // This will count how many times the tsuba hit the box, because after it hits the second box, it will stop moving
            numberOfhits++; 
        }
    }
}
