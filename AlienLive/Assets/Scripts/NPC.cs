using UnityEngine;
using System.Collections;
using System;

public class NPC : MonoBehaviour
{

    private Rigidbody2D rigid;
    private float inverseMoveTime;
    private BoxCollider2D boxCollider;
    private Animator anim;


    public LayerMask Block;
    private Transform Target = null;
    private bool lookDown;


    // Use this for initialization
    void Start()
    {

        MainBar.instance.AddNpcToList(this);
        rigid = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        inverseMoveTime = 1f / 0.5f;
        anim = GetComponent<Animator>();

    }


    public void MoveToChair()
    {

        if (transform.position == Target.position)
        {

            StopMove();
        }
        else
        {
            float xDir = 0;
            float yDir = 0;

            if (Mathf.Abs(Target.position.y - transform.position.y) < float.Epsilon)
            {

                if (Mathf.Abs(Target.position.x - transform.position.x) <= 0.16f)
                    xDir = Target.position.x - transform.position.x;
                else
                    xDir = Target.position.x > transform.position.x ? 0.16f : -0.16f;
            }
            else
            {
                if (Mathf.Abs(Target.position.y - transform.position.y) <= 0.16f)
                    yDir = Target.position.y - transform.position.y;
                else
                    yDir = Target.position.y > transform.position.y ? 0.16f : -0.16f;
            }



            //Call the AttemptMove function and pass in the generic parameter Player, because Enemy is moving and expecting to potentially encounter a Player
            //AttemptMove<Player>(xDir, yDir);
            Vector2 start = transform.position;

            Vector2 end = start + new Vector2(xDir, yDir);
            
            if (!Physics2D.Linecast(start, end, Block))
            {

                anim.SetBool("isWalking", true);
                anim.SetFloat("input_x", xDir);
                anim.SetFloat("input_y", yDir);

                Vector3 newPostion = Vector3.MoveTowards(rigid.position, end, inverseMoveTime * Time.deltaTime);

                //Call MovePosition on attached Rigidbody2D and move it to the calculated position.
                rigid.MovePosition(newPostion);
            }
            else
            {

                anim.SetBool("isWalking", false);

                xDir = 0;
                yDir = 0;
                //If the difference in positions is approximately zero (Epsilon) do the following:

                //If the difference in positions is approximately zero (Epsilon) do the following:
                if (Mathf.Abs(Target.position.x - transform.position.x) < float.Epsilon)

                    if (Mathf.Abs(Target.position.y - transform.position.y) <= 0.16f)
                        yDir = Target.position.y - transform.position.y;
                    else
                        yDir = Target.position.y > transform.position.y ? 0.16f : -0.16f;

                //If the difference in positions is not approximately zero (Epsilon) do the following:
                else
                {
                    if (Mathf.Abs(Target.position.x - transform.position.x) <= 0.16f)
                        xDir = Target.position.x - transform.position.x;
                    else
                        xDir = Target.position.x > transform.position.x ? 0.16f : -0.16f;
                }
                end = start + new Vector2(xDir, yDir);


                if (!Physics2D.Linecast(start, end, Block))
                {
                    anim.SetBool("isWalking", true);
                    anim.SetFloat("input_x", xDir);
                    anim.SetFloat("input_y", yDir);
                    Vector3 newPostion = Vector3.MoveTowards(rigid.position, end, inverseMoveTime * Time.deltaTime);
                    rigid.MovePosition(newPostion);

                }
                else
                {
                    anim.SetBool("isWalking", false);
                }


            }
        }

    }

    internal void StartMove(Transform transform, bool look)
    {
        Target = transform;
        lookDown = look;
    }

    internal void StopMove()
    {
        anim.SetBool("isWalking", false);
        if (lookDown)
            anim.SetFloat("input_y", -0.16f);
        else
            anim.SetFloat("input_y", 0.16f);
    }

    internal bool HasTarget()
    {
        return Target == null;
    }

    protected void OnCantMove<T>(T component)
    {
        throw new NotImplementedException();
    }
}
