using System.Collections;
using UnityEngine;

public class playerToMouseScript : MonoBehaviour
{
    Camera cam;
    void Start()
    {
        cam = GameObject.Find("Main Camera").GetComponent<Camera>;
    }
    void FixedUpdate()
    {
        Vector3 mousePos = Input.mousePosition;
        transform.position = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 5));
    }
}
