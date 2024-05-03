using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovements : MonoBehaviour
{
	bool alive = true;

	public float speed = 5;
    [SerializeField] Rigidbody rb;

	float horizontalInput;
	[SerializeField] float horizontalMultiplier = 1;

	public float speedIncreasePerPoint = 0.1f;

	[SerializeField] float jumpForce = 400f;
	[SerializeField] LayerMask groundMask;

	Animator animator;

	private void Awake()
	{
		animator = GetComponentInChildren<Animator>();
		if (animator == null)
		{
			Debug.LogError("Animator component not found on the player GameObject or its children.");
		}
	}

	private void FixedUpdate()
	{
		if (!alive) return;

		Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
		Vector3 horizontalmove = transform.right * horizontalInput * speed * Time.fixedDeltaTime * horizontalMultiplier;
		rb.MovePosition(rb.position + forwardMove + horizontalmove);
	}


	void Update()
    {
		horizontalInput = Input.GetAxis("Horizontal");

		if (Input.GetKeyDown(KeyCode.Space))
		{
			Debug.Log("Jumping");
			Jump();
		}

		if (transform.position.y < -5)
        {
			DieEmpty();
        }
    }

	public void Die()
	{
		alive = false;


		//Restart the game
		Invoke("Restart",2);

		animator.Play("Stumble Backwards");
		
	}

	public void DieEmpty()
	{
		alive = false;


		//Restart the game
		Invoke("Restart", 2);

		animator.Play("Floating");

	}

	void Restart()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	void Jump()
	{
		float height = GetComponent<Collider>().bounds.size.y;
		bool isGrounded = Physics.Raycast(transform.position, Vector3.down, (height / 2) + 0.1f, groundMask);

		//if we are jump

		if (isGrounded)
		{
			rb.AddForce(Vector3.up * jumpForce);
			animator.Play("Jumping Up");
		}

	}
}
