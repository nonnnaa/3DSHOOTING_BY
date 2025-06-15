using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    private Transform trans_cam;
    private Transform trans_target;
    private Vector3 offset;
    private void Awake()
    {
        float s = GameManager.instance.sensiti_cam;

        trans_cam = transform;
        trans_target = GameObject.FindGameObjectWithTag("Player").transform;
        offset = trans_cam.position - trans_target.position;
    }
    // Start is called before the first frame update
    private void LateUpdate()
    {
        trans_cam.position = Vector3.Lerp(trans_cam.position, trans_target.position+offset, Time.deltaTime * 3.5f);
    }
}
