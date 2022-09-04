using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_move : MonoBehaviour
{
    [SerializeField]
    private float speed;
    private Vector2 direction;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        direction = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        Move();
        AnimateMovement();
       
    }

    public void AnimateMovement()
    {
        animator.SetLayerWeight(1, 1);

        animator.SetFloat("x", direction.x);
        animator.SetFloat("y", direction.y);
    }

    public void Move()
    {
        transform.Translate(direction * speed * Time.deltaTime);
        
        if(direction.x != 0 || direction.y != 0)
        {
            AnimateMovement();
        }
        else
        {
            animator.SetLayerWeight(1, 0);
        }
    }

    private void GetInput()
    {
        Vector2 moveVector;

        moveVector.x = Input.GetAxisRaw("Horizontal");
        if (moveVector.x < 0 )
        {
            transform.localScale = new Vector3(-4f, 4f, 1f);
        }
        else
        {
            transform.localScale = new Vector3(4f, 4f, 1f);
        }
        moveVector.y = Input.GetAxisRaw("Vertical");

        direction = moveVector;
    }
}
