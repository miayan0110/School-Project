using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHeart : MonoBehaviour
{
    public Sprite fullHeart, halfHeart, emptyHeart;

    Image IM1, IM2, IM3;

    int playerBlood;

    void Start()
    {
        playerBlood = 6;
        IM1 = GameObject.Find("Heart1").GetComponent<Image>();
        IM2 = GameObject.Find("Heart2").GetComponent<Image>();
        IM3 = GameObject.Find("Heart3").GetComponent<Image>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            LoseBlood();
        }
    }

    void LoseBlood()
    {
        playerBlood -= 1;
        switch (playerBlood)
        {
            case 5:
                IM3.sprite = halfHeart;
                break;
            case 4:
                IM3.sprite = emptyHeart;
                break;
            case 3:
                IM2.sprite = halfHeart;
                break;
            case 2:
                IM2.sprite = emptyHeart;
                break;
            case 1:
                IM1.sprite = halfHeart;
                break;
            case 0:
                IM1.sprite = emptyHeart;
                break;
            default:
                break;
        }
    }
}
