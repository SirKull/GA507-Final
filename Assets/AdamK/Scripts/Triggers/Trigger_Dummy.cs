using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_Dummy : MonoBehaviour
{
    public BossTurret bossTurret;
    public bool isTriggered = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "turret")
        {
            isTriggered = true;
            bossTurret.shield.SetActive(false);
            bossTurret.ShootDummy();
            other.GetComponent<DummyTurret>().Death();
        }
    }
}
