using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RegenSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private int _numberOfPrefabs;
    [SerializeField] private float _spawnRadius;
    [SerializeField] private float _delayBetweenSpawns;
      public static int count;
    [SerializeField] private Collider2D _destroyCollider;
    [SerializeField] private TMP_Text Score;
    

    private void SpawnPrefabs()
    {
        for (int i = 0; i < _numberOfPrefabs; i++)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-10f, 10f), transform.position.y, transform.position.z) + Random.insideUnitSphere * _spawnRadius;
            GameObject newPrefab = Instantiate(_prefab, spawnPosition, Quaternion.identity);
            newPrefab.SetActive(true);

            // Add Rigidbody2D component to the prefab
            Rigidbody2D prefabRigidbody = newPrefab.GetComponent<Rigidbody2D>();
            if (prefabRigidbody == null)
            {
                prefabRigidbody = newPrefab.AddComponent<Rigidbody2D>();
            }

            // Add BoxCollider2D component to the prefab
            BoxCollider2D prefabCollider = newPrefab.GetComponent<BoxCollider2D>();
            if (prefabCollider == null)
            {
                prefabCollider = newPrefab.AddComponent<BoxCollider2D>();
            }

            // Set collider properties
            prefabCollider.isTrigger = true;
            prefabCollider.size = new Vector2(1f, 1f);

            // Add script to destroy the prefab when it collides with the destroy collider
            DestroyOnTriggerEnter druppeltje = prefabCollider.gameObject.AddComponent<DestroyOnTriggerEnter>();
            druppeltje._triggerCollider = _destroyCollider;
            druppeltje.Score = Score;
        }
    }

    private IEnumerator SpawnPrefabsContinuously()
    {
        while (true)
        {
            SpawnPrefabs();
            yield return new WaitForSeconds(_delayBetweenSpawns);
        }
    }

    private void Start()
    {
        StartCoroutine(SpawnPrefabsContinuously());
    }
    
  

 
}


   

