using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{

    void OnTriggerEnter(Collider other) 
    {
        VidaScript.vidaValue -= 1;
        Destroy(other.gameObject); 
    }
}
