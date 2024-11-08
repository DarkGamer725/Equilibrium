using UnityEngine;

public class MobilePlatform : MonoBehaviour
{
    [SerializeField] Transform[] positions;
    [SerializeField] float speed;
    [SerializeField] float offset;
    [SerializeField] float timeWaiting;

    int actualDestiny;
    float timer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        actualDestiny = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            Vector3 direction;
            Vector3 destiny = positions[actualDestiny].position;
            Vector3 actualPosition = transform.position;

            direction = destiny - actualPosition;

            direction.Normalize();
            Vector3 newPosition;

            newPosition = actualPosition + direction * speed * Time.deltaTime;

            transform.position = newPosition;

            float distance = Vector3.Distance(newPosition, destiny);

            if (distance < offset)
            {
                actualDestiny += 1;
                if (actualDestiny >= positions.Length)
                {
                    actualDestiny = 0;
                }
                timer = timeWaiting;
            }
        }
        
    }
}
