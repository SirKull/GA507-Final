using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public TargetManager targetManager;

    public bool movingLeft;
    public float minSpeed = 3f;
    public float maxSpeed = 15f;
    public float speed;
    public float minScale = 0f;
    public float maxScale = 3f;
    public float scale;
    public int targetHealth;
    public int minHealth = 1;
    public int maxHealth = 4;

    public Vector3 leftBound;
    public Vector3 rightBound;
    public Vector3 scaleChange;

    //Pass the target Y position
    //pick a random X position between min and max
    //pick a random direction (left or right)
    //Reference to TargetManager
    //determine left and right positions

    public void Init(float y, Vector3 min, Vector3 max, TargetManager manager)
    {
        transform.position = new Vector3(Random.Range(min.x, max.x), y, 0);
        movingLeft = Random.value > 0.5f;
        targetManager = manager;

        leftBound = new Vector3(min.x, y, 0);
        rightBound = new Vector3(max.x, y, 0);
    }
    // Start is called before the first frame update
    void Start()
    {
        targetHealth = Random.Range(minHealth, maxHealth);
        speed = Random.Range(minSpeed, maxSpeed);
        scale = Random.Range(minScale, maxScale);
        scaleChange = new Vector3(scale, 0.1f, scale);
        this.transform.localScale += scaleChange;
    }

    // Update is called once per frame
    void Update()
    {
        if(targetManager.timer <= 0) { return; }

        if (movingLeft)
        {
            transform.position = Vector3.MoveTowards(transform.position, leftBound, speed * Time.deltaTime);

            if(Vector3.Distance(transform.position, leftBound) < 0.001f)
            {
                movingLeft = false;
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, rightBound, speed * Time.deltaTime);

            if(Vector3.Distance(transform.position, rightBound) < 0.001f)
            {
                movingLeft = true;
            }
        }
    }

    public void Hit()
    {
        targetHealth--;
        if(targetHealth == 0)
        {
            targetManager.OnWillDestroy(this);
            Destroy(gameObject);
        }
    }
}
