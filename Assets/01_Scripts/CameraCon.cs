using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCon : MonoBehaviour
{
    public Transform centralAxis;
    public float camSpeed;
    public float mouseX;
    public float mouseY;

    void CamMove()
    {
        if(Input.GetMouseButton(1))
        {
            mouseX += Input.GetAxis("Mouse X");
            mouseY += Input.GetAxis("Mouse Y") * -1;
            centralAxis.rotation = Quaternion.Euler(
                new Vector3(
                    centralAxis.rotation.x + mouseY,
                    centralAxis.rotation.y + mouseX,
                    0) * camSpeed);
        }
        
    }
 
    // Update is called once per frame
    void Update()
    {
        CamMove();
    }
}
