using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    ////public Image fadeImg;
    ////public GameObject gameOverUI;

    // Start is called before the first frame update
    void Start()
    {

    }

    //void OnGameOver()
    //{
    //    StartCoroutine(Fade(Color.clear, Color.black, 1));
    //    gameOverUI.SetActive(true);
    //}
    //IEnumerator Fade(Color from, Color to, float time)
    //{
    //    float speed = 1 / time;
    //    float percent = 0;

    //    while(percent < 1)
    //    {
    //        percent += Time.deltaTime * speed;
    //        fadeImg.color = Color.Lerp(from, to, percent);
    //        yield return null;
    //    }
    //}

    public void StartNewGame()
    {
        SceneManager.LoadScene("Main");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
