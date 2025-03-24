using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="new Item Data",menuName ="Item Data")]
public class ItemData : ScriptableObject
{
    public string ItemManaterName;
    public string ItemName;
    public float Money;
    public Sprite Image;
}
