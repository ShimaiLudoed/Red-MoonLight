using UnityEngine;
using UnityEngine.UI;
using Utils;

namespace UI
{
    public class InteractionIcon : MonoBehaviour
    {
        [SerializeField] private Image icon; 
        [SerializeField] private LayerMask player;


        private void Start()
        {
            icon.gameObject.SetActive(false); 
        }

        private void Update()
        {
            if (icon.gameObject.activeSelf)
            {
                Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);
                icon.transform.position = screenPos + new Vector3(0, 100, 0); 
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Debug.Log("Взаимодействие с объектом!");
                    icon.gameObject.SetActive(false); 
                }
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (LayerMaskCheck.ContainsLayer(player, other.gameObject.layer))
            {
                icon.gameObject.SetActive(true); 
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (LayerMaskCheck.ContainsLayer(player, other.gameObject.layer))
            {
                icon.gameObject.SetActive(false); 
            }
        }
    }
}
