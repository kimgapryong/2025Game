using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager
{
    public List<SlotFragment> fragments = new List<SlotFragment>();
    public T CreateUi<T>(string path, Transform trans = null) where T : Component
    {
        GameObject ui = Manager.Resources.Instantaite($"UI/{path}", trans);
        ui.GetComponent<RectTransform>().localPosition = Vector3.zero;
        T com = ui.GetOrAddComponent<T>();
        return com;
    }
}
