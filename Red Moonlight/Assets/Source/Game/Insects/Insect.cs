using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Insect : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
  [field: SerializeField] public bool IsVenomous{get; private set;}
  [field: SerializeField] public int Index{get; private set;}
  [SerializeField] private InsectGameManager insectGameManager;
  [SerializeField] private CanvasGroup canvasGroup;
  [SerializeField] private RectTransform rectTransform;
  [SerializeField] public bool onNonTray = false;
  [SerializeField] public bool onTray = false;

  public void OnBeginDrag(PointerEventData eventData)
  {
    canvasGroup.alpha = 0.6f; 
    canvasGroup.blocksRaycasts = false; 
  }
  
  public void OnDrag(PointerEventData eventData)
  {
    Vector2 position;
    RectTransformUtility.ScreenPointToLocalPointInRectangle(
      rectTransform.parent.GetComponent<RectTransform>(),  
      eventData.position, 
      eventData.pressEventCamera, 
      out position);
    rectTransform.anchoredPosition = position;
  }
  public void OnEndDrag(PointerEventData eventData)
  {
    canvasGroup.alpha = 1f; 
    canvasGroup.blocksRaycasts = true; 
    if (eventData.pointerCurrentRaycast.gameObject != null && 
        (eventData.pointerCurrentRaycast.gameObject.transform == insectGameManager.PoisonousTray || 
         eventData.pointerCurrentRaycast.gameObject.transform == insectGameManager.NonPoisonousTray))
    {
      return;
    }
    OnRemoveFromTray();
  }
  public void OnRemoveFromTray()
  {
    insectGameManager.RemoveInsect(Index, transform);
  }
}