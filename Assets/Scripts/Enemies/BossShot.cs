using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShot : MonoBehaviour
{
    public float maxRot;
    public float minRot;
    public Transform tr;
    public float randSpeed;
    private float endRot;
    public bool isRotating;
    private float previousRot;
    private float nextRot;


    // Use this for initialization
    void Start ()
    {
        isRotating = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (!isRotating)
        {
            previousRot = tr.transform.rotation.z;
            nextRot = Random.Range(minRot, maxRot);


            isRotating = true;

            endRot = Time.time + randSpeed;
        }

        else
        {
            if (Time.time <= endRot)
                tr.transform.rotation = new Quaternion(0, 0, 1, previousRot + (Time.time / endRot) * nextRot);

            else
            {
                tr.transform.rotation = new Quaternion(0, 0, 1, previousRot + nextRot);

                isRotating = false;
            }

            if(tr.transform.rotation.z > maxRot)
                tr.transform.rotation = new Quaternion(0, 0, 1, maxRot);

            if(tr.transform.rotation.z < minRot)
                tr.transform.rotation = new Quaternion(0, 0, 1, minRot);


        }

    }
}
