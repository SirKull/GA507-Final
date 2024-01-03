using BezierSolution;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public HUDController hudController;

    public Transform trigger_Spawn;
    public Transform dummySpawn1;
    public Transform dummySpawn2;

    public BezierWalkerWithSpeed bezierWalkerWithSpeed;
    public BezierSpline factoryBezier;

    public GameObject hero_TurretPrefab;
    public GameObject dummy_TurretPrefab;

    public float enemiesKilled;

    // Start is called before the first frame update
    void Start()
    {
        Setup(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnDestroy()
    {
        enemiesKilled++;
    }

    public void Setup()
    {
        Cursor.lockState = CursorLockMode.Locked;

        hudController.containerEnemies.SetActive(true);
        hudController.containerBoss.SetActive(false);

        //Spawn Player
        //GameObject player = Instantiate(hero_TurretPrefab);
        //player.GetComponent<BezierWalkerWithSpeed>().spline = factoryBezier;
        //player.GetComponent<BezierWalkerWithSpeed>().NormalizedT = 0f;


        //Spawn Dummy 1
        GameObject dummy1 = Instantiate(dummy_TurretPrefab);
        dummy1.GetComponent<BezierWalkerWithSpeed>().spline = factoryBezier;
        dummy1.GetComponent<BezierWalkerWithSpeed>().NormalizedT = 0.07f;

        //Spawn Dummy 2
        GameObject dummy2 = Instantiate(dummy_TurretPrefab);
        dummy2.GetComponent<BezierWalkerWithSpeed>().spline = factoryBezier;
        dummy2.GetComponent<BezierWalkerWithSpeed>().NormalizedT = 0.1f;


    }

    public void DestroyTurret()
    {

    }
}
