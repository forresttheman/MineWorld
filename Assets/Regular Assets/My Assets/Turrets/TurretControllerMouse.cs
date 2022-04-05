using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretControllerMouse : MonoBehaviour
{
    public Transform Tower;
    public Transform Barrel;
    public float towerSpeed;
    public float barrelSpeed;

    float towerAngle;
    float barrelAngle;


    // Update is called once per frame
    void Update()
    {
        RotateTower();
        RotateBarrels();
    }

    void RotateTower()
    {
        towerAngle += Input.GetAxis("Mouse X") * towerSpeed * Time.deltaTime;
        Tower.localRotation = Quaternion.AngleAxis(towerAngle, Vector3.up); //rotate only on the y axis
    }

    void RotateBarrels()
    {
        barrelAngle += Input.GetAxis("Mouse Y") * barrelSpeed * -Time.deltaTime;
        barrelAngle = Mathf.Clamp(barrelAngle, -10, 10);
        Barrel.localRotation = Quaternion.AngleAxis(barrelAngle, Vector3.back);
    }
}
