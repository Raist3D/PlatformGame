using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    public Transform targetTransform;
    public Vector2 offset;
    public float smoothTime;
    private Vector3 currentVelocity;

    public PlayerBehaviour player;

    void FixedUpdate()
    {
        if (player.facingRight) offset.x = Mathf.Abs(offset.x);
        else offset.x = -Mathf.Abs(offset.x);

        Vector3 newPosition = new Vector3(targetTransform.position.x + offset.x, targetTransform.position.y + offset.y, transform.position.z);
        transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref currentVelocity, smoothTime);
    }
}
