using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShootingModeText : MonoBehaviour
{
    TextMeshProUGUI shootingMode;
    
    void Start()
    {
        shootingMode = this.gameObject.GetComponent<TextMeshProUGUI>();
    }

    
    void Update()
    {
        ShowShootingMode();
    }

    void ShowShootingMode()
    {
        shootingMode.text = ShootingController.GetShootingMode();
    }
}
