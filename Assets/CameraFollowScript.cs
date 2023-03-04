using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowScript : MonoBehaviour
{
    public float zOffset = 10f;
    public float panSpeed = 5f;
    public Transform target;

    private void Update()
    {
        if (target is not null)
        {
            var lerpPos = Vector2.Lerp(transform.position, target.position, Time.deltaTime * panSpeed);

            transform.position = new Vector3(lerpPos.x, lerpPos.y, -zOffset);
        }
    }
}
