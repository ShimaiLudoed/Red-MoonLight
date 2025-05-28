using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Telescope : MonoBehaviour
{
  [SerializeField] private RectTransform overFLow;
  [SerializeField] private RectTransform[] constellations;
  [SerializeField] private float radius;
  private int _allConstellations;
  public static Action onWin;
  
  private void Update()
  {
    Vector2 mousePosition = Input.mousePosition;
    overFLow.position = mousePosition; 
    CheckConstellations(mousePosition);
  }
  private void CheckConstellations(Vector2 position)
  {
    foreach (var constellation in constellations)
    {
      if (Vector2.Distance(position, constellation.transform.position) < radius)
      {
        Debug.Log($"Созвездие {constellation.name} найдено!");
        constellation.gameObject.SetActive(false);
        _allConstellations++;
      }
    }

    if (_allConstellations == constellations.Length)
    {
      onWin?.Invoke();
    }
  }
}
