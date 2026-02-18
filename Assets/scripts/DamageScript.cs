using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class DamageScript : MonoBehaviour
{
    [SerializeField] int HealthPoints = 3;
    [SerializeField] int Damage = 1;
    [SerializeField] private List<Image> livesImages;
    [SerializeField] private Image vignetteImage;

    void Start()
    {

        if (vignetteImage != null)
        {
            vignetteImage.gameObject.SetActive(false);
        }
        else
        {
            return;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Mandarin"))
        {
            Debug.Log("Мандарин потерян");

            HealthPoints -= Damage;
            Debug.Log($"Осталось жизней: {HealthPoints}");
            Destroy(collision.gameObject.transform.parent.gameObject);

            RemoveLife();
        }
    }

    private void RemoveLife()
    {

        if (livesImages.Count > 0)
        {
            Image lastLife = livesImages[livesImages.Count - 1];
            lastLife.gameObject.SetActive(false);
            livesImages.RemoveAt(livesImages.Count - 1);
        }

        if (HealthPoints <= 1)
        {
            ShowVignette();
        }

        if (HealthPoints <= 0)
        {
            Debug.Log("Ты проиграл");
            Invoke(nameof(QuitGame), 1.5f);
        }
    }

    private void ShowVignette()
    {
        if (vignetteImage != null)
        {
            vignetteImage.gameObject.SetActive(true);
            Debug.Log("Осталась 1 жизнь");
        }
    }

    private void QuitGame()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
