using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Slide();
    }
    void Slide()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            animator.SetBool("isSliding", true);
            Debug.Log(animator.GetBool("isSliding"));
        }
        if (Input.GetKeyUp(KeyCode.Z))
        {
            animator.SetBool("isSliding", false);
        }
    }
}
