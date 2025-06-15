using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sample_01 : MonoBehaviour
{
    public static Sample_01 instance;
    // 
    public int age=20;
    private int addAge;
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        Debug.LogError("helo @");
        Debug.LogWarning("helo !");
        age = 12;
        Debug.Log("Age:  " + age);
        // age = 15;
        //  Debug.Log("Age:  " + age);
        ShowLog("helo world");
        ShowLog(" new log ");
        int sum = Add(1, 2);
        Debug.Log(" sum: " + sum);
        SmapleGeneric<int> sg_1 = new SmapleGeneric<int>();
        sg_1.ShowInfo(2);
        SmapleGeneric<string> sg_2 = new SmapleGeneric<string>();
        sg_2.ShowInfo("helo world");
        string s=SampleSingleton.instance.mess;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    private void ShowLog(string mess)
    {
        Debug.Log(" mess: " + mess);
    }
    private int Add(int  a,int b)
    {
        return a + b;
    }
}

public class SampleStatic
{
    private static string add_info = " brayang";
    public static int Add(int a, int b)
    {
        return a + b;
    }
    public static void ShowInfo(string mess)
    {
        Debug.LogError(mess+" "+ add_info);
    }
}
public class SmapleGeneric<T>
{ 
    public void ShowInfo(T a)
    {
        Debug.Log(a.ToString());
    }


}
public class SampleSingleton: BYSingleton<SampleSingleton>
{
    public string mess = "helo";
}
public class sampleSingleton_2: BYSingleton<sampleSingleton_2>
{

}