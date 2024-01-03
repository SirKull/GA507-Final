using BezierSolution;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurret : MonoBehaviour
{
    public LevelManager levelManager;
    public BulletHoleImpact bulletHoleImpactPrefab;
    public LaserEffect laserEffectPrefab;
    public Transform head;
    public Transform body;
    public Camera playerCamera;
    public HUDController hudController;

    //public Animator animator;

    public int layerMask = 1 << 7;

    //stats
    [Header ("Stats")]
    public float health = 15f;
    public float maxHealth = 15f;
    public float range = 10f;

    //bezier 
    [Header ("Bezier")]
    public BezierWalkerWithSpeed bezierWalkerFactory;
    public BezierWalkerWithSpeed bezierWalkerBoss;

    //laser
    [Header("Laser")]
    public float laserTimer;
    public float laserDuration = 0.07f;
    public float laserCooldown = 0.8f;
    LineRenderer laserLine;
    public AudioSource source;

    //shield
    [Header("Shield")]
    public GameObject playerShieldPrefab;
    public float shieldTimer = 4f;
    public float shieldCooldown = 4f;
    public bool shieldsUp = false;
    public float shieldLifetime = 0.8f;

    //ultimate 
    /*[Header("Ultimate")]
    public float ultimate;
    public bool isUlt = false;
    public float maxUltimate = 4f;
    public float ultimateTimer = 1.5f;
    public Transform firePoint;*/

    //movement 
    [Header ("Head Movement")]
    public Vector3 currentEulerAngles;
    public float headX;
    public float headY;
    public float turretSpeed = 50f;
    public float headMin = -22f;
    public float headMax = 30f;
   
    //raycast
    public Ray ray;

    // Start is called before the first frame update
    void Start()
    {
        currentEulerAngles = head.localEulerAngles;
        laserLine = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        laserTimer += Time.deltaTime;
        shieldTimer -= Time.deltaTime;
        health = Mathf.Clamp(health, 0, maxHealth);
        shieldTimer = Mathf.Clamp(shieldTimer, 0, shieldCooldown);

        //shooting
        if (Input.GetMouseButtonDown(0) && laserTimer > laserCooldown)
        {
            Shoot();
            source.Play();
        }

        //ultimate
       /* if (Input.GetMouseButtonDown(1))
        {
            if(ultimate == 4)
            {
                isUlt = true;
                ultimateTimer -= Time.deltaTime;
                ultimateTimer = Mathf.Clamp(ultimateTimer, 0, maxUltimate);
                if(ultimateTimer >= 0 && isUlt == true)
                {
                    Ultimate();
                }
                if(ultimateTimer == 0)
                {
                    isUlt = false;
                    ultimate = 0;
                }
            }
        }*/

        //shield
        //gets the key S and then calls the shield function
        if (Input.GetKeyDown(KeyCode.S))
        {
            Shield();
        }

        //looking around
        //calling euler angles as the new vector3 of the player's mouse
        headX = -Input.GetAxis("Mouse Y");
        headY = Input.GetAxis("Mouse X");

        currentEulerAngles += new Vector3(headX, headY) * Time.deltaTime * turretSpeed;
        currentEulerAngles.x = Mathf.Clamp(currentEulerAngles.x, headMin, headMax);

        head.eulerAngles = currentEulerAngles;

        //death
        if (health == 0)
        {
            Death();
        }
    }

    public void Shoot()
    {
        laserTimer = 0;
        Debug.Log("Shoot");

        laserLine.SetPosition(0, head.position);
        ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, range, layerMask))
        {
            Vector3 hitPosition = hit.point;
            laserLine.SetPosition(1, hit.point);
            Instantiate(bulletHoleImpactPrefab, hitPosition, Quaternion.LookRotation(hit.normal), hit.transform);
            Instantiate(laserEffectPrefab, hitPosition, Quaternion.LookRotation(hit.normal), hit.transform);

            Bullet_Turret turret = hit.transform.GetComponent<Bullet_Turret>();
            if (turret != null)
            {
                Debug.Log("GetTurret");
                turret.GetComponent<Bullet_Turret>().Hit();
                //ultimate++;

            }

            Crusher_Weakpoint crusher = hit.transform.GetComponent<Crusher_Weakpoint>();
            if (crusher != null)
            {
                Debug.Log("GetCrusher");
                crusher.Hit();

            }

            BossTurret_Shield bossTurretShield = hit.transform.GetComponent<BossTurret_Shield>();
            if(bossTurretShield != null)
            {
                Debug.Log("GetShield");
                bossTurretShield.GetComponent<BossTurret_Shield>().Hit();
                //ultimate++;

            }

            BossTurret_Pillar bossTurretPillar = hit.transform.GetComponent<BossTurret_Pillar>();
            if(bossTurretPillar != null)
            {
                Debug.Log("GetBossHealth");
                bossTurretPillar.GetComponent<BossTurret_Pillar>().PillarHit();
            }
        }
        else
        {
            laserLine.SetPosition(1, (head.position - Vector3.up * 1f) + (head.transform.forward * range));
        }
        StartCoroutine(LaserTrail());
    }

    public void Shield()
    {
        if (shieldTimer <= 0)
        {
            Instantiate(playerShieldPrefab, body);
            shieldTimer = 4f;
            StartCoroutine(ShieldsUp());
        }
    }

    /*public void Ultimate()
    {
            Debug.Log("Ultimate");

            laserLine.SetPosition(0, head.position);
            ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hit;

            if (Physics.Raycast(firePoint.position, firePoint.transform.forward, out hit, range, layerMask))
            {
                Vector3 hitPosition = hit.point;
                laserLine.SetPosition(1, hit.point);
                Instantiate(bulletHoleImpactPrefab, hitPosition, Quaternion.LookRotation(hit.normal), hit.transform);

                Bullet_Turret turret = hit.transform.GetComponent<Bullet_Turret>();
                if (turret != null)
                {
                    Debug.Log("GetTurret");
                    turret.GetComponent<Bullet_Turret>().Hit();
                    ultimate++;

                }

                Crusher_Weakpoint crusher = hit.transform.GetComponent<Crusher_Weakpoint>();
                if (crusher != null)
                {
                    Debug.Log("GetCrusher");
                    crusher.Hit();

                }

                BossTurret_Shield bossTurretShield = hit.transform.GetComponent<BossTurret_Shield>();
                if (bossTurretShield != null)
                {
                    Debug.Log("GetShield");
                    bossTurretShield.GetComponent<BossTurret_Shield>().Hit();
                    ultimate++;

                }

                BossTurret_Pillar bossTurretPillar = hit.transform.GetComponent<BossTurret_Pillar>();
                if (bossTurretPillar != null)
                {
                    Debug.Log("GetBossHealth");
                    bossTurretPillar.GetComponent<BossTurret_Pillar>().PillarHit();
                }
            }
            else
            {
                laserLine.SetPosition(1, head.position + (head.transform.forward * range));
            }
    }*/

    IEnumerator ShieldsUp()
    {
        shieldsUp = true;
        yield return new WaitForSeconds(shieldLifetime);
        shieldsUp = false;
    }
    IEnumerator LaserTrail()
    {
        laserLine.enabled = true;
        yield return new WaitForSeconds(laserDuration);
        laserLine.enabled = false;
    }
    public void Damage(float damage)
    {
        if(shieldsUp == false)
        {
            health = health - damage;
        }

    }

    public void FactoryComplete()
    {
        bezierWalkerFactory.enabled = false;
        bezierWalkerBoss.enabled = true;
    }

  public void GetHealth()
    {
        health += 8f;
    }

    public void Death()
    {
        Destroy(gameObject);
        hudController.Lose();
    }
}
