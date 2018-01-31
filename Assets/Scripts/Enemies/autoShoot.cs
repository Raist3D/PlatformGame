using UnityEngine;
using System.Collections;

public class autoShoot : MonoBehaviour
{
    public Transform shotPos;
    public Rigidbody projectile;
    public float shotDelay;
    public float forceAmount;

    public GameObject effect;


    void SpawnBall()
    {
        Rigidbody shotRigid;
        if((projectile != null) && (shotPos != null))
        {
            shotRigid = Instantiate(projectile, shotPos.position, shotPos.rotation) as Rigidbody;
           // Instantiate(effect, shotPos.position, shotPos.rotation);
            if(shotRigid != null)
            {
                shotRigid.AddForce(shotPos.forward * forceAmount);

            }
        }
    }

    void Start()
    {
        //float timeToSpawn = Random.Range(timeMin, timeMax);
        InvokeRepeating("SpawnBall", shotDelay, 1.50f);
    }
}