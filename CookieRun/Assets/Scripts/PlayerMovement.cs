using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 PlayerPos;
    private Rigidbody2D rigid;
    private int jumpStack;

    public float speed;
    public float jumpforce;
    // Start is called before the first frame update
    void Start()
    {
        jumpStack = 2;
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
    }

    void Move()
    {
        PlayerPos = gameObject.transform.position;
        PlayerPos.x += speed;

        gameObject.transform.position = PlayerPos;
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jumpStack>0)
        {
            rigid.AddForce(Vector2.up * jumpforce, ForceMode2D.Impulse);
            jumpStack -= 1;
        }
    }

    public void ResetJumpStack()
    {
        jumpStack = 2;
        Debug.Log(jumpStack);
    }
}
