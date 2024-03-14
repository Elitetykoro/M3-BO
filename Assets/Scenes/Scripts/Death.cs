using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{
    public GameObject TimerManager;
    [SerializeField] private ParticleSystem Explosion;
    [SerializeField] private MeshRenderer Baloon;
    [SerializeField] private MeshRenderer BaloonString;
    
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("lazer")||other.CompareTag("enemy"))
        {
            StartCoroutine("DeathExplosion");
        }
        

    }

    IEnumerator DeathExplosion()
    {
        TimerManager.GetComponent<timer>().Death();
        Baloon.enabled = false;
        BaloonString.enabled = false;
        Explosion.Play();
        yield return new WaitForSeconds(0.6f);
        SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
    }
}
