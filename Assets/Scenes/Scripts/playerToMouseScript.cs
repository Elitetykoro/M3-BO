using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class playerToMouseScript : MonoBehaviour
{
    public Camera cam;
    void Start()
    {
    }
    void FixedUpdate()
    {
        Vector3 position = (cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 49)) - transform.position) / 12;

        transform.position += position;
    }
}
