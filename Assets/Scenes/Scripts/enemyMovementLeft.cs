using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class enemyMovementLeft : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] Rigidbody rb;
    void FixedUpdate()
    {
        rb.AddForce(transform.forward * Random.Range(200f,450f) * Time.deltaTime, ForceMode.Impulse);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }
}