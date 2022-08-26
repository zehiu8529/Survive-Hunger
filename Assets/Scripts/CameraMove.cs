using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    private Vector3 offset = new Vector3(0f, 0f, -10f);
    [SerializeField]
    private Transform target;

    private float smoothTime = 0.25f;
    private Vector3 velocity = Vector3.zero;
    [SerializeField] float xOffSet = 0f;
    [SerializeField] float yOffSet = 0f;

    GameObject cameraComposition;
    Bounds cameraBound;

    private void Start()
    {
        cameraComposition = GameObject.Find("Camera Boundary");
        cameraBound = cameraComposition.GetComponent<BoxCollider2D>().bounds;
    }

    void Update()
    {
        FollowPlayer();
        LimitCamera();        
    }

    /// <summary>
    /// Make camera follow player
    /// </summary>
    void FollowPlayer()
    {
        Vector3 targetPos = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, smoothTime);
    }

    /// <summary>
    /// Limit camera movement within bound
    /// </summary>
    void LimitCamera()
    {
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, cameraBound.min.x + xOffSet, cameraBound.max.x - xOffSet),
            Mathf.Clamp(transform.position.y, cameraBound.min.y + yOffSet, cameraBound.max.y - yOffSet), transform.position.z);
    }
}
