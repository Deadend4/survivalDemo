using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CraftItem : ScriptableObject
{
    [SerializeField] public int id;
    [SerializeField] public Sprite icon;
    [SerializeField] Item item;
    [SerializeField] int count;
}
