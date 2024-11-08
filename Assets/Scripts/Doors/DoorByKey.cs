using UnityEngine;

public class DoorByKey : Door
{
    protected override void Start()
    {
        base.Start();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Contacto");
        Inventory inv = other.gameObject.GetComponent<Inventory>();
        if (inv != null)
        {
            if (inv.HasItem("Key"))
            {
                Open();
            }
        }
    }
}
