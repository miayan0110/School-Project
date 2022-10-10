using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWizzardM : MonoBehaviour
{
    public float playerSpeed;

    SpriteRenderer playerSR;
    Animator playerAni, skillAni;

    void Start()
    {
        playerSR = this.GetComponent<SpriteRenderer>();
        playerAni = this.GetComponent<Animator>();
        skillAni = GameObject.Find("SkillAnim").GetComponent<Animator>();
    }

    void Update()
    {
        MoveByWSAD();
        Attack();
    }

    void MoveByWSAD()
    {
        if (Input.GetKey(KeyCode.W))
        {
            playerAni.Play("run");
            this.gameObject.transform.position += new Vector3(0f, playerSpeed * Time.deltaTime, 0f);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            playerAni.Play("run");
            this.gameObject.transform.position -= new Vector3(0f, playerSpeed * Time.deltaTime, 0f);
        }

        if (Input.GetKey(KeyCode.A))
        {
            playerAni.Play("run");
            playerSR.flipX = true;
            this.gameObject.transform.position -= new Vector3(playerSpeed * Time.deltaTime, 0f, 0f);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            playerAni.Play("run");
            playerSR.flipX = false;
            this.gameObject.transform.position += new Vector3(playerSpeed * Time.deltaTime, 0f, 0f);
        }
    }

    void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerAni.Play("hit");
            skillAni.Play("fire");
        }
    }
}
