using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tsuka2Script : MonoBehaviour
{
    public bool hitBlade = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Blade"))
        {
            hitBlade = true;
        }
    }
}   
