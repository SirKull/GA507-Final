using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Shield : MonoBehaviour
{
    public float shieldLifetime = 0.8f;
    public PlayerTurret playerTurret;

    public AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        source.Play();
    }

    // Update is called once per frame
    void Update()
    {
        shieldLifetime -= Time.deltaTime;

        if(shieldLifetime <= 0)
        {
            playerTurret.shieldsUp = false;
            Destroy(gameObject);
        }
    }
}
