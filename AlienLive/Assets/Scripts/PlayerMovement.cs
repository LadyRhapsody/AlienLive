using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D rbody;
    private Animator anim;
    private bool canWalk;


    // Use this for initialization
    void Start()
    {

        rbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        canWalk = true;
    }

    // Update is called once per frame
    void Update()
    {

        if (canWalk)
        {
            Vector2 move_vector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

            if (move_vector != Vector2.zero)
            {
                anim.SetBool("isWalking", true);
                anim.SetFloat("input_x", move_vector.x);
                anim.SetFloat("input_y", move_vector.y);
            }
            else
            {
                anim.SetBool("isWalking", false);
            }

            rbody.MovePosition(rbody.position + move_vector * Time.deltaTime * 1.5f);
        }
    }

    public void StopWalk()
    {
        canWalk = false;
    }

    public void StartWalk()
    {
        canWalk = true;
    }
}
