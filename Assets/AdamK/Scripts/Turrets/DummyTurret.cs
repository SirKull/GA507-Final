using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyTurret : MonoBehaviour
{
    public LevelManager levelManager;
    public ParticleSystem explosion;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Death()
    {
        StartCoroutine(DeathSequence());
    }

    IEnumerator DeathSequence()
    {
        explosion.Play();
        yield return new WaitForSeconds(0.8f);
        Destroy(gameObject);
    }
}
