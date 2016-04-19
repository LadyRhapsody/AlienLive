using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    private Rigidbody2D rbody;
	private Animator anim;


	// Use this for initialization
	void Start () {
	
		rbody = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
	
		Vector2 move_vector = new Vector2 (Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

		if (move_vector != Vector2.zero) {
			anim.SetBool ("isWalking",true);
			anim.SetFloat("input_x", move_vector.x);
			anim.SetFloat("input_y", move_vector.y);
		} else {
			anim.SetBool ("isWalking", false);
		}

		rbody.MovePosition (rbody.position + move_vector * Time.deltaTime* 1.5f);
	}
}
