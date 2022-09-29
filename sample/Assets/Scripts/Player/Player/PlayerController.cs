using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float playerSpeed;

    public static bool laserDestroy = true;

    string HORIZONTAL = "Horizontal";
    string VERTICAL = "Vertical";

    SpriteRenderer sr;
    Transform targetTrans;
    
    void Start()
    {
        sr = this.gameObject.GetComponent<SpriteRenderer>();
        targetTrans = GameObject.Find("PlayerShootingController").GetComponent<Transform>();
    }

    
    void Update()
    {
        if (laserDestroy || ShootingController.GetShootingMode() != "Laser")
        {
            MoveByKeyboard();
        }
        else
        {
            if (targetTrans.eulerAngles.z > 90.0f && targetTrans.eulerAngles.z < 270.0f)
            {
                sr.flipX = true;
            }
            else
            {
                sr.flipX = false;
            }
        }

        //MoveByMouse();
    }

    void MoveByKeyboard()
    {
        float dirX = Input.GetAxis(HORIZONTAL);
        float dirY = Input.GetAxis(VERTICAL);
        if (dirX < 0)
        {
            sr.flipX = true;
        }
        else if (dirX > 0)
        {
            sr.flipX = false;
        }
        this.gameObject.transform.position += new Vector3(dirX * playerSpeed * Time.deltaTime, 0f, 0f);
        this.gameObject.transform.position += new Vector3(0f, dirY * playerSpeed * Time.deltaTime, 0f);
    }

    void MoveByMouse()
    {
        Vector3 mousedir = Input.mousePosition;
        Vector3 playerdir = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 finaldir = mousedir - playerdir;
        finaldir.z = 0f;
        transform.right = finaldir;
        //transform.Translate(Vector3.up * playerSpeed * Time.deltaTime);
    }
}
