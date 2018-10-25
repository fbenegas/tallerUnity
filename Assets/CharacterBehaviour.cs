using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBehaviour : MonoBehaviour {

    [SerializeField]
    private Animator animator;
    [SerializeField]
    private new Rigidbody2D rigidbody2D;
    [SerializeField]
    private float maxSpeed;

    private bool facingRight;
	// Use this for initialization
	void Start ()
    {
        facingRight = true;
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        float move = maxSpeed * Input.GetAxis("Horizontal");
        rigidbody2D.velocity = new Vector2(move, rigidbody2D.velocity.y);

        if (move != 0)
            animator.SetBool("running", true);
        else
            animator.SetBool("running", false);

        if (move < 0 && facingRight)
            Flip();
        if (move > 0 && !facingRight)
            Flip();

	}

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 aux = transform.localScale;
        aux.x *= -1;
        transform.localScale = aux;
    }
}
