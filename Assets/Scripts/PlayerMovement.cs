using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
	[SerializeField] private float jumpValue = 100f;
	[SerializeField] private float speed = 10f;

	[SerializeField] private Sprite jumpSprite;
	[SerializeField] private Sprite sitSprite;

	private SpriteRenderer spriteRenderer;
	private Vector2 movementValue;
	private bool isGrounded = false;
	private Rigidbody2D rigidbody2D;
	private float height = -10;

	private void Awake()
	{
		rigidbody2D = GetComponent<Rigidbody2D>();
		spriteRenderer = GetComponent<SpriteRenderer>();
	}

	private void Update()
	{
		UpdateJump();
		UpdateMove();
	}

	private void UpdateMove()
	{
		rigidbody2D.velocity = new Vector2(movementValue.x * speed, rigidbody2D.velocity.y);

		if (transform.position.x > 3.5)
		{
			transform.position = new Vector3(-3.5f, transform.position.y, 0);
		}
		else if (transform.position.x < -3.5)
		{
			transform.position = new Vector3(3.5f, transform.position.y, 0);
		}
	}

	public void OnMove(InputValue value)
	{
		movementValue = value.Get<Vector2>();
	}

	private void UpdateJump()
	{
		if (rigidbody2D.velocity.y <= 0)
		{
			if (isGrounded)
			{
				rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, jumpValue);
				isGrounded = false;
			}
			spriteRenderer.sprite = sitSprite;

			if (transform.position.y < height)
				SceneManager.LoadScene(0);
							
		}
		else
		{
			spriteRenderer.sprite = jumpSprite;
			height = transform.position.y - 10;
		}
	}

	public void OnCollisionEnter2D(Collision2D collision)
	{
		isGrounded = true;
	}
	public void OnCollisionExit2D(Collision2D collision)
	{
		isGrounded = false;
	}
}
