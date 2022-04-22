using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInputManager))]
public class PlayerManager : MonoBehaviour
{
    [SerializeField]
    private Material materialRed;
    [SerializeField]
    private Material materialBlue;
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
            playerInput.gameObject.GetComponent<PlayerController>().playerType = PlayerType.PlayerBlue;
            playerInput.gameObject.transform.GetChild(0).gameObject.GetComponent<MeshRenderer>().material = materialBlue;
        }
        if (playercount == 2)
        {
            playerInput.gameObject.GetComponent<PlayerController>().playerType = PlayerType.PlayerRed;
            playerInput.gameObject.transform.GetChild(0).gameObject.GetComponent<MeshRenderer>().material = materialRed;
        }
    }
}
