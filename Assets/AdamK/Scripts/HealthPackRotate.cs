using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPackRotate : MonoBehaviour
{
    public GameObject healthPack;
    public GameObject rotatePoint;
    public float speed = 70f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        healthPack.transform.RotateAround(rotatePoint.transform.position, Vector3.up, speed * Time.deltaTime);
    }
}
