using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class lazermanager : MonoBehaviour
{
    [SerializeField] private GameObject LazerWarning;
    [SerializeField] private GameObject Lazer;
    [SerializeField] private Transform Player;
    private float LazerSpawnTime;
    private bool active = true;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("LazerSpawn");
        
    }

    // Update is called once per frame
    void Update()
    {
        LazerSpawnTime = Random.Range(4f, 10f);
    }
       
    

    
    private IEnumerator LazerSpawn()
    {
        while (active)
        {
            yield return new WaitForSeconds(LazerSpawnTime);
            LazerWarning.transform.position = Player.position;
            LazerWarning.transform.rotation = Quaternion.Euler(0, Random.Range(20, 160), 0);
            LazerWarning.SetActive(true);
            yield return new WaitForSeconds(1.5f);
            LazerWarning.SetActive(false);
            Lazer.transform.position = LazerWarning.transform.position;
            Lazer.transform.rotation = LazerWarning.transform.rotation;
            Lazer.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            Lazer.SetActive(false);
            LazerSpawnTime = Random.Range(4f, 6f);
        }
    }
   
}