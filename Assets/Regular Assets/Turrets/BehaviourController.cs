using UnityEngine;

public class BehaviourController : MonoBehaviour
{
    [Tooltip ("Determines if you start in 3rd person view")]
    public bool isIn3rd = true;
    public GameObject camThird;
    public GameObject camFirst;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("l")) //add a collision check to the turret so they can't just become a turret from anywhere
        {
            isIn3rd = !isIn3rd;
        }

        if (isIn3rd)
        {
            camThird.SetActive(true);
            camFirst.SetActive(false);
        }

        else
        {
            camThird.SetActive(false);
            camFirst.SetActive(true);
        }
    }
}
