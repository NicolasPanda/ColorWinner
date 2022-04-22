using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityTimer;

public class BulletSpawner : MonoBehaviour
{

    [SerializeField]
    private float baloonInterval = 1f;
    [SerializeField] 
    private float bulletSpeed = 5f;
    [SerializeField]
    private GameObject blueBaloon;
    [SerializeField] 
    private GameObject redBaloon;
    [SerializeField] 
    private GameObject bulletSpawner;
    [SerializeField]
    private bool isBlueNext = true;
    
    
    // Start is called before the first frame update
    void Start()
    {
        Timer.Register(baloonInterval, ShootBullet, isLooped: true);
    }

    private void ShootBullet()
    {
        if (isBlueNext)
        {
            isBlueNext = !isBlueNext;
            var position = bulletSpawner.transform.position;
            var t = transform;
            var newBullet = Instantiate(blueBaloon);
            newBullet.transform.position = position;
            newBullet.transform.rotation = Quaternion.Euler(0, Random.Range(-35, 35), 0) * transform.rotation;
            newBullet.GetComponent<Rigidbody>().velocity = newBullet.transform.forward * bulletSpeed;
        }
        else
        {
            isBlueNext = !isBlueNext;
            var position = bulletSpawner.transform.position;
            var t = transform;
            var newBullet = Instantiate(redBaloon);
            newBullet.transform.position = position;
            newBullet.transform.rotation = Quaternion.Euler(0, Random.Range(-35, 35), 0) * transform.rotation;
            newBullet.GetComponent<Rigidbody>().velocity = newBullet.transform.forward * bulletSpeed;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
