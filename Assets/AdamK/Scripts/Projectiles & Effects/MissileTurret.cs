using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileTurret : MonoBehaviour
{
    public PlayerTurret playerTurret;

    public Transform player;
    public Transform head; 
    public Transform firePoint;

    public float distance;
    public float fireThreshold = 25f;

    public GameObject missilePrefab;
    public float fireTimer;
    public float fireCooldown;

    public AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        player.position = player.transform.position;
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
