using Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

public class Teleport : MonoBehaviour
{
    [SerializeField] private Transform teleportLocation; // Место, кудаTeleport должно телепортировать игрока
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private Transform playerTransform;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (LayerMaskCheck.ContainsLayer(playerLayer, other.gameObject.layer))
        {
            InputListener.OnInteract += TeleportToPoint;
        }
    }

    private void TeleportToPoint()
    {
        playerTransform.position = teleportLocation.position;
        InputListener.OnInteract -= TeleportToPoint;
    }
}
