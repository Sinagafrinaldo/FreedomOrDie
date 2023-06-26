using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float FollowSpeed = 2f;
    public float yOffset = 1f;
    public Transform target;

   void Start()
{
    float screenAspect = (float)Screen.width / (float)Screen.height;
    float cameraHeight = Camera.main.orthographicSize * 2;
    float cameraWidth = cameraHeight * screenAspect;

    Vector3 newPos = new Vector3(target.position.x, target.position.y + yOffset, -10f);

    // Check if the camera position is beyond the left edge of the tilemap
    if (newPos.x < cameraWidth / 2f)
    {
        newPos = new Vector3(cameraWidth / 2f, newPos.y, newPos.z);
    }

    transform.position = newPos;
}

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = new Vector3(target.position.x, target.position.y+ yOffset, -10f);
        transform .position = Vector3.Slerp(transform.position, newPos, FollowSpeed*Time.deltaTime);
    }
}
