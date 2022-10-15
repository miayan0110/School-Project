using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillMask : MonoBehaviour
{
    public static bool energyIsFull;

    int MAXTIME = 10;

    Image mask;

    int time;
    float energy;

    void Start()
    {
        mask = this.gameObject.GetComponent<Image>();
        energy = 0;
        time = MAXTIME;
        energyIsFull = true;
    }

    void Update()
    {
        mask.fillAmount = energy;

        if (energy == 0)
        {
            energyIsFull = true;
        }

        if (!energyIsFull)
        {
            if (time > 0)
            {
                time--;
            }
            else if (time == 0)
            {
                FadeOutMask();
                time = MAXTIME;
            }
        }
    }

    void FadeOutMask()
    {
        if (energy - 0.005f >= 0)
        {
            energy -= 0.005f;
        }
        else
        {
            energy = 0;
            energyIsFull = true;
        }
    }

    public void FullEnergy()
    {
        if (energyIsFull)
        {
            energy = 1;
            energyIsFull = false;
        }
    }
}
