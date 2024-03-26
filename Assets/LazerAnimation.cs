using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator animator;
    // Update is called once per frame
    void Update()
    {
        animator.SetBool("lazerscale", true);
    }
}
