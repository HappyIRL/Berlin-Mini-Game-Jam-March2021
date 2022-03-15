using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	public Transform playerTransform { get; set; }
	private void Update()
	{
		if (playerTransform != null)
			transform.position = new Vector3(transform.position.x, Mathf.Max(1, playerTransform.position.y), transform.position.z);
	}
}
