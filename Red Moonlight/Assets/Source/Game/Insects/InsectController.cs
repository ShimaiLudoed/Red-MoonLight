using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InsectController : MonoBehaviour
{
  [SerializeField] private InsectGameManager insectGameManager;

  public void OnDrop(PointerEventData eventData)
  {
    Insect insect = eventData.pointerDrag.GetComponent<Insect>();
    if (insect != null)
    {
      Transform tray = eventData.pointerPress.transform;
      insectGameManager.PlaceInsect(insect.Index, tray);
    }
  }
}
