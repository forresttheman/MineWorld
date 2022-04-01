using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretControllerWASD : MonoBehaviour
{
    public Transform Tower;
    public Transform[] Barrels;
    public float towerInc = 60f;
    float towerSpeed;
    public float barrelSpeed = 200f;
    float barrelAngle;
    public int barrelClamp = 10;


    // Update is called once per frame
    void Update()
    {
        RotateTower();
        RotateBarrels();
    }

    void RotateTower()
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

    void RotateBarrels()
    {
        if (Input.GetKeyDown("w"))
        {
            barrelAngle +=  barrelSpeed * Time.deltaTime;
        }
        if (Input.GetKeyDown("s"))
        {
            barrelAngle -= barrelSpeed * Time.deltaTime;
        }


        barrelAngle = Mathf.Clamp(barrelAngle, -barrelClamp, barrelClamp);

        foreach (Transform barrel in Barrels){
            barrel.localRotation = Quaternion.AngleAxis(barrelAngle, Vector3.back);
        }
    }
}
