using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserEffect : MonoBehaviour
{
    public float destroyTimer = 1.2f;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Spawned");
    }

    // Update is called once per frame
    void Update()
    {
/*        destroyTimer -= Time.deltaTime;
        if(destroyTimer >= 0)
        {
            Destroy(gameObject);
        }*/
    }
}
