using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTurret_Pillar : MonoBehaviour
{
    public BossTurret bossTurret;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PillarHit()
    {
        bossTurret.Damage();
    }
}
