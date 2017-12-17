using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyGameObject : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Destroy")
        {
            Destroy(gameObject);
        }
    }
}
