using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillBoard : MonoBehaviour
{
    public GameObject playerSkillOnEnemy;

    Transform playerTR;
    Image myIM;
    Animator skillAnim;

    void Start()
    {
        playerTR = GameObject.Find("Player").GetComponent<Transform>();
        myIM = this.gameObject.GetComponent<Image>();
        skillAnim = playerSkillOnEnemy.GetComponent<Animator>();
    }

    void Update()
    {
        
    }

    public void Skill()
    {
        Instantiate(playerSkillOnEnemy, playerTR.position, Quaternion.identity);
        StartCoroutine("Delete");
        //StartCoroutine("PlaySkill");
        /*
        if (playerSkillOnEnemy.activeInHierarchy && skillAnim.GetCurrentAnimatorStateInfo(0).IsName("idle"))
        {
            playerSkillOnEnemy.SetActive(false);
        }
        */
    }

    IEnumerator PlaySkill()
    {
        yield return null;
        skillAnim.Play(myIM.sprite.name);
    }

    IEnumerator Delete()
    {
        yield return new WaitForSeconds(2.0f);
        Destroy(GameObject.Find("PlayerSkillOnEnemy(Clone)"));
    }
}
