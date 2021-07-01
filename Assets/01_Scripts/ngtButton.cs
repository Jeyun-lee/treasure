using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ngtButton : MonoBehaviour
{
    GameObject negotiation; 
    public List<EnemyController> econ;
    bool isOnButton;
    public int scoreCount = 0;
    // Start is called before the first frame update
    void Start()
    {
         GetComponent<Button>().interactable = false;

    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < econ.Count; i++)
        {
            if (econ[i].bPlayerInSightRange)
            {

                GetComponent<Button>().interactable = true;
                isOnButton = true;
                break;
            }
            else
            {
                isOnButton=false;
            }
            
        }
        if(!isOnButton)
        {
            GetComponent<Button>().interactable = false;

        }

    }
    public void DestroyObj()
    {
        scoreCount += 1;

        for (int i = 0; i < econ.Count; i++)
        {
            if (econ[i].bPlayerInSightRange)
            {
                Destroy(econ[i].gameObject);
                econ.RemoveAt(i);
            }
            GetComponent<Button>().interactable = false;

        }

    }

}

//ó���� �Ǵµ� �ι�°���� ��� Ȱ��ȭ
