using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage = 1f;
    public float speed = 25f;
    public float travelTime = 4f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        travelTime -= Time.deltaTime;
        if(travelTime <= 0)
        {
            Destroy(gameObject);
        }
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Player Hit");
            PlayerTurret turret = other.gameObject.GetComponentInParent<PlayerTurret>();
            turret.Damage(damage);
            Destroy(gameObject);
        }
    }
}
