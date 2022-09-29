using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserShooting : MonoBehaviour
{
    public static int TIME = 15;

    int appearTimer = TIME;
    int disappearTimer = TIME / 15;
    bool firstTrigger, touched;

    BoxCollider2D coll2d;
    GameObject energyBar;
    
    void Start()
    {
        coll2d = this.gameObject.GetComponentInChildren<BoxCollider2D>();
        energyBar = GameObject.Find("Bar");

        firstTrigger = false;
        touched = false;
    }

    
    void Update()
    {
        Shoot();
    }

    void Shoot()
    {
        appearTimer -= 1;
        if (appearTimer == 0)
        {
            this.gameObject.transform.localScale += new Vector3(0, 3, 0);
            appearTimer = TIME;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "GameEdges")
        {
            touched = true;
            firstTrigger = true;
            if (this.gameObject.transform.localScale.x <= 0.01f)
            {
                PlayerController.laserDestroy = true;
                Destroy(this.gameObject);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "GameEdges")
        {
            if (firstTrigger)
            {
                touched = false;
                firstTrigger = false;
                //print("first trigger");
                StartCoroutine("WaitForDisappear");
            }
            else if(!firstTrigger && touched)
            {
                //print("start disappearing");
                ChangeScale();
            }

            if (this.gameObject.transform.localScale.x <= 0.01f && disappearTimer <= 0)
            {
                PlayerController.laserDestroy = true;
                Destroy(this.gameObject);
            }
        }
    }
    
    IEnumerator WaitForDisappear()
    {
        //print("wait for timer");
        yield return new WaitForSeconds(disappearTimer);
        //print("finished waiting");
        touched = true;
    }

    void ChangeScale()
    {
        disappearTimer -= 1;
        this.gameObject.transform.localScale -= new Vector3(0.03f, 0, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Target")
        {
            /*
            if (!LaserEnergy.energyFull && energyBar.transform.localScale.x + LaserEnergy.energyMax * 0.2f < LaserEnergy.energyMax)
            {
                energyBar.transform.localScale += new Vector3(LaserEnergy.energyMax * 0.2f, 0f, 0f);
            }
            */
            if (!CircleLaserBar.isFull && CircleLaserBar.energy + CircleLaserBar.MaxEnergy * 0.2f < CircleLaserBar.MaxEnergy)
            {
                CircleLaserBar.energy += CircleLaserBar.MaxEnergy * 0.2f;
            }
            Destroy(collision.gameObject);
        }
    }
}
