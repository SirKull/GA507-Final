using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger3 : MonoBehaviour
{
    public LevelManager levelManager;

    public bool isTriggered = false;

    public bool balcony1Spawned = false;
    public bool balcony2Spawned = false;
    public bool balcony3Spawned = false;
    public bool balcony4Spawned = false;

    public Transform balconySpawn1;
    public Transform balconySpawn2;
    public Transform balconySpawn3;
    public Transform balconySpawn4;

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
        if (isTriggered == true)
        {
            SpawnEnemies();
        }
    }

    public void SpawnEnemies()
    {
        spawnTimer -= Time.deltaTime;

        if (spawnTimer <= 0 && balcony1Spawned == false)
        {
            GameObject enemy1 = Instantiate(bulletTurretPrefab, balconySpawn1.transform.position, Quaternion.identity);
            enemy1.GetComponent<Bullet_Turret>().levelManager = levelManager;
            enemy1.GetComponent<Bullet_Turret>().fireChargeUpTimer = Random.Range(minFire, maxFire);
            spawnTimer = 2f;
            balcony1Spawned = true;
        }
        if (spawnTimer <= 0 && balcony2Spawned == false)
        {
            GameObject enemy2 = Instantiate(bulletTurretPrefab, balconySpawn2.transform.position, Quaternion.identity);
            enemy2.GetComponent<Bullet_Turret>().levelManager = levelManager;
            enemy2.GetComponent<Bullet_Turret>().fireChargeUpTimer = Random.Range(minFire, maxFire);
            spawnTimer = 2f;
            balcony2Spawned = true;
        }
        if (spawnTimer <= 0 && balcony3Spawned == false)
        {
            GameObject enemy3 = Instantiate(bulletTurretPrefab, balconySpawn3.transform.position, Quaternion.identity);
            enemy3.GetComponent<Bullet_Turret>().levelManager = levelManager;
            enemy3.GetComponent<Bullet_Turret>().fireChargeUpTimer = Random.Range(minFire, maxFire);
            spawnTimer = 2f;
            balcony3Spawned = true;
        }
        if (spawnTimer <= 0 && balcony4Spawned == false)
        {
            GameObject enemy4 = Instantiate(bulletTurretPrefab, balconySpawn4.transform.position, Quaternion.identity);
            enemy4.GetComponent<Bullet_Turret>().levelManager = levelManager;
            enemy4.GetComponent<Bullet_Turret>().fireChargeUpTimer = Random.Range(minFire, maxFire);
            spawnTimer = 2f;
            balcony4Spawned = true;
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
