using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndZone : MonoBehaviour
{
    [SerializeField] Text endTextGood;
    [SerializeField] Text endTextBad;
    [SerializeField] float timeToNextLevel;
    [SerializeField] string nextLevelName;
    bool restartable;

    private void Start()
    {
        endTextGood.gameObject.SetActive(false);
        endTextBad.gameObject.SetActive(false);
        restartable = false;
    }
    private void Update()
    {
        if (restartable)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerScore ps = other.GetComponent<PlayerScore>();
            int playerScore = ps.GetScore();
            EndGame(playerScore);
        }
    }

    private void EndGame(int score)
    {
        if (score >= 5)
        {
            endTextGood.gameObject.SetActive(true);
            StartCoroutine(ChangeLevel());
        }
        else
        {
            restartable = true;  
            endTextBad.gameObject.SetActive(true);
        }

    }

    IEnumerator ChangeLevel()
    {
        yield return new WaitForSeconds(timeToNextLevel);
        SceneManager.LoadScene(nextLevelName);
    }
}
