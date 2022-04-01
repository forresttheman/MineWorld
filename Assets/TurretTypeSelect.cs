using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretTypeSelect : MonoBehaviour
{
    public GameObject[] Turrets;
    public int turretIndex = 1;
    public int desiredTurret = 1;

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

        else
        {
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
        SelectTurret();
    }
}
