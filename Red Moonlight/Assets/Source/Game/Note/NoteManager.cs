using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NoteManager : MonoBehaviour
{
  [SerializeField] private GameObject notePrefab;
  [SerializeField] private float spawnInterval = 1f; 
  [SerializeField] private float spawnRangeX = 4f;

  private void Start()
  {
    StartCoroutine(SpawnNotes());
  }

  private IEnumerator SpawnNotes()
  {
    while (true)
    {
      SpawnNote();
      yield return new WaitForSeconds(spawnInterval);
    }
  }

  void SpawnNote()
  {
    float spawnX = Random.Range(-spawnRangeX, spawnRangeX);
    Vector3 spawnPosition = new Vector3(spawnX, 6, 0); 
    GameObject note = Instantiate(notePrefab, spawnPosition, Quaternion.identity);
    note.transform.SetParent(transform, false);
  }
}