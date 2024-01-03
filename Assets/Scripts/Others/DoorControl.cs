using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorControl : MonoBehaviour
{
    Animator animator;
    public bool doorOpen=false;
    void Start()
    {
        animator= GetComponent<Animator>();
    }
    void Update()
    {
        DoorOpen();
    }
    void DoorOpen()
    {
        if (doorOpen==true)
        {
            animator.SetTrigger("doorOpen");
            Destroy(gameObject,1.27f);
           
        }
    }
}
