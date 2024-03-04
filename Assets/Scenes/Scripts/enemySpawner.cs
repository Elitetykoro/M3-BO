using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject enemy;
    [SerializeField] Transform player;
    [SerializeField] Transform Spawner;
    public Vector3 velocity = new Vector3 ();
    private float z;
    private float x;
    void Start()
    {
        StartCoroutine("enemySpawn");
    }

    // Update is called once per frame
    IEnumerator enemySpawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(4f, 10f));
            Instantiate(enemy,Spawner.position ,transform.rotation);
        }
    }
    void FixedUpdate()
    {
        Spawner.position += velocity * Time.deltaTime;
        transform.LookAt(player.position);
        if (Spawner.position.z >= 30)
        {
            z = velocity.z;
            velocity = new Vector3(velocity.x, 0, -velocity.z);
        }
        if (Spawner.position.z <= -30)
        {
            velocity = new Vector3(velocity.x, 0, z);
        }

        Spawner.position += velocity * Time.deltaTime;
        if (Spawner.position.x >= 54)
        {
            x = velocity.x;
            velocity = new Vector3(-velocity.x, 0, velocity.z);
        }
        if (Spawner.position.x <= -54)
        {
            velocity = new Vector3(x, 0, velocity.z);
        }
    }
}
