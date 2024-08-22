using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARRaycastManager))]
public class ARObjectSpawner : MonoBehaviour
{
    private bool placementPoseIsValid = false;

    [SerializeField] private int maxObjects;
    [SerializeField] private ObjectListSO objectListSO;

    private Pose PlacementPose;
    private ARRaycastManager aRRaycastManager;
    private List<ARRaycastHit> hits = new List<ARRaycastHit>();

    private void Awake() => aRRaycastManager = GetComponent<ARRaycastManager>();
    private void Start() => StartCoroutine(SpawnObjects(maxObjects, 3f));
    private void Update() => UpdatePlacementPose();

    private void UpdatePlacementPose()
    {
        var screenCenter = new Vector2(Screen.width / 2, Screen.height / 2);

        aRRaycastManager.Raycast(screenCenter, hits, TrackableType.Planes);

        placementPoseIsValid = hits.Count > 0;
        if (placementPoseIsValid)
            PlacementPose = hits[0].pose;
    }

    public void RespawnEnemy(int amount) => StartCoroutine(SpawnObjects(amount, 5f));

    private IEnumerator SpawnObjects(int count, float delay)
    {
        yield return new WaitForSeconds(delay);
        for (int i = 0; i < count; i++)
        {
            Vector3 randomOffset = new Vector3(
                Random.Range(-1.5f, 1.5f),
                0,
                Random.Range(-1.5f, 1.5f)
            );

            Vector3 spawnPosition = PlacementPose.position + randomOffset;

            int randomIndex = Random.Range(0, objectListSO.objectTypes.Count);
            GameObject selectedEnemyType = objectListSO.objectTypes[randomIndex].prefab;
            ObjectPool.SpawnObject(selectedEnemyType, spawnPosition, Quaternion.identity);
        }
    }
}