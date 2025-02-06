using UnityEngine;

namespace Core
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private Transform player; 
        [SerializeField] private float offsetX ;
        [SerializeField] private float smoothSpeed; 

        void LateUpdate()
        {
            if (player != null)
            {
                Vector3 desiredPosition = new Vector3(player.position.x + offsetX, transform.position.y, transform.position.z);
                Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
                transform.position = smoothedPosition;
            }
        }
    }
}
