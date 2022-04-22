using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityTimer;

public class Bullet : MonoBehaviour
{
    public PlayerType type = PlayerType.PlayerBlue;
    
    [SerializeField]
    private float deSpawnTime = 1f;

    private Timer _deSpawnTimeTimer;
    private void Start()
    {
        _deSpawnTimeTimer = Timer.Register(deSpawnTime, () => Destroy(gameObject));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (type == PlayerType.PlayerRed)
        {
            if (other.gameObject.layer != LayerMask.NameToLayer("Blue")) return;
            //TODO: +1 point for playerREd
            _deSpawnTimeTimer.Cancel();
            Destroy(other.gameObject);
        }
        if (type == PlayerType.PlayerBlue)
        {
            if (other.gameObject.layer != LayerMask.NameToLayer("Red")) return;
            //TODO: +1 point for playerBlue
            _deSpawnTimeTimer.Cancel();
            Destroy(other.gameObject);
        }
    }
}
