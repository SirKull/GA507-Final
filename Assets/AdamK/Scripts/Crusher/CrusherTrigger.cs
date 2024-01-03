using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrusherTrigger : MonoBehaviour
{
    public CrusherController crusherController;
    public bool crusherTriggered = false;
    public bool isDestroyed = false;

    private void OnTriggerEnter(Collider other)
    {
        if (isDestroyed == false)
        {
            if (other.gameObject.tag == "Player" || other.gameObject.tag == "turret")
            {
                crusherController.CrusherFunction();
            }
        }

    }
}
