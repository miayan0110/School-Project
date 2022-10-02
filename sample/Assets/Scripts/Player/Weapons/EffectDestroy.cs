using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectDestroy : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void Delete()
    {
        PlayerController.isExploded = true;
        Destroy(this.gameObject);
    }
}
