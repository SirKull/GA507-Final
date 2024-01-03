using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Turret : MonoBehaviour
{
    public LevelManager levelManager;
    public GameObject turret;

    //public Animator animator;

    public Transform player;
    public Transform head;
    public Transform leftFirePoint;
    public Transform rightFirePoint;

    public ParticleSystem explosion;

    public float distance;
    public float fireThreshold = 15f;

    public GameObject bulletPrefab;
    public float fireChargeUpTimer = 2f;
    public float fireTimer = 0f;

    public bool isDestroyed = false;
    public bool offline = false;

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
        if(isDestroyed == false)
        {
            if (player != null)
            {
                distance = Vector3.Distance(transform.position, player.position);

                //animator.SetBool("PlayerNotFound", true);
                //animator.SetBool("PlayerFound", false);
                if (distance < fireThreshold)
                {
                    head.LookAt(player.position);
                    fireTimer = fireTimer + Time.deltaTime;

                    //animator.SetBool("PlayerNotFound", false);
                    //animator.SetBool("PlayerFound", true);

                    if (fireTimer >= fireChargeUpTimer)
                    {
                        source.Play();
                        Debug.Log("fired");
                        GameObject laser = Instantiate(bulletPrefab);
                        laser.transform.position = leftFirePoint.transform.position;
                        laser.transform.rotation = leftFirePoint.transform.rotation;
                        fireTimer = 0f;
                    }
                }
            }
        }

        if(isDestroyed == true)
        {
            StartCoroutine(Death());
        }
        
    }
    IEnumerator Death()
    {
        offline = true;
        Destroy(turret);
        explosion.Play();
        yield return new WaitForSeconds(0.8f);
        Destroy(gameObject);
    }
    public void Hit()
    {
        Debug.Log("Ow");
        levelManager.OnDestroy();
        isDestroyed = true;
    }
}
