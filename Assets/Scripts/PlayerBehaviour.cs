using UnityEngine;
using UnityEngine.UI;

public class PlayerBehaviour : MonoBehaviour
{

    int lives;
    [SerializeField] int startingLives;
    [SerializeField] Text livesText;
    [SerializeField] PauseMenu pauseMenu;

    Vector3 initPosition;
    Quaternion initRotation;

    private void Start()
    {
        initPosition = transform.localPosition;
        initRotation = transform.localRotation;
        lives = startingLives;
        UpdateLivesText();
        pauseMenu.RegisterOnPause(PauseBall);
    }

    public void LoseLife()
    {
        lives--;
        UpdateLivesText();
        if (lives >= 0)
        {
            Respawn();
        }
        else
        {
            GameOver();
        }
    }
    public void Respawn()
    {
        transform.localPosition = initPosition;
        transform.localRotation = initRotation;
        Rigidbody rb = this.gameObject.GetComponent<Rigidbody>();
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

    }

    private void UpdateLivesText()
    {
        livesText.text = "Lives: " + lives;
    }

    private void GameOver()
    {
        livesText.text = "Game Over";
        Destroy(this.gameObject);
    }

    private void PauseBall(bool pause)
    {
        Rigidbody rb = this.gameObject.GetComponent<Rigidbody>();
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }
}
