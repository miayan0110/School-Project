using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserEnergy : MonoBehaviour
{
    public static int MAXTIMER = 300;
    public static bool energyFull;
    public static float energyMax;

    int timer = MAXTIMER;

    void Start()
    {
        energyMax = this.gameObject.transform.localScale.x;
        energyFull = true;
    }

    void Update()
    {
        if (!PlayerController.laserDestroy && Input.GetMouseButtonDown(0) && energyFull)
        {
            this.gameObject.transform.localScale = new Vector3(0f, 0.1202872f, 1f);
            energyFull = false;
        }
        else if (!energyFull)
        {
            if (timer > 0)
            {
                timer--;
            }
            else if (timer == 0)
            {
                AutoStoringEnergy();
                timer = MAXTIMER;
            }
        }
    }

    void AutoStoringEnergy()
    {
        if (this.gameObject.transform.localScale.x + energyMax * 0.05f < energyMax)
        {
            this.gameObject.transform.localScale += new Vector3(energyMax * 0.05f, 0f, 0f);
        }
        else
        {
            energyFull = true;
            this.gameObject.transform.localScale = new Vector3(energyMax, 0.1202872f, 1);
        }
    }
}
