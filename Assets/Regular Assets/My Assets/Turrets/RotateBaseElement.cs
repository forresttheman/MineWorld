using UnityEngine;

public class RotateBaseElement : MonoBehaviour
{
    [Header ("Set 1")]
    public Transform baseElement1;
    public Transform pylonElement1;
    [Header("Set 2")]
    public Transform baseElement2;
    public Transform pylonElement2;
    [Header("Set 3")]
    public Transform baseElement3;
    public Transform pylonElement3;
    [Header("Set 4")]
    public Transform baseElement4;
    public Transform pylonElement4;

    public float rotateSpeed;
    float baseAngle;
    float pylonAngle;

    private GameObject parent;
    public TurretTypeSelect selector;


    void Start()
    {
        parent = GameObject.Find("Base");
        selector = parent.GetComponent<TurretTypeSelect>();
    }

    // Update is called once per frame
    void Update()
    {
        //update angles
        pylonAngle += rotateSpeed * Time.deltaTime;
        baseAngle -= rotateSpeed * Time.deltaTime;

        //rotate elements
        if (selector.desiredTurret == 1)
        {
            pylonElement1.localRotation = Quaternion.AngleAxis(pylonAngle, Vector3.up); //rotate only on the y axis
            baseElement1.localRotation = Quaternion.AngleAxis(baseAngle, Vector3.up); //rotate only on the y axis
        }

        if (selector.desiredTurret == 2)
        {
            pylonElement2.localRotation = Quaternion.AngleAxis(pylonAngle, Vector3.up); //rotate only on the y axis
            baseElement2.localRotation = Quaternion.AngleAxis(baseAngle, Vector3.up); //rotate only on the y axis
        }

        if (selector.desiredTurret == 3)
        {
            pylonElement3.localRotation = Quaternion.AngleAxis(pylonAngle, Vector3.up); //rotate only on the y axis
            baseElement3.localRotation = Quaternion.AngleAxis(baseAngle, Vector3.up); //rotate only on the y axis
        }

        if (selector.desiredTurret == 4)
        {
            pylonElement4.localRotation = Quaternion.AngleAxis(pylonAngle, Vector3.up); //rotate only on the y axis
            baseElement4.localRotation = Quaternion.AngleAxis(baseAngle, Vector3.up); //rotate only on the y axis
        }
    }
}
