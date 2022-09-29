using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public float movingSpeed = 5f;
    public float timer = 1;

    void Start()
    {
        
    }

    void Update()
    {
        Move();
        Delete();
    }

    void Move()
    {
        switch (ShootingController.GetShootingMode())
        {
            case "Auto Track":
                Track();
                break;
            default:
                transform.Translate(Vector3.right * movingSpeed * Time.deltaTime);
                break;
        }

    }

    void Delete()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            //print("limited time: change target");
            ShootingController.isTargetDead = true;
            Destroy(this.gameObject);
        }
    }

    void Track()
    {
        if (GameObject.FindWithTag("Target") != null)
        {
            Vector3 targetDir = Camera.main.WorldToScreenPoint(ShootingController.target.transform.position);
            Vector3 myDir = Camera.main.WorldToScreenPoint(transform.position);
            Vector3 newDir = targetDir - myDir;
            newDir.z = 0f;
            transform.right = newDir.normalized;
            transform.Translate(Vector3.right * movingSpeed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Target" || collision.gameObject.tag == "GameEdges")
        {
            //print("target killed: change taregt");
            ShootingController.isTargetDead = true;
            Destroy(this.gameObject);
        }
    }
}
