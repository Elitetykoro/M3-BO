using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class timer : MonoBehaviour
{
    private float CTime = 0;
    private bool active = true;
    [SerializeField] private TextMeshProUGUI text;
    
    
    // Update is called once per frame
    void Update()
    {
        if(active)
        {
            CTime += Time.deltaTime;
        }
        text.text = CTime.ToString();
    }
}
