using UnityEngine;

public class Bullet : MonoBehaviour
{
    float speed;

    private void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerBehaviour player = other.GetComponent<PlayerBehaviour>();
        if (player != null)
        {
            player.LoseLife();
        }
        Destroy(this.gameObject);
    }

    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }
}
