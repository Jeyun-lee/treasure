using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Open : MonoBehaviour
{
    public PlayerMove pm;

    public Animator anim;
   

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PLAYER")
        {
            if(pm.count >= 5)
            {
                Debug.Log("열림");
                anim.SetBool("isOpen", true);
            }
            else
            {
                Debug.Log("부족");

                anim.SetBool("isLocked", true);
            }


        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
