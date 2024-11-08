using System.Collections;
using UnityEngine;

public class CannonFriend : MonoBehaviour
{
    [SerializeField] Transform shootingSpot;
    [SerializeField] float shootingDelay;
    [SerializeField] Vector3 force;
    Rigidbody target;

    void SetInShootingSpot()
    {
        target.transform.position = shootingSpot.position;
    }

    IEnumerator ShootWithDelay()
    {
        yield return new WaitForSeconds(shootingDelay);
        Shoot();
    }

    void Shoot()
    {

        target.isKinematic = false;
        target.AddForce(force);
        target = null;
    }

    private void SetTarget(Rigidbody target)
    {
        this.target = target;
        target.isKinematic = true;
        SetInShootingSpot();
        StartCoroutine(ShootWithDelay());
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" 
            && target == null)
        {
            SetTarget(collision.gameObject.GetComponent<Rigidbody>());
        }
    }
}
