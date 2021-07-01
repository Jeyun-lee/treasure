using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour
{
    [SerializeField]
    private Transform charBody;
    [SerializeField]
    private Transform camArm;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LookAround();
        Move();
    }

    private void Move()
    {
        Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        bool isMove = moveInput.magnitude != 0;
        if(isMove)
        {
            Vector3 lookForward = new Vector3(camArm.forward.x, 0f, camArm.forward.z).normalized;
            Vector3 lookRight = new Vector3(camArm.right.x, 0f, camArm.right.z).normalized;
            Vector3 moveDir = lookForward * moveInput.y + lookRight * moveInput.x;

            charBody.forward =
                transform.position += moveDir * Time.deltaTime * 5f;
        }
        //Debug.DrawRay(camArm.position,new Vector3(camArm.forward.x, 0f, camArm.forward.z).normalized, Color.red);
    }
    private void LookAround()
    {
        Vector2 mouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        Vector3 camAngle = camArm.rotation.eulerAngles;
        float x = camAngle.x - mouseDelta.y;

        if(x<180f)
        {
            x = Mathf.Clamp(x, -1f, 70f);
        }
        else
        {
            x = Mathf.Clamp(x, 335f, 361f);
        }

        camArm.rotation = Quaternion.Euler(x, camAngle.y + mouseDelta.x, camAngle.z);
    
    }
}
