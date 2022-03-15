using System.Runtime.CompilerServices;
using UnityEngine;

public class Player : MonoBehaviour
{
	private void Start()
	{
		SetUpCamera();
		ReferenceManager.Instance.Tutorial.SetActive(false);
	}

	private void SetUpCamera()
	{
		ReferenceManager.Instance.Camera.playerTransform = transform;
		ReferenceManager.Instance.Factory.playerTransform = transform;
	}
}
