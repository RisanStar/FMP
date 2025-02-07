using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPosition : MonoBehaviour
{
    private Camera playerCam;
    private Vector3 camPosOffset;

    private void Awake()
    {
        playerCam = Camera.main; 
    }

    private void Start()
    {
        camPosOffset = new Vector3(transform.position.x, (transform.position.y + 1f), transform.position.z);
    }

    private void Update()
    {
        playerCam.transform.position = camPosOffset;
    }
}
