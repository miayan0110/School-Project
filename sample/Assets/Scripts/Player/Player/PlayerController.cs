using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float playerSpeed;

    public static bool laserDestroy = true;
    public static bool isExploded = true;
    public static string HORIZONTAL = "Horizontal";
    public static string VERTICAL = "Vertical";

    SpriteRenderer sr;
    Transform targetTrans;
    Animator playerAni;
    
    void Start()
    {
        sr = this.gameObject.GetComponent<SpriteRenderer>();
        targetTrans = GameObject.Find("PlayerShootingController").GetComponent<Transform>();
        playerAni = this.gameObject.GetComponent<Animator>();
    }

    
    void Update()
    {
        if ((laserDestroy || ShootingController.GetShootingMode() != "Laser") && isExploded)
        {
            MoveByKeyboard();
        }
        /*
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
        */
        //MoveByMouse();
    }

    void MoveByKeyboard()
    {
        float dirX = Input.GetAxis(HORIZONTAL);
        float dirY = Input.GetAxis(VERTICAL);
        if (dirX != 0)
        {
            playerAni.SetBool("WalkingSide", true);
            playerAni.SetTrigger("Side");
            playerAni.ResetTrigger("Down");
        }
        else if (dirY != 0)
        {
            playerAni.ResetTrigger("Side");
            playerAni.SetTrigger("Down");
        }
        else
        {
            playerAni.SetBool("WalkingSide", false);
        }

        if (dirX < 0)
        {
            sr.flipX = true;
        }
        else if (dirX > 0)
        {
            sr.flipX = false;
        }

        if (dirY < 0)
        {
            playerAni.SetBool("WalkingDown", true);
        }
        else
        {
            playerAni.SetBool("WalkingDown", false);
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
