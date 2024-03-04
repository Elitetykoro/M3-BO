using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{
    [SerializeField] private GameObject TimerManager;
    
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("lazer"))
        {
            Debug.Log("death");
            TimerManager.GetComponent<timer>().Death();
        }
    }
}
