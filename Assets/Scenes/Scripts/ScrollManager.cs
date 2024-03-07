using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollManager : MonoBehaviour
{
    [SerializeField] float scrollspeed = 10;
    private Vector3 ScrollerPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ScrollerPos = transform.position;
        ScrollerPos.z -= scrollspeed * Time.deltaTime;
        transform.position = ScrollerPos;
        if(ScrollerPos.z <= -334.7f)
        {
            transform.position = new Vector3(-7.48f, 9.7f, -31.83f);
            scrollspeed += 0.2f;
        }

    }
}
