using UnityEngine;
using System.Collections;

public class CeilingAutoShot : MonoBehaviour
{
    public Transform shotPos;
    public Rigidbody projectile;
    static float timeMin = 10;
    static float timeMax = 15;
    public float shotDelay;
    public float forceAmount;
    public float aliveTime;

    public GameObject effect;


    void SpawnBall()
    {
        Rigidbody shotRigid;
        if((projectile != null) && (shotPos != null))
        {
            shotRigid = Instantiate(projectile, shotPos.position, shotPos.rotation) as Rigidbody;
            Instantiate(effect, shotPos.position, shotPos.rotation);
            if(shotRigid != null)
            {
                shotRigid.AddForce(shotPos.forward * forceAmount);
                Destroy(gameObject, aliveTime);


            }
        }
    }

    void Start()
    {
        //float timeToSpawn = Random.Range(timeMin, timeMax);
        InvokeRepeating("SpawnBall", shotDelay, 1.50f);
    }
}