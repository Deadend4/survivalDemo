using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableItem : MonoBehaviour
{
    [Header("Parameters")]
    [SerializeField] private int amount = 1;
    [Header("Sockets")]
    [SerializeField] GameObject handSocket;
    [Header("Scripts")]
    [SerializeField] private Item item;
    [SerializeField] Inventory inventory;
    [SerializeField] TakeItem takeItem;

    // Update is called once per frame
    void Update()
    {
        //if (takeItem.isGrabed && Input.GetMouseButtonDown(0) && this.gameObject == handSocket.transform.GetChild(0).gameObject)
        if (handSocket.transform.childCount > 0)
        {
            Debug.Log(handSocket.transform.GetChild(0).name);
            if (takeItem.isGrabed && this.gameObject.Equals(handSocket.transform.GetChild(0).gameObject))
            {

                if (inventory.AddItems(item, amount))
                {
                    takeItem.isGrabed = false;
                    Destroy(gameObject);
                }

            }
        }
    }
}
