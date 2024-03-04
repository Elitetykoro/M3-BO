using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject enemy;
    [SerializeField] Transform Spawner;
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
            Vector3 v = Spawner.position;
            Instantiate(enemy,v ,Quaternion.identity);
        }
    }
    void FixedUpdate()
    {
        
    }
}
