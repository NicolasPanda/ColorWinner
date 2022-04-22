using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityTimer;

public class Baloon : MonoBehaviour
{
    [SerializeField]
    private float deSpawnTime = 15f;

    private Timer _deSpawnTimeTimer;
    private void Start()
    {
        _deSpawnTimeTimer = Timer.Register(deSpawnTime, () => Destroy(gameObject));
    }

    private void OnDestroy()
    {
        _deSpawnTimeTimer.Cancel();
    }
}
