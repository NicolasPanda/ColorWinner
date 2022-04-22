using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInputManager))]
public class PlayerManager : MonoBehaviour
{
    [SerializeField]
    private GameObject playerRed;
    [SerializeField]
    private GameObject playerBlue;
    private PlayerInputManager PlayerInputManager;
    private void Awake()
    {
        PlayerInputManager = GetComponent<PlayerInputManager>();
    }

    public void OnPlayerJoined(PlayerInput playerInput)
    {

        var playercount = PlayerInputManager.playerCount;
        if (playercount == 1)
        {
            Instantiate(playerBlue, playerInput.gameObject.transform);
            playerInput.gameObject.GetComponent<PlayerController>().playerType = PlayerType.PlayerBlue;
        }
        if (playercount == 2)
        {
            Instantiate(playerRed, playerInput.gameObject.transform);
            playerInput.gameObject.GetComponent<PlayerController>().playerType = PlayerType.PlayerRed;
        }
    }
}
