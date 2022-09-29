using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CircleLaserBar : MonoBehaviour
{
    public static float MAXTIME = 10;
    public static bool isFull;
    public static float MaxEnergy;
    public static float energy;

    public Image bar;

    float timer = MAXTIME;

    void Start()
    {
        MaxEnergy = 100;
        energy = MaxEnergy;
        isFull = true;
    }

    void Update()
    {
        bar.fillAmount = energy / MaxEnergy;

        if (!PlayerController.laserDestroy && Input.GetMouseButtonDown(0) && isFull)
        {
            energy = 0;
            isFull = false;
        }
        else if (!isFull)
        {
            if (timer > 0)
            {
                timer--;
            }
            else if (timer == 0)
            {
                AutoStoringEnergy();
                timer = MAXTIME;
            }
        } 
    }

    void AutoStoringEnergy()
    {
        if (energy + MaxEnergy * 0.003f < MaxEnergy)
        {
            energy += MaxEnergy * 0.003f;
        }
        else
        {
            isFull = true;
            energy = MaxEnergy;
        }
    }
}
