using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class timer : MonoBehaviour
{
    private float CTime = 0;
    private bool active = true;
    public float ETime;
    [SerializeField] private TextMeshProUGUI CTtext;
    [SerializeField] private TextMeshProUGUI HStext;
    
    
    // Update is called once per frame
    void Update()
    {
        if(active)
        {
            CTime += Time.deltaTime;
        }
       
        CTtext.text = CTime.ToString();
        HStext.text = PlayerPrefs.GetFloat("BestTime").ToString();

        
        
        if (CTime > PlayerPrefs.GetFloat("BestTime", 0f)){
            PlayerPrefs.SetFloat("BestTime", CTime);
        }
    }
    public void Death()
    {
        active = false;
        ETime = CTime;
        PlayerPrefs.SetFloat("EndTime", ETime);
        Debug.Log("timer stopped");
    }
}
