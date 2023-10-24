using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItem : MonoBehaviour
{
    [Header("Prefabs")]
    [SerializeField] GameObject stickPrefab;
    [SerializeField] GameObject matchPrefab;
    [SerializeField] GameObject fabricPrefab;
    [SerializeField] GameObject ethanolPrefab;
    [SerializeField] KeyCode dropKey = KeyCode.G;
    [Header("Scripts")]
    private Inventory inventory;

    // Start is called before the first frame update
    void Start()
    {
        inventory = GetComponent<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(dropKey) && Input.GetKeyDown(KeyCode.Alpha1))
        {
            checkItem(0);
        }
        if (Input.GetKey(dropKey) && Input.GetKeyDown(KeyCode.Alpha2))
        {
            checkItem(1);
        }
        if (Input.GetKey(dropKey) && Input.GetKeyDown(KeyCode.Alpha3))
        {
            checkItem(2);
        }
        if (Input.GetKey(dropKey) && Input.GetKeyDown(KeyCode.Alpha4))
        {
            checkItem(3);
        }
        if (Input.GetKey(dropKey) && Input.GetKeyDown(KeyCode.Alpha5))
        {
            checkItem(4);
        }
    }

    private void checkItem(int index)
    {
        if (inventory.GetItem(index) != null)
        {
            if (inventory.GetItem(index).name == "stick")
            {
                spawnPrefabs(stickPrefab, this.transform.position, inventory.GetAmount(index));
            }
            else if (inventory.GetItem(index).name == "match")
            {
                spawnPrefabs(matchPrefab, this.transform.position, inventory.GetAmount(index));
            }
            else if (inventory.GetItem(index).name == "fabric")
            {
                spawnPrefabs(fabricPrefab, this.transform.position, inventory.GetAmount(index));
            }
            else if (inventory.GetItem(index).name == "ethanol")
            {
                spawnPrefabs(ethanolPrefab, this.transform.position, inventory.GetAmount(index));
            }
            inventory.DeleteItems(inventory.GetItem(index), inventory.GetAmount(index));
        }

    }

    public void spawnPrefabs(GameObject prefab, Vector3 prefabPosition, int count)
    {
        for (int index = 0; index < count; index++)
        {
            GameObject spawnObject = Instantiate(prefab, prefabPosition, Quaternion.identity);
            int suffixLength = "(clone)".Length;
            spawnObject.name.Substring(0, spawnObject.name.Length - suffixLength);
        }

    }
}
