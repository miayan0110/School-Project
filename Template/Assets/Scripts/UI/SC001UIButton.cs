using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SC001UIButton : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void ChangeSceneStart()
    {
        print("start!");
        SceneManager.LoadScene("SC1To2");
    }

    public void ChangeSceneEnd()
    {
        print("end!");
    }
}
