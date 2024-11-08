using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField] float scaleFactor;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Vector3 scale = other.transform.localScale;
            scale *= scaleFactor;
            other.gameObject.transform.localScale = scale;

            Destroy(this.gameObject);
        }
    }
}
