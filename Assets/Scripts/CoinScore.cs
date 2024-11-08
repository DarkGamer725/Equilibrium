using UnityEngine;
using UnityEngine.UI;

public class CoinScore : MonoBehaviour
{
    [SerializeField] int coinValue;
    [SerializeField] string playerName;

    private void OnTriggerEnter(Collider other)
    {
        PlayerScore player = other.gameObject.GetComponent<PlayerScore>();

        if (player != null)
        {
            player.AddScore(coinValue);
            AudioSource audio = gameObject.GetComponent<AudioSource>();
            audio.Play();
            gameObject.GetComponent<SphereCollider>().enabled = false;
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            Destroy(this.gameObject, 3);
        }
        //relocate();
    }

    private void relocate()
    {
        float randomPosX = Random.Range(-110, 110) / 10f;
        float randomPosZ = Random.Range(-120, 100) / 10f;

        transform.localPosition = new Vector3(randomPosX, transform.localPosition.y, randomPosZ);
    }
}
