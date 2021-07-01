using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerMove : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField]
    private float playerSpeed = 5f;
    public int count = 0;
    //public CanvasGroup gameResultOver;

    public ngtButton ngt;
    public Text countKey;
    public Open open;
   


    public Image OverPanel;
    public Text GoText;
    public Image ClearPanel;
    public Text GcText;
    float time = 0f;
    float Ftime = 1f;
    public Text nonkey;
    public Text deadByEnemy;
    void Start()
    {
        //gameResultOver.interactable = false;
        //gameResultOver.alpha = 0f;

        rb = GetComponent<Rigidbody>();
        countKey.text = "¿­¼è : " + count + "°³";
    }

    void FixedUpdate()
    {
        float hzt = Input.GetAxis("Horizontal");
        float vtc = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(hzt, 0, vtc);
        transform.Translate(new Vector3(hzt, 0, vtc) * playerSpeed * Time.deltaTime);

        rb.AddForce(movement * playerSpeed);
    }
    public int num = 0;
    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.tag == "KEY")
        {
            Destroy(other.gameObject);
            count += 1;
            countKey.text = "¿­¼è : " + count + "°³";

        }

        if (other.gameObject.tag == "TREASURE")
        {
            if (count < 5)
            {
                open.anim.SetTrigger("isLocked");

                
                nonkey.gameObject.SetActive(true);

                StartCoroutine(showText());


            }
            else
            {
                open.anim.SetBool("isOpen", true);


                if(ngt.scoreCount >= 3)
                {
                    StartCoroutine(FadeFlow());
                    deadByEnemy.gameObject.SetActive(true);

                }
                else
                {
                    StartCoroutine(FadeFlowClear());

                }


                //Destroy(other.gameObject);


            }
        }
        if (other.gameObject.tag == "ENEMY")
        {
            StartCoroutine(FadeFlow());

        }

    }           
    public Button button;

    IEnumerator showText()
    {
        yield return new WaitForSeconds(1);
        nonkey.gameObject.SetActive(false);


    }
    IEnumerator FadeFlow()
    {
        OverPanel.gameObject.SetActive(true);
        Color alpha = OverPanel.color;
        button.gameObject.SetActive(true);
        

        GoText.gameObject.SetActive(true);
        while (alpha.a < 1f)
        {
            time += Time.deltaTime / Ftime;
            alpha.a = Mathf.Lerp(0, 1, time);
            OverPanel.color = alpha;
            yield return null;
        }
        yield return null;
    }
    IEnumerator FadeFlowClear()
    {
        yield return new WaitForSeconds(2.3f);

        ClearPanel.gameObject.SetActive(true);
        Color alpha = ClearPanel.color;
        button.gameObject.SetActive(true);


        GcText.gameObject.SetActive(true);
        while (alpha.a < 1f)
        {
            time += Time.deltaTime / Ftime;
            alpha.a = Mathf.Lerp(0, 1, time);
            ClearPanel.color = alpha;
            yield return null;
        }
        yield return null;
    }
    //gameResultOver.alpha = 1f;
    //Time.timeScale = 0;
    //gameResultOver.interactable = true;

    //IEnumerator LoadSceneCoroutine()
    //{
    //    switch (num)
    //    {
    //        case 1:
    //            yield return new WaitForSeconds(3f); SceneManager.LoadSceneAsync("GameOver", LoadSceneMode.Additive);
    //            break;
    //        case 2:
    //            yield return new WaitForSeconds(3f); SceneManager.LoadSceneAsync("GameClear", LoadSceneMode.Additive);

    //            break;

    //    }

    //}

}


        ////if(other.gameObject.tag == "ENEMY")
        ////{
        ////    Destroy(other.gameObject);
        ////}
    //void OnGameOver()
    //{
    //    StartCoroutine(Fade(Color.clear, Color.black, 1));
    //    gameOverUI.SetActive(true);
    //}
    //IEnumerator Fade(Color from, Color to, float time)
    //{
    //    float speed = 1 / time;
    //    float percent = 0;

    //    while (percent < 1)
    //    {
    //        percent += Time.deltaTime * speed;
    //        fadeImg.color = Color.Lerp(from, to, percent);
    //        yield return null;
    //    }
    //}

 
