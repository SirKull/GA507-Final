using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TargetManager : MonoBehaviour
{
    public Target prefab;
    public int numTargets;

    public Transform minBound;
    public Transform maxBound;

    public float spacing;

    public Vector3 min;
    public Vector3 max;

    public int destroyCount = 0;

    public UnityEvent OnTargetHit;
    public float timer = 90f;

    public Ray ray;

    // Start is called before the first frame update
    void Start()
    {
        min = minBound.position;
        max = maxBound.position;
        spacing = (max.y - min.y) / (numTargets - 1);

        SpawnTargets();
    }

    public void SpawnTargets()
    {
        for(int i = 0; i < numTargets; i++)
        {
            Target clone = Instantiate(prefab);
            clone.Init(max.y - (spacing * i), min, max, this);
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if(timer <= 0) { return; }

        if (Input.GetMouseButtonDown(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit, 100))
            {
                Target target = hit.transform.GetComponent<Target>();
                if(target != null)
                {
                    target.Hit();
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        Debug.DrawRay(ray.origin, ray.direction * 100);
    }
    public void OnWillDestroy(Target target)
    {
        destroyCount++;
        OnTargetHit.Invoke();

        Target clone = Instantiate(prefab);
        clone.Init(target.transform.position.y, min, max, this);
    }
}
