using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBaseElement : MonoBehaviour
{
    public Transform baseElement;
    public Transform pylonElement;

    public float rotateSpeed;
    float baseAngle;
    float pylonAngle;

    // Update is called once per frame
    void Update()
    {
        pylonAngle += rotateSpeed * Time.deltaTime;
        baseAngle -= rotateSpeed * Time.deltaTime;
        pylonElement.localRotation = Quaternion.AngleAxis(pylonAngle, Vector3.up); //rotate only on the y axis
        baseElement.localRotation = Quaternion.AngleAxis(baseAngle, Vector3.up); //rotate only on the y axis
    }
}
