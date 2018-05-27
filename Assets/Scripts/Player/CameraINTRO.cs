using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraINTRO : MonoBehaviour
{
    public Transform targetTransform;
    public Vector3 offset;
    public float smoothTime;
    private Vector3 currentVelocity;

    public PlayerBehaviour player;

    void FixedUpdate()
    {

        Vector3 newPosition = new Vector3(targetTransform.position.x + offset.x, targetTransform.position.y + offset.y, transform.position.z + offset.z);
        transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref currentVelocity, smoothTime);
    }
}
