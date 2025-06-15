using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float sensiti_cam;
    [SerializeField] private float followSpeed;

    private Transform targetTransform;
    private Transform cameraTransform;
    private Vector3 offset;
    void Awake()
    {
        targetTransform = GameObject.FindGameObjectWithTag("Player").transform;
        cameraTransform = transform;
        offset = cameraTransform.position - targetTransform.position;
    }

    
    void LateUpdate()
    {

        cameraTransform.position = Vector3.Lerp(cameraTransform.position, targetTransform.position + offset, followSpeed * Time.deltaTime);
    }
}
