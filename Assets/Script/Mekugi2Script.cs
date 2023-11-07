using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mekugi2Script : MonoBehaviour
{
    public bool hitTsuka1 = false;

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Tsuka1"))
        {
            hitTsuka1 = true;
        }
    }
}
