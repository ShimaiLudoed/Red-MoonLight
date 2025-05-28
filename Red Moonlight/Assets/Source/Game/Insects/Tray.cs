using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tray : MonoBehaviour, IDropHandler
{
  [SerializeField] private InsectGameManager insectGameManager;

  public void OnDrop(PointerEventData eventData)
  {
    Insect insect = eventData.pointerDrag.GetComponent<Insect>();
        
    if (insect != null)
    {
      insectGameManager.PlaceInsect(insect.Index, transform);
    }
  }
}
