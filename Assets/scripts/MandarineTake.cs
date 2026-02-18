using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mandarine : MonoBehaviour
{
    public Text scoreYouText;
    public Text scoreGenaText;
    public  int scoreYou = 0;
    public static int scoreGena = 0;

    void Start()
    {

        if (scoreYouText == null)
        {
            GameObject obj = GameObject.Find("ScoreYou");
            if (obj != null) scoreYouText = obj.GetComponent<Text>();
        }

        if (scoreGenaText == null)
        {
            GameObject obj = GameObject.Find("ScoreGena");
            if (obj != null) scoreGenaText = obj.GetComponent<Text>();
        }

        UpdateUI();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("GenaBasket"))
        {
            Debug.Log("Гена украл мандарин");
            scoreGena++;
            UpdateUI();
            Destroy(gameObject.transform.parent.gameObject);
        }
        else if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Мандарин пойман");
            scoreYou++;
            UpdateUI();
            Destroy(gameObject.transform.parent.gameObject);
        }
    }

    void UpdateUI()
    {
        if (scoreYouText != null)
        {
            scoreYouText.text = "Score You: " + scoreYou;
        }

        if (scoreGenaText != null)
        {
            scoreGenaText.text = "Score Gena: " + scoreGena;
        }
    }
}
