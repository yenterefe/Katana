using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mekugi1Script : MonoBehaviour
{
    public bool hitTsuka2 = false;

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Tsuka2"))
        {
            hitTsuka2 = true;
        }
    }
}
