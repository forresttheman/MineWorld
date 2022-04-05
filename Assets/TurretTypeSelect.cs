using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretTypeSelect : MonoBehaviour
{
    public GameObject[] Turrets;
    private int turretIndex = 1;
    public int desiredTurret = 1;
    private GameObject tower;

    private GameObject scriptHolder;
    public TurretControllerWASD turretController;


    void SelectTurret()
    {
        if (desiredTurret != turretIndex)
        {
            foreach (GameObject turret in Turrets)
            {
                turretIndex += 1;

                if (turretIndex == desiredTurret)
                {
                    turret.SetActive(true);
                    Debug.Log("Desired Turret Selected");

                    //find the tower in hierarchy
                    tower = GameObject.FindGameObjectWithTag("Tower");

                    //find the transform component and set the turret controller transform to it
                    turretController.Tower = tower.GetComponent<Transform>();

                }

                else
                {
                    turret.SetActive(false);
                    Debug.Log("Skipped Turret");
                }
                
                if (turretIndex > Turrets.Length)
                {
                    Debug.Log("Done.");
                    break;
                }
            }
        }

        else {
            Debug.Log("turrrrr");
            foreach (GameObject turret in Turrets)
            {
                turret.SetActive(true);
                break;
            }
        }

    }

    void Start()
    {
        scriptHolder = GameObject.Find("Base");
        turretController = scriptHolder.GetComponent<TurretControllerWASD>();
        SelectTurret();
        Debug.Log("Success");
    }

    void Update()
    {
        if (Input.GetKeyDown("p"))
        {
            desiredTurret += 1;
            SelectTurret();
        }

        if (desiredTurret >= Turrets.Length)
        {
            desiredTurret = Turrets.Length;
        }
    }
}
