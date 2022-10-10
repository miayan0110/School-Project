using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWizzardM : MonoBehaviour
{
    public float playerSpeed;

    SpriteRenderer playerSR;
    Animator playerAni;

    void Start()
    {
        playerSR = this.GetComponent<SpriteRenderer>();
        playerAni = this.GetComponent<Animator>();
    }

    void Update()
    {
        MoveByWSAD();
    }

    void MoveByWSAD()
    {
        if (Input.GetKey(KeyCode.W))
        {
            //playerAni.SetBool("isRunning", true);
            playerAni.Play("run");
            this.gameObject.transform.position += new Vector3(0f, playerSpeed * Time.deltaTime, 0f);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            //playerAni.SetBool("isRunning", true);
            playerAni.Play("run");
            this.gameObject.transform.position -= new Vector3(0f, playerSpeed * Time.deltaTime, 0f);
        }

        if (Input.GetKey(KeyCode.A))
        {
            //playerAni.SetBool("isRunning", true);
            playerAni.Play("run");
            playerSR.flipX = true;
            this.gameObject.transform.position -= new Vector3(playerSpeed * Time.deltaTime, 0f, 0f);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            //playerAni.SetBool("isRunning", true);
            playerAni.Play("run");
            playerSR.flipX = false;
            this.gameObject.transform.position += new Vector3(playerSpeed * Time.deltaTime, 0f, 0f);
        }
    }
}
