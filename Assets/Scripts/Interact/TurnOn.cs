using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOn : MonoBehaviour
{
    [SerializeField] public Inventory inventory;
    [SerializeField] Item item;
    [SerializeField] GameObject Effect;

    public void startEffect()
    {
        if (inventory.DeleteItems(item, 3))
        {
            StartCoroutine("objectEffect");
        }
    }
    IEnumerator objectEffect()
    {
        Effect.SetActive(true);

        yield return new WaitForSeconds(60);
        Effect.SetActive(false);
    }
}
