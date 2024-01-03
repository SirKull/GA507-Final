using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmTrigger : MonoBehaviour
{
    public PlayerTurret playerTurret;
    public DummyTurret dummyTurret;
    public LevelManager levelManager;

    public AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.GetComponent<PlayerTurret>().Death();
            source.Play();
        }
        if (other.gameObject.tag == "turret")
        {
            other.GetComponent<DummyTurret>().Death();
            source.Play();
        }
    }

}
