using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingController : MonoBehaviour
{
    public GameObject knife;
    public GameObject laser;
    public GameObject laserEnergyBar;
    public GameObject laserUI;
    public GameObject explosion;

    public static GameObject target = null;
    public static bool isTargetDead = true;

    static string currentShootingMode = "Manual";

    LinkedList<string> shootingModeList = new LinkedList<string>();
    GameObject[] gos;
    SpriteRenderer playersr;

    void Start()
    {
        InitializingShootingMode();

        playersr = GameObject.Find("Player").GetComponent<SpriteRenderer>();

        //print("initial: " + isTargetDead);
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            currentShootingMode = ChangeShootingMode(currentShootingMode);
        }

        switch (currentShootingMode)
        {
            case "Manual":
                laserEnergyBar.SetActive(false);
                laserUI.SetActive(false);
                Manual();
                Shoot();
                break;
            case "Auto":
                Auto();
                Shoot();
                break;
            case "Auto Track":
                AutoTrack();
                Shoot();
                break;
            case "Multiple":
                Multiple();
                break;
            case "Laser":
                laserEnergyBar.SetActive(true);
                laserUI.SetActive(true);
                Laser();
                break;
            case "Explosion":
                laserEnergyBar.SetActive(false);
                laserUI.SetActive(false);
                Explosion();
                break;
            default:
                Manual();
                Shoot();
                break;
        }
    }

    void InitializingShootingMode()
    {
        shootingModeList.AddFirst("Manual");
        shootingModeList.AddAfter(shootingModeList.Find("Manual"), "Auto");
        shootingModeList.AddAfter(shootingModeList.Find("Auto"), "Auto Track");
        shootingModeList.AddAfter(shootingModeList.Find("Auto Track"), "Multiple");
        shootingModeList.AddAfter(shootingModeList.Find("Multiple"), "Laser");
        shootingModeList.AddAfter(shootingModeList.Find("Laser"), "Explosion");
    }
    
    public static string GetShootingMode()
    {
        return currentShootingMode;
    }
    
    string ChangeShootingMode(string mode)
    {
        if (shootingModeList.Last.Value == mode) return shootingModeList.First.Value;
        else return shootingModeList.Find(mode).Next.Value;
    }

    GameObject RandomTarget()
    {
        gos = GameObject.FindGameObjectsWithTag("Target");
        return gos[Random.Range(0, gos.Length)];
    }

    void Shoot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(knife, transform.position, transform.rotation);
        }
    }

    void Manual()
    {
        Vector3 mouseDir = Input.mousePosition;
        Vector3 myDir = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 newDir = mouseDir - myDir;
        newDir.z = 0f;
        transform.right = newDir.normalized;
    }

    void Auto()
    {
        if (GameObject.FindWithTag("Target") != null)
        {
            if (isTargetDead)
            {
                //print("random target");
                target = RandomTarget();
                //print("random target finished");
                isTargetDead = false;
                //print("isTargetDead:" + isTargetDead);
            }
            
            Vector3 targetDir = Camera.main.WorldToScreenPoint(target.transform.position);
            Vector3 myDir = Camera.main.WorldToScreenPoint(transform.position);
            Vector3 newDir = targetDir - myDir;
            newDir.z = 0f;
            transform.right = newDir.normalized;
        }   
    }

    void AutoTrack()
    {
        Auto();
    }

    void Multiple()
    {
        Manual();
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(knife, transform.position, transform.rotation);
            Instantiate(knife, transform.position, Quaternion.Euler(new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z + 10)));
            Instantiate(knife, transform.position, Quaternion.Euler(new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z - 10)));
            Instantiate(knife, transform.position, Quaternion.Euler(new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z + 20)));
            Instantiate(knife, transform.position, Quaternion.Euler(new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z - 20)));
        }
    }

    void Laser()
    { 
        Manual();
        if (Input.GetMouseButtonDown(0) && PlayerController.laserDestroy && (LaserEnergy.energyFull || CircleLaserBar.isFull))
        {
            PlayerController.laserDestroy = false;
            Instantiate(laser, transform.position, Quaternion.Euler(new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z - 90)));
        }
    }

    void Explosion()
    {
        float dirX = Input.GetAxis(PlayerController.HORIZONTAL);
        float dirY = Input.GetAxis(PlayerController.VERTICAL);

        Vector3 explorePositionX = new Vector3(1.0f, 0.0f, 0.0f);
        Vector3 explorePositionY = new Vector3(0.0f, 1.0f, 0.0f);

        if (Input.GetKeyDown(KeyCode.E))
        {
            PlayerController.isExploded = false;
            if (dirY < 0)
            {
                Instantiate(explosion, transform.position - explorePositionY, Quaternion.identity);
            }
            else if (dirY > 0)
            {
                Instantiate(explosion, transform.position + explorePositionY, Quaternion.identity);
            }
            else if (dirX < 0)
            {
                Instantiate(explosion, transform.position - explorePositionX, Quaternion.identity);
            }
            else if (dirX > 0)
            {
                Instantiate(explosion, transform.position + explorePositionX, Quaternion.identity);
            }
        }
    }
}
