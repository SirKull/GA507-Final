using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class TargetUI : MonoBehaviour
{
    public TMP_Text timer;
    public TMP_Text hitCount;
    public TargetManager manager;



    // Start is called before the first frame update
    void Start()
    {
        manager.OnTargetHit.AddListener(OnTargetHit);
        OnTargetHit();
    }

    // Update is called once per frame
    void Update()
    {
        if(manager.timer <= 0) { return; }
        timer.text = TimeSpan.FromSeconds(manager.timer).ToString(@"mm\:ss");
    }
  
    public void OnTargetHit()
    {
        hitCount.text = manager.destroyCount.ToString();

    }
}
