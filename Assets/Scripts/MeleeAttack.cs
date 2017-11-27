using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Weapon")
        {
            Destroy(gameObject);
        }
       // enemy.gameObject.SetActive(false);
    }

}
