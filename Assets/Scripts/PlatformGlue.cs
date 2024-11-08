using UnityEngine;

public class PlatformGlue : MonoBehaviour
{
    Transform prevParent;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameObject platform = this.gameObject;
            GameObject ball = collision.gameObject;

            prevParent = ball.transform.parent;

            ball.transform.SetParent(transform, true);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.transform.SetParent(prevParent, true);
        }
    }
}
