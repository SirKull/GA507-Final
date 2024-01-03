using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_Shoot : MonoBehaviour
{
    public HUDController hudController;
    public PlayerTurret playerTurret;

    public bool isTriggered = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isTriggered == true)
        {
            hudController.shootText.SetActive(true);
            StartCoroutine(MessageLength());
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            isTriggered = true;
        }
    }

    IEnumerator MessageLength()
    {
        yield return new WaitForSeconds(3f);
        hudController.shootText.SetActive(false);
        isTriggered = false;
    }
}
