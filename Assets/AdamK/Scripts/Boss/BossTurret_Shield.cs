using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTurret_Shield : MonoBehaviour
{
    public GameObject shield;
    public int health = 6;

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
        health--;
        if (health == 5)
        {
            shield.GetComponent<Renderer>().material.color = new Color(1f, 0.91f, 0.91f, 1f);
        }
        if (health == 4)
        {
            shield.GetComponent<Renderer>().material.color = new Color(1f, 0.7f, 0.7f, 1f);
        }
        if (health == 3)
        {
            shield.GetComponent<Renderer>().material.color = new Color(1f, 0.5f, 0.5f, 1f);
        }
        if (health == 2)
        {
            shield.GetComponent<Renderer>().material.color = new Color(1f, 0.35f, 0.35f, 1f);
        }
        if (health == 1)
        {
            shield.GetComponent<Renderer>().material.color = new Color(1f, 0.2f, 0.2f, 1f);
        }
        if (health <= 0)
        {
            Destroy(gameObject);
        }
        else { return; }
    }

}
