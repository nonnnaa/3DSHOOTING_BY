using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleEvent_2 : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        SampleEvent.instance.onEventLoadDataServer += OnEventLoadDataServer;
    }

    private void OnEventLoadDataServer(string data)
    {
        Debug.LogError(" Sample event 2: " + data);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnUnityEventCount(int a)
    {
        Debug.LogError(" OnUnityEventCount" + a);
    }
}
