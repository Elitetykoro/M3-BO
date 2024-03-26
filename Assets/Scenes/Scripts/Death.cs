using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{
    public GameObject TimerManager;
    [SerializeField] private MeshRenderer Balloon;
    [SerializeField] private MeshRenderer BalloonString;
    [SerializeField] private ParticleSystem Explosion;
    [SerializeField] private AudioClip Boom;
    private bool isDead = false;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("lazer")||other.CompareTag("enemy"))
        {
            Debug.Log("death");
            if (!isDead)
            {
                isDead = true;
                StartCoroutine("BaloonExplosion");
            }
        }
        

    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("lazer") || other.gameObject.CompareTag("enemy"))
        {
            Debug.Log("death");
            if (!isDead)
            {
                isDead = true;
                StartCoroutine("BaloonExplosion");
            }
        }


    }


    IEnumerator BaloonExplosion()
    {
        TimerManager.GetComponent<timer>().Death();
        SoundManager.Instance.PlaySound(Boom);
        Balloon.enabled = false;
        BalloonString.enabled = false;
        Explosion.Play();

        yield return new WaitForSeconds(0.6f);
        SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
    }
}
