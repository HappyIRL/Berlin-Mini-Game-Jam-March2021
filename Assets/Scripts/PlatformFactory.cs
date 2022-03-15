using System.Collections.Generic;
using UnityEngine;

public class PlatformFactory : MonoBehaviour
{
	[SerializeField ]private Transform platformParent;
	[SerializeField] private List<GameObject> platformPrefab;
	[SerializeField] private Vector2 platformMinimumDistance = new Vector2(1, 1);
	[SerializeField] private float jumpDistance = 1f;
	[SerializeField] private int maxPlatformOnScreen = 15;
	[SerializeField] private Vector2 startPosition;
	[SerializeField] private float despawnDistance;
	[SerializeField] private float highestPlatform;
	[SerializeField] private GameObject spacePrefab;

	private GameObject lastSpaceSpawn;

	public Transform playerTransform { get; set; }

	private List<GameObject> platforms = new List<GameObject>();

	private void Start()
	{
		GeneratePlatforms();

		lastSpaceSpawn = Instantiate(spacePrefab, new Vector3(0, 40, 0), Quaternion.identity);
	}

	private void Update()
	{
		if (playerTransform == null)
			return;

		UpdateDespawn();
		UpdateBackground();
	}

	private void UpdateBackground()
	{
		if (playerTransform.position.y + 10 > lastSpaceSpawn.transform.position.y)
		{
			lastSpaceSpawn = Instantiate(spacePrefab, new Vector3(0, lastSpaceSpawn.transform.position.y + 10, 0), Quaternion.identity);
		}
	}

	private void GeneratePlatforms()
	{
		highestPlatform = startPosition.y;
		for (int i = 0; i < maxPlatformOnScreen; i++)
		{
			GameObject go = Instantiate(platformPrefab[Random.Range(0, 3)], platformParent.transform);
			go.transform.position = new Vector2(startPosition.x + Random.Range(-2.5f, 2.5f), highestPlatform + jumpDistance);
			platforms.Add(go);
			highestPlatform += jumpDistance;
		}
	}

	private void SpawnPlatform()
	{
		GameObject go = Instantiate(platformPrefab[Random.Range(0,3)],platformParent.transform);
		go.transform.position = new Vector2(startPosition.x + Random.Range(-2.5f, 2.5f), highestPlatform + jumpDistance);
		platforms.Add(go);
		highestPlatform += jumpDistance;
	}

	private void UpdateDespawn()
	{
		if (platforms.Count == 0)
			return;
		GameObject go = platforms[0];
		if (go.transform.position.y < playerTransform.position.y - despawnDistance)
		{
			platforms.RemoveAt(0);
			Destroy(go);
			SpawnPlatform();
		}
	}
}
