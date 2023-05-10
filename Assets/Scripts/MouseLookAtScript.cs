using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLookAtScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetDir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float flareAngle = (Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg) /*- 90f*/; //covers the direction Flare is facing
        transform.rotation = Quaternion.AngleAxis(flareAngle, Vector3.forward);
    }
}
