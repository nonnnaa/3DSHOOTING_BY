using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SampleEvent : BYSingletonMono<SampleEvent>
{
    public event Action<string> onEventLoadDataServer;
    public UnityEvent<int> onCount;
    // public event LoadDataServer onEventLoadDataServer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            if (onEventLoadDataServer != null)
            {
                onEventLoadDataServer.Invoke(" event load data server");
            }
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            if (onCount != null)
            {
                onCount.Invoke(2);
            }
        }
    }
}
