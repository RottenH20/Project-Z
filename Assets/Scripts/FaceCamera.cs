using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceCamera : MonoBehaviour 
{
    private Camera cameraAffected;
    public bool useStaticBillboard;

    // Start is called before the first frame update
    void Start()
    {
        cameraAffected = Camera.main;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (!useStaticBillboard)
            transform.LookAt(cameraAffected.transform);
        else
            transform.rotation = cameraAffected.transform.rotation;


        transform.LookAt(cameraAffected.transform);

        transform.rotation = Quaternion.Euler(0f, transform.rotation.eulerAngles.y, 0f);
    }
}
