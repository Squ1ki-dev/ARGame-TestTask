using System.Collections;
using System.Collections.Generic;
using AudioSystem;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class InteractionSystem : MonoBehaviour
{
    [SerializeField] private ScoreHandler scoreHandler;
    [SerializeField] private ARObjectSpawner objectSpawner;
    [SerializeField] private InventoryObject inventory;
    [SerializeField] private SoundData soundData;

    private void Update() => Fire();

    private void Fire()
    {
        if (Input.GetMouseButtonUp(0)) 
        {
            Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 100f));
            Vector3 direction = worldMousePosition - Camera.main.transform.position;

            RaycastHit hit;

            if (Physics.Raycast(Camera.main.transform.position, direction, out hit, 100f))
            {
                Debug.DrawLine(Camera.main.transform.position, hit.point, Color.green, 0.5f);

                var item = hit.collider.GetComponent<Item>();

                if (hit.collider.GetComponent<Item>())
                {
                    inventory.AddItem(item.item, 1);
                    scoreHandler.AddScore();
                    ObjectPool.ReturnToPool(hit.collider.gameObject);
                    objectSpawner.RespawnEnemy(1);

                    SoundManager.Instance.CreateSoundBuilder()
                        .WithRandomPitch()
                        .WithPosition(hit.collider.transform.position)
                        .Play(soundData);
                }
            }
        }
    }

    private void OnApplicationQuit() => inventory.Container.Clear();
}