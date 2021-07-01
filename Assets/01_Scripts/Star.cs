using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Star : MonoBehaviour
{
    ngtButton coin;
    public GameObject panel;
    public Image[] coins;
    public Sprite[] coinImage;
    // Start is called before the first frame update
    void Awake()
    {
        coin = FindObjectOfType<ngtButton>();
    }

    public void result()
    {
        for (int i = 0; i < 3; i++)
        {
            if (i >= 3 - coin.scoreCount)
            {
                coins[i].sprite = coinImage[0];
            }
            else
            {
                coins[i].sprite = coinImage[1];
            }
        }

    }
    // Update is called once per frame
    void Update()
    {
        result();
    }
}
