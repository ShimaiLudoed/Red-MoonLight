using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Player
{
  public abstract class APlayerPanel : MonoBehaviour
  {
    protected List<ScriptableObject> _objects;
    [SerializeField] private GameObject Panel;
    [SerializeField] private Button ButtonPrefab;
    [SerializeField] private Transform ListContainer;
    [SerializeField] private TMP_Text DetailsText;
    [SerializeField] private Image DetailsImage;
    private bool _isPanelOpen = false;
    
    
    public virtual void AddItem(ScriptableObject objects)
    {
      _objects.Add(objects);
    }
    
    
    
    public void ToggleQuestPanel()
    {
      _isPanelOpen = !_isPanelOpen;
      Panel.SetActive(_isPanelOpen);

      if (_isPanelOpen)
      {
        Display();
      }
      else
      {
        ClearList();
      }
    }
    void Display()
    {
      ClearList();

      foreach (var objects in _objects)
      {
        Button questButton = Instantiate(ButtonPrefab, ListContainer);
        questButton.GetComponentInChildren<TMP_Text>().text = "0";
        //TMP_Text objectiveText = questButton.transform.Find("QuestObjectiveText").GetComponent<TMP_Text>();
        //if (objectiveText != null)
        //{
          //objectiveText.text = $"Цель: {quest.Objective}";
        //}
        questButton.onClick.AddListener(() => ShowDetails(objects));
      }
    }

    void ShowDetails(ScriptableObject objects)
    {
      DetailsText.text = $" Название:";
      if (/*quest.QuestGiver.Image != null &&*/ DetailsImage != null)
      {
        //DetailsImage.sprite = quest.QuestGiver.Image;
        DetailsImage.gameObject.SetActive(true);
      }
      else
      {
        DetailsImage.gameObject.SetActive(false);
      }
    }

    void ClearList()
    {
      foreach (Transform child in ListContainer)
      {
        Destroy(child.gameObject);
      }

      if (DetailsImage != null)
      { 
        //questDetailsImage.gameObject.SetActive(false); 
        // questDetailsImage.sprite = null; 
      }
    }
  }
}
