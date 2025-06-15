using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void ShowInfo();
public delegate void ShowInfo_1(string mess);
public delegate string ShowInfo_2(string mess,string add);// func
public delegate void LoadDataServer(string data);// action
public delegate void Callback(bool res);
public delegate bool CheckTime();// predicate
public class SampleDelegate : MonoBehaviour
{
    public ShowInfo showInfo;
    // Start is called before the first frame update
    void Start()
    {
        showInfo = () =>
        {
            Debug.LogError("helo");
        };
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            // showInfo();
            // callback
            ShowMess_2((mess) =>
            {
                Debug.LogError(" show info ShowMess_2_delegate" + mess);
            
            });
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            ConectLoadData((data) =>
            {

            });
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            UpgradeCharacter((res) =>
            {
                // 
            });
            UpgradeCharacter(UpgradeResult);
        }
    }
    private void UpgradeResult(bool res)
    {

    }
    private void ConectLoadData(Action<string> callback)
    {
        string data = " data";
        // progress
        callback(data);
    }
    public void UpgradeCharacter(Callback callback)
    {
        // upgrade success
        callback(true);
    }
    // callback 
    public void ShowMess()
    {
        Debug.LogError(" show info delegate");
    }
    public void ShowMess_2(ShowInfo_1 sh_1)
    {
        sh_1(" helooooooo");
    }
    public void ShowMess_2_delegate(string mess)
    {
        Debug.LogError(" show info ShowMess_2_delegate"+ mess);
    }
}
