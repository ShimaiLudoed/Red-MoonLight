using Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

public class Teleport : MonoBehaviour
{
    [SerializeField] private Transform teleportLocation;
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Transform cameraPlayer;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (LayerMaskCheck.ContainsLayer(playerLayer, other.gameObject.layer))
        {
            InputListener.OnInteract += TeleportToPoint;
        }
    }

    private void TeleportToPoint()
    {
        cameraPlayer.position = teleportLocation.position;
        playerTransform.position = teleportLocation.position;
        InputListener.OnInteract -= TeleportToPoint;
    }
}
