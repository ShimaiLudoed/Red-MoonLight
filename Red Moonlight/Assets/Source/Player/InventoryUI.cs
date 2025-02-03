using UnityEngine;
using UnityEngine.UI;
namespace Player
{
  public class InventoryUI : MonoBehaviour
  {
    //public GameObject inventoryPanel; // Ссылка на панель инвентаря
    private bool isInventoryOpen = false; // Статус открытия инвентаря

    private void Start()
    {
      //inventoryPanel.SetActive(false); // Панель инвентаря скрыта при запуске
      Debug.Log("Инвентарь инициализирован и скрыт.");
    }

    private void Update()
    {
      // Проверка нажатия клавиши "I" для открытия/закрытия инвентаря
      if (Input.GetKeyDown(KeyCode.I))
      {
        ToggleInventory();
      }
    }

    public void ToggleInventory()
    {
      isInventoryOpen = !isInventoryOpen;
      //inventoryPanel.SetActive(isInventoryOpen); // Переключаем видимость панели
        
      if (isInventoryOpen)
      {
        Debug.Log("Инвентарь открыт.");
        // Вы можете вызвать метод отображения инвентаря
        GetComponent<Inventory>().ShowInventory();
      }
      else
      {
        Debug.Log("Инвентарь закрыт.");
      }
    }
  }
}