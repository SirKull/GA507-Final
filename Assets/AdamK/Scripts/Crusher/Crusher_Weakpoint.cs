using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crusher_Weakpoint : MonoBehaviour
{
    public CrusherTrigger crusherTrigger;
    public ParticleSystem smoke;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Hit()
    {
        crusherTrigger.isDestroyed = true;
        Debug.Log("Ow");
        smoke.Play();
    }
}
