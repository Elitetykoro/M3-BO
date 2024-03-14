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
    public float minSpeedRate = 3f, maxSpeedRate = 5f;
    void Start()
    {
        StartCoroutine("enemySpawn");
    }

    // Update is called once per frame
    IEnumerator enemySpawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(3f, 5f));
            Instantiate(enemy,Spawner.position ,transform.rotation);
            minSpeedRate += -0.1f;
            maxSpeedRate += -0.1f;
        }
    }
    void FixedUpdate()
    {
        Spawner.position += velocity * Time.deltaTime;
        transform.LookAt(player.position);
        if (Spawner.position.z >= 26)
        {
            velocity = new Vector3(velocity.x, 0, -velocity.z);
        }
        if (Spawner.position.z <= -26)
        {
            velocity = new Vector3(velocity.x, 0, velocity.z*-1);
        }

        Spawner.position += velocity * Time.deltaTime;
        if (Spawner.position.x >= 50)
        {
            velocity = new Vector3(-velocity.x, 0, velocity.z);
        }
        if (Spawner.position.x <= -50)
        {
            velocity = new Vector3(velocity.x*-1, 0, velocity.z);
        }
    }
}
