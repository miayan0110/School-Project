using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyNecromancer : MonoBehaviour
{
    public Vector3 startPosition;
    public Vector3 targetPosition;
    public float movingSpeed;

    SpriteRenderer mySR;
    Animator myAnim;

    Vector3 selfPosition;
    Vector3 target;

    void Start()
    {
        startPosition = this.gameObject.transform.position;
        mySR = this.gameObject.GetComponent<SpriteRenderer>();
        myAnim = this.gameObject.GetComponent<Animator>();
        target = targetPosition;
    }

    void Update()
    {
        selfPosition = this.gameObject.transform.position;
        AutoMove();
    }

    void AutoMove()
    {
        if (selfPosition == startPosition)
        {
            StartCoroutine(Wait(targetPosition, true));
        }
        else if (selfPosition == targetPosition)
        {
            StartCoroutine(Wait(startPosition, false));
        }
        this.gameObject.transform.position = Vector3.MoveTowards(selfPosition, target, movingSpeed * Time.deltaTime);
    }

    IEnumerator Wait(Vector3 position, bool filp)
    {

        yield return new WaitForSeconds(1.0f);
        mySR.flipX = filp;

        yield return new WaitForSeconds(1.0f);
        target = position;
    }
}
