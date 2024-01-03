using BezierSolution;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger2 : MonoBehaviour
{
    public LevelManager levelManager;
    public BezierWalkerWithSpeed bezierWalkerWithSpeed;

    public bool isTriggered = false;
    public bool enemiesDead = false;

    public bool box1Spawned = false;
    public bool box2Spawned = false;
    public bool box3Spawned = false;
    public bool container1Spawned = false;
    public bool ground1Spawned = false;
    public bool balcony1Spawned = false;

    public Transform boxSpawn1;
    public Transform boxSpawn2;
    public Transform boxSpawn3;
    public Transform containerSpawn1;
    public Transform groundSpawn1;
    public Transform balconySpawn1;

    public float spawnTimer = 2f;
    public float minFire = 1.2f;
    public float maxFire = 2.2f;

    public GameObject bulletTurretPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isTriggered == true && enemiesDead == false)
        {
            bezierWalkerWithSpeed.enabled = false;
            SpawnEnemies();
        }
        if (levelManager.enemiesKilled == 13)
        {
            enemiesDead = true;
            bezierWalkerWithSpeed.enabled = true;
        }
    }

    public void SpawnEnemies()
    {
        spawnTimer -= Time.deltaTime;

        if (spawnTimer <= 0 && box1Spawned == false)
        {
            GameObject enemy1 = Instantiate(bulletTurretPrefab, boxSpawn1.transform.position, Quaternion.identity);
            enemy1.GetComponent<Bullet_Turret>().levelManager = levelManager;
            enemy1.GetComponent<Bullet_Turret>().fireChargeUpTimer = Random.Range(minFire, maxFire);
            spawnTimer = 2f;
            box1Spawned = true;
        }
        if (spawnTimer <= 0 && box2Spawned == false)
        {
            GameObject enemy2 = Instantiate(bulletTurretPrefab, boxSpawn2.transform.position, Quaternion.identity);
            enemy2.GetComponent<Bullet_Turret>().levelManager = levelManager;
            enemy2.GetComponent<Bullet_Turret>().fireChargeUpTimer = Random.Range(minFire, maxFire);
            spawnTimer = 2f;
            box2Spawned = true;
        }
        if (spawnTimer <= 0 && box3Spawned == false)
        {
            GameObject enemy3 = Instantiate(bulletTurretPrefab, boxSpawn3.transform.position, Quaternion.identity);
            enemy3.GetComponent<Bullet_Turret>().levelManager = levelManager;
            enemy3.GetComponent<Bullet_Turret>().fireChargeUpTimer = Random.Range(minFire, maxFire);
            spawnTimer = 2f;
            box3Spawned = true;
        }
        if (spawnTimer <= 0 && container1Spawned == false)
        {
            GameObject enemy4 = Instantiate(bulletTurretPrefab, containerSpawn1.transform.position, Quaternion.identity);
            enemy4.GetComponent<Bullet_Turret>().levelManager = levelManager;
            enemy4.GetComponent<Bullet_Turret>().fireChargeUpTimer = Random.Range(minFire, maxFire);
            spawnTimer = 2f;
            container1Spawned = true;
        }
        if (spawnTimer <= 0 && ground1Spawned == false)
        {
            GameObject enemy5 = Instantiate(bulletTurretPrefab, groundSpawn1.transform.position, Quaternion.identity);
            enemy5.GetComponent<Bullet_Turret>().levelManager = levelManager;
            enemy5.GetComponent<Bullet_Turret>().fireChargeUpTimer = Random.Range(minFire, maxFire);
            spawnTimer = 2f;
            ground1Spawned = true;
        }
        if (spawnTimer <= 0 && balcony1Spawned == false)
        {
            GameObject enemy6 = Instantiate(bulletTurretPrefab, balconySpawn1.transform.position, Quaternion.identity);
            enemy6.GetComponent<Bullet_Turret>().levelManager = levelManager;
            enemy6.GetComponent<Bullet_Turret>().fireChargeUpTimer = Random.Range(minFire, maxFire);
            spawnTimer = 2f;
            balcony1Spawned = true;
        }
        else
        {
            return;
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isTriggered = true;
        }
    }
}
