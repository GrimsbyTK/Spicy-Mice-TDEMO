using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float speed = 5.0F;
	private Rigidbody rb;
	public LayerMask groundLayers;
	public float jumpForce = 10.0f;
	public CapsuleCollider col;

	void Start () {
		rb = GetComponent<Rigidbody> ();
		col = GetComponent<CapsuleCollider> ();
		Cursor.lockState = CursorLockMode.Locked;
	}

	void Update () {
		float translation = Input.GetAxis ("Vertical") * speed;
		float straffe = Input.GetAxis ("Horizontal") * speed;
		translation *= Time.deltaTime;
		straffe *= Time.deltaTime;

		transform.Translate (straffe, 0, translation);

		if (IsGrounded() && Input.GetKeyDown (KeyCode.Space))
		{
			rb.AddForce (Vector3.up * jumpForce, ForceMode.Impulse);
		}

		if (Input.GetKeyDown ("escape"))
			Cursor.lockState = CursorLockMode.None;
	}

	private bool IsGrounded()
	{
		return Physics.CheckCapsule (col.bounds.center, new Vector3 (col.bounds.center.x, col.bounds.min.y, col.bounds.center.z), col.radius * .9f, groundLayers);
	}
}
