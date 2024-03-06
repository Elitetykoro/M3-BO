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
        Vector3 mousePos = Input.mousePosition;
        transform.position = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 49));
    }
}
