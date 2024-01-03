using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint1 : MonoBehaviour
{
    public LevelManager levelManager;
    public GameObject playerTurretContainer;
    public PlayerTurret playerTurret;

    public float checkPointEnemies;
    public float checkPointHealth;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        levelManager.GetComponent<LevelManager>().enemiesKilled = checkPointEnemies;
        playerTurret.GetComponent<PlayerTurret>().health = checkPointHealth;
    }
}
