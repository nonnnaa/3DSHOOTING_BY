using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleEvent_1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SampleEvent.instance.onEventLoadDataServer += OnSampleData;
        SampleEvent.instance.onCount.AddListener(OnUnityEventCount);
    }
    private void OnSampleData(string data)
    {
        Debug.LogError("Sample event 1: " + data);
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        SampleEvent.instance.onEventLoadDataServer -= OnSampleData;
        SampleEvent.instance.onCount.RemoveListener(OnUnityEventCount);

    }
    public void OnClick()
    {
        Debug.LogError(" On Button click");
    }
    // Update is called once per frame
    void Update()
    {

    }
    public void OnUnityEventCount(int a)
    {
        Debug.LogError(" OnUnityEventCount 1" + a);
    }
}
