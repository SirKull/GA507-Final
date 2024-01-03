using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTurret : MonoBehaviour
{
    public HUDController hudController;

    public bool isTriggered = false;
    public bool bossFightBegin = true;

    public int layerMask = 1 << 6;

    public Transform player;
    public Transform dummy;
    public Transform bossTurret;
    public Transform bossTurretHead;
    public Transform firePoint;
    public Transform outerShieldRotatePoint;
    public Transform innerShieldRotatePoint;
    public GameObject shield;

    [Header("Outer Shields")]
    public Transform outerShield1;
    public Transform outerShield2;
    public Transform outerShield3;
    public Transform outerShield4;

    [Header("Inner Shields")]
    public Transform innerShield1;
    public Transform innerShield2;
    public Transform innerShield3;
    public Transform innerShield4;

    [Header("Stats")]
    public float health = 15f;
    public float maxHealth = 15f;
    public float rotateSpeed = 2.5f;
    public float weaponChargeTimer = 5f;
    public float range = 12f;
    public float laserDuration = 0.4f;

    [Header("Particles")]
    public ParticleSystem sparks1;
    public ParticleSystem sparks2;
    public ParticleSystem sparks3;
    public ParticleSystem sparks4;
    public ParticleSystem smoke;

    LineRenderer laserLine;

    public bool bossTurretActive = false;

    public AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        laserLine = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindWithTag("Player").transform;
        if (isTriggered == true)
        {
            bossTurretActive = true;
        }

        if (bossTurretActive == true)
        {
            shield.SetActive(false);
            hudController.BossFight();
            ShieldRotate();

            bossTurretHead.LookAt(player.position - Vector3.up * 1.8f);
            weaponChargeTimer -= Time.deltaTime;

            //animator.SetBool("PlayerNotFound", false);
            //animator.SetBool("PlayerFound", true);

            if (weaponChargeTimer == 5)
            {

            }

            if (weaponChargeTimer <= 0)
            {
                //source.Play();

                Shoot();
                weaponChargeTimer = 5f;
            }
        }
        if (bossTurretActive == false) { return; }

        if (health <= 10)
        {
            sparks1.Play();
            sparks3.Play();
        }

        if(health <= 5)
        {
            sparks4.Play();
            sparks2.Play();
            smoke.Play();
        }

        if(health <= 0)
        {
            bossTurretActive = false;
            player.GetComponent<PlayerTurret>().bezierWalkerBoss.enabled = false;
            hudController.Win();
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && bossFightBegin == true)
        {
            isTriggered = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            isTriggered = false;
            bossFightBegin = false;
        }
    }

    public void Shoot()
    {
        Debug.Log("fired");

        source.Play();
        laserLine.SetPosition(0, firePoint.position);
        RaycastHit hit;

        if (Physics.Raycast(firePoint.position, firePoint.transform.forward, out hit, range, layerMask))
        {
            PlayerTurret hero = hit.transform.GetComponent<PlayerTurret>();
            if (hero != null)
            {
                laserLine.SetPosition(1, hit.point);
                Debug.Log("GetPlayer");
                hero.GetComponent<PlayerTurret>().Damage(3f);
            }
        }
        else
        {
            Debug.Log("Miss");
            laserLine.SetPosition(1, firePoint.position + (firePoint.transform.forward * range));
        }
        StartCoroutine(LaserTrail());
    }

    public void ShootDummy()
    {
        dummy = GameObject.FindWithTag("turret").transform;
        bossTurretHead.LookAt(dummy.position - Vector3.up * 1.8f);

        laserLine.SetPosition(0, firePoint.position);
        RaycastHit hit;

        if (Physics.Raycast(firePoint.position, firePoint.transform.forward, out hit, range))
        {
            DummyTurret turret = hit.transform.GetComponent<DummyTurret>();
            if (turret != null)
            {
                laserLine.SetPosition(1, hit.point);
            }
        }
        StartCoroutine(LaserTrail());
    }

    IEnumerator LaserTrail()
    {
        laserLine.enabled = true;
        yield return new WaitForSeconds(laserDuration);
        laserLine.enabled = false;
    }

    public void Damage()
    {
        health--;
    }

    public void ShieldRotate()
    {
        Debug.Log("ShieldRotate");
        if (outerShield1 != null)
        {
            outerShield1.transform.RotateAround(outerShieldRotatePoint.transform.position, Vector3.up, rotateSpeed * Time.deltaTime);
        }
        if (outerShield2 != null)
        {
            outerShield2.transform.RotateAround(outerShieldRotatePoint.transform.position, Vector3.up, rotateSpeed * Time.deltaTime);
        }
        if (outerShield3 != null)
        {
            outerShield3.transform.RotateAround(outerShieldRotatePoint.transform.position, Vector3.up, rotateSpeed * Time.deltaTime);
        }
        if (outerShield4 != null)
        {
            outerShield4.transform.RotateAround(outerShieldRotatePoint.transform.position, Vector3.up, rotateSpeed * Time.deltaTime);
        }
        if(innerShield1 != null)
        {
            innerShield1.transform.RotateAround(innerShieldRotatePoint.transform.position, Vector3.up, -rotateSpeed * Time.deltaTime);
        }
        if(innerShield2 != null)
        {
            innerShield2.transform.RotateAround(innerShieldRotatePoint.transform.position, Vector3.up, -rotateSpeed * Time.deltaTime);
        }
        if(innerShield3 != null)
        {
            innerShield3.transform.RotateAround(innerShieldRotatePoint.transform.position, Vector3.up, -rotateSpeed * Time.deltaTime);
        }
        if(innerShield4 != null)
        {
            innerShield4.transform.RotateAround(innerShieldRotatePoint.transform.position, Vector3.up, -rotateSpeed * Time.deltaTime);
        }
        else
        {
            return;
        }
    }
}
