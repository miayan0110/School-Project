using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillBoard : MonoBehaviour
{
    public GameObject skillEffectOnEnemy;

    Transform playerTR;
    Image myIM;
    Animator skillAnim;

    void Start()
    {
        playerTR = GameObject.Find("Player").GetComponent<Transform>();
        myIM = this.gameObject.GetComponent<Image>();
    }

    void Update()
    {
        
    }

    public void Skill()
    {
        if (SkillMask.energyIsFull)
        {
            Instantiate(skillEffectOnEnemy, playerTR.position, Quaternion.identity);
            if (GameObject.Find("SkillEffectOnEnemy(Clone)") != null)
            {
                skillAnim = GameObject.Find("SkillEffectOnEnemy(Clone)").GetComponent<Animator>();
            }
        }
        StartCoroutine("PlaySkill");
    }

    IEnumerator PlaySkill()
    {
        yield return null;
        skillAnim.SetBool("AreaBuffOn", true);
        
        yield return null;
        skillAnim.Play(myIM.sprite.name);

        yield return null;
        StartCoroutine("Delete");
    }

    IEnumerator Delete()
    {
        yield return new WaitForSeconds(2.0f);
        skillAnim.SetBool("AreaBuffOn", false);
        Destroy(GameObject.Find("SkillEffectOnEnemy(Clone)"));
    }
}
