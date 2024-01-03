using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrusherController : MonoBehaviour
{
    public Animator animator;
    public bool crusherDown = false;
    public float crusherTimer;
    public float crusherDownTime = 1f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(crusherDown == true)
        {
            crusherTimer += Time.deltaTime;
        }
        if (crusherTimer >= crusherDownTime)
        {
            crusherDown = false;
            animator.SetBool("CrusherDown", crusherDown);
            crusherTimer = 0f;
        }
    }

    public void CrusherFunction()
    {
        crusherDown = !crusherDown;
        animator.SetBool("CrusherDown", crusherDown);
    }
}
