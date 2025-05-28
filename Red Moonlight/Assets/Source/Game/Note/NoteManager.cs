using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NoteManager : MonoBehaviour
{
  [SerializeField] private GameObject notePrefab;
  [SerializeField] private float spawnInterval = 1f; 
  [SerializeField] private Transform[] spawnPoints; 
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
    int randomIndex = Random.Range(0, spawnPoints.Length);
    Transform spawnPosition = spawnPoints[randomIndex]; 
    GameObject note = Instantiate(notePrefab, spawnPosition.transform.position, Quaternion.identity);
    note.transform.SetParent(transform, false);
  }
}