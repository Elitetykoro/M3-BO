using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SpawnWarningParticles : MonoBehaviour
{
    private Vector3 Spawnposition;
    [SerializeField]private ParticleSystem PS;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, Vector3.forward, Color.red);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Wall"))
        {
            
            Instantiate(PS, Spawnposition, transform.rotation);
        }
    }
}
