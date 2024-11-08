using UnityEngine;

public class DeathZoneBehaviour : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        PlayerBehaviour player = other.gameObject.GetComponent<PlayerBehaviour>();
        if (player != null)
        {
            player.LoseLife();
        }
        else
        {
            Destroy(other.gameObject);
        }
    }
}
