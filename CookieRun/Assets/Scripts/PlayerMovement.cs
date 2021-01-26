using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 PlayerPos;
    private Rigidbody2D rigid;
    private int jumpStack;
    private Animator animator;

    public float speed;
    public float jumpforce;
    // Start is called before the first frame update
    void Start()
    {
        jumpStack = 2;
        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
        Slide();
    }

    void Move()
    {
        PlayerPos = gameObject.transform.position;
        PlayerPos.x += speed;

        gameObject.transform.position = PlayerPos;
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jumpStack>1)
        {
            rigid.velocity = Vector2.up * jumpforce;
            jumpStack -= 1;
        }
        else if(Input.GetKeyDown(KeyCode.Space) && jumpStack > 0)
        {
            rigid.velocity = Vector2.up * jumpforce;
            jumpStack -= 1;
        }
        
    }

    public void ResetJumpStack()
    {
        jumpStack = 2;
        Debug.Log(jumpStack);
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
