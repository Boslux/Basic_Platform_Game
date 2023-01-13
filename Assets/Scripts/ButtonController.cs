using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    Animator animator;
    public bool isOn = true;
    public GameObject door;

    private void Start()
    {
        animator= GetComponent<Animator>();
    }
    private void Update()
    {
        OnAction();
    }
    void OnAction()
    {
        if (isOn==false)
        {
            animator.SetTrigger("off");
            door.GetComponent<DoorControl>().doorOpen = true;
        //  gameObject.GetComponent<FireController>().fireOn= false;
            
        }
        

    }
}
