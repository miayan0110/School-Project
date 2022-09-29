using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingController : MonoBehaviour
{
    static float TIMER = 3f;
    static float SPEED = 5f;

    public float movingSpeed = SPEED;

    float timer = TIMER;
    Vector3 newDir = new Vector3(0, 0, 0);

    void Start()
    {
        //給予隨機初始方位
        newDir = new Vector3(Random.Range(-10, 11), Random.Range(-10, 11), 0).normalized;
        transform.right = newDir;
    }

    void Update()
    {
        AutoMove();
    }

    void AutoMove()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            newDir = new Vector3(Random.Range(-10, 11), Random.Range(-10, 11), 0).normalized;
            transform.right = newDir;
            timer = TIMER;
        }

        transform.Translate(Vector3.right * movingSpeed * Time.deltaTime);
    }

    void AvoidWeapon(Collider2D collision)
    {
        int avoidMode = Random.Range(0, 3);
        movingSpeed = SPEED * 1.5f;
        switch (avoidMode)
        {
            case 1:
                transform.right = collision.gameObject.transform.up;
                break;
            case 2:
                transform.right = -collision.gameObject.transform.up;
                break;
            default:
                transform.right = collision.gameObject.transform.right;
                break;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "GameEdgesX")
            transform.right = new Vector3(transform.right.x, -transform.right.y, 0);
        else if (collision.gameObject.name == "GameEdgesY")
            transform.right = new Vector3(-transform.right.x, transform.right.y, 0);
        else if (collision.gameObject.tag == "Weapon")
            Destroy(this.gameObject);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Weapon")
        {
            AvoidWeapon(collision);
        }
        else if(collision.gameObject.tag == "Player")
        {
            Vector3 objDir = Camera.main.WorldToScreenPoint(collision.gameObject.transform.position);
            Vector3 myDir = Camera.main.WorldToScreenPoint(transform.position);
            Vector3 dir = (objDir - myDir).normalized;
            dir.z = 0;
            transform.right = dir;
            movingSpeed = SPEED * 1.5f;
        }
        else
        {
            movingSpeed = SPEED;
        }
    }

}
