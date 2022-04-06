using System.Collections.Generic;
using UnityEngine;

public class TurretControllerWASD : MonoBehaviour
{
    public Transform Tower;
    public List<Transform> Barrels1;
    public List<Transform> Barrels2;
    public List<Transform> Barrels3;
    public List<Transform> Barrels4;

    private GameObject scriptHolder;
    private TurretTypeSelect selector;
    private BehaviourController controller;

    public float towerInc = 60f;
    float towerSpeed;
    public float barrelSpeed = 200f;
    float barrelAngle;
    public int barrelClamp = 10;
    bool rotateGat = false;


    // Update is called once per frame
    void Update()
    {
        RotateTower();
        RotateBarrels();
    }

    private void Start()
    {
        scriptHolder = GameObject.Find("Base");
        selector = scriptHolder.GetComponent<TurretTypeSelect>();
        controller = scriptHolder.GetComponent<BehaviourController>();
    }

    void RotateTower()
    {
        if (controller.isIn3rd)
        {
            if (Input.GetKeyDown("a"))
            {
                towerSpeed = towerInc;
            }
            if (Input.GetKeyDown("d"))
            {
                towerSpeed = -towerInc;
            }

            if (Input.GetKeyUp("a") || Input.GetKeyUp("d"))
            {
                towerSpeed = 0f;
            }

            Tower.Rotate(0, towerSpeed * Time.deltaTime, 0);
        }
        
    }

    void RotateBarrels()
    {
        if (controller.isIn3rd)
        {
            if (Input.GetKeyDown("w"))
            {
                barrelAngle += barrelSpeed * Time.deltaTime;
                rotateGat = true;
            }
            if (Input.GetKeyDown("s"))
            {
                barrelAngle -= barrelSpeed * Time.deltaTime;
                rotateGat = false;
            }

            //clamp barrel angles
            if (selector.desiredTurret == 4)
            {
                barrelAngle = Mathf.Clamp(barrelAngle, -1000000000, 1000000000);
            }

            else
            {
                barrelAngle = Mathf.Clamp(barrelAngle, -barrelClamp, barrelClamp);
            }

            //rotate barrels (somewhat messy, lists weren't working)
            if (selector.desiredTurret == 1)
            {
                foreach (Transform barrel in Barrels1)
                {
                    barrel.localRotation = Quaternion.AngleAxis(barrelAngle, Vector3.back);
                }
            }

            if (selector.desiredTurret == 2)
            {
                foreach (Transform barrel in Barrels2)
                {
                    barrel.localRotation = Quaternion.AngleAxis(barrelAngle, Vector3.back);
                }
            }

            if (selector.desiredTurret == 3)
            {
                foreach (Transform barrel in Barrels3)
                {
                    barrel.localRotation = Quaternion.AngleAxis(barrelAngle, Vector3.back);
                }
            }

            if (selector.desiredTurret == 4 && rotateGat)
            {
                foreach (Transform barrel in Barrels4)
                {
                    barrel.Rotate(barrelSpeed * 1.5f * Time.deltaTime, 0, 0);
                }
            }
        }
    }
}
