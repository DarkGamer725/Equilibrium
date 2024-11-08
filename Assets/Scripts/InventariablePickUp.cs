using UnityEngine;

public class InventariablePickUp : MonoBehaviour
{

    [SerializeField] string itemName;
    Item item;

    private void Start()
    {
        item = new Item();

        item.SetName(itemName);
    }

    private void OnTriggerEnter(Collider other)
    {
        Inventory inv = other.gameObject.GetComponent<Inventory>();
        if (inv != null)
        {
            if (inv.AddItem(item))
            {
                Destroy(this.gameObject);
            }
        }
    }
}
