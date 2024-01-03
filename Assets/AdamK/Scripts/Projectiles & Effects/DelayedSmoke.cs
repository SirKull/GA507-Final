using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayedSmoke : MonoBehaviour
{
    public ParticleSystem particles;
    public Coroutine smokeCor;

    public float runTime = 5f;
    public Vector3 a;
    public Vector3 b;

    void Start()
    {
        Coroutine smokeCor = StartCoroutine(PlaySmokeDelayed());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator PlaySmokeDelayed()
    {
        yield return new WaitForSeconds(2f);

        particles.Play();

        float curr = 0;

        while(curr < runTime)
        {
            curr += Time.deltaTime;

            yield return null;

            Vector3.Lerp(a, b, curr / runTime);
        }

        yield return new WaitForSeconds(2f);

        particles.Stop();
    }

    private void OnDisable()
    {
        if(smokeCor != null)
        {
            StopCoroutine(PlaySmokeDelayed());
        }
    }
}
