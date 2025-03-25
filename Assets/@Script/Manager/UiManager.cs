using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager
{
    public List<SlotFragment> slotFragments = new List<SlotFragment>();
    public List<BagSlotFragment> bagSlotFragment = new List<BagSlotFragment>();
    public InvenCanvas Inventory { get; set; }
    public ShopCanvas Shop { get; set; }
    public BagCanvas Bag { get; set; }
   
    public T CreateUi<T>(string path, Transform trans = null) where T : Component
    {
        GameObject ui = Manager.Resources.Instantaite($"UI/{path}", trans);
        ui.GetComponent<RectTransform>().localPosition = Vector3.zero;
        T com = ui.GetOrAddComponent<T>();
        return com;
    }
}
