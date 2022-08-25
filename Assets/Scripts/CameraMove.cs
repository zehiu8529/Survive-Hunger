using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    private Vector3 offset = new Vector3(0f,0f,-10f);
    [SerializeField]
    private Transform target;

    private float smoothTime = 0.25f;
    private Vector3 velocity = Vector3.zero;
        
    void Update()
    {
        FollowPlayer();
    }

    /// <summary>
    /// Make camera follow player
    /// </summary>
    void FollowPlayer()
    {
        Vector3 targetPos = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, smoothTime);
    }
}
