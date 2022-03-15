using UnityEngine;

public class ReferenceManager : MonoBehaviour
{
	[SerializeField] private CameraFollow camera;
	[SerializeField] private PlatformFactory factory;
	[SerializeField] private GameObject tutorial;
	public CameraFollow Camera => camera;
	public PlatformFactory Factory => factory;
	public GameObject Tutorial => tutorial;

	public static ReferenceManager Instance { get; private set; }

	private void Awake()
	{
		Instance = null;
		Instance = this;
	}
}
