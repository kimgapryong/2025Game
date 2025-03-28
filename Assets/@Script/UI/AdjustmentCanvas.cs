using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class AdjustmentCanvas : UI_Base
{
    enum Objects
    {
        AdjustmentContent,
    }
    enum Buttons
    {
        CloseBtn,
    }
    public override bool Init()
    {
        base.Init();
        Bind<GameObject>(typeof(Objects));
        Bind<Button>(typeof(Buttons));
        GetButton((int)Buttons.CloseBtn).gameObject.BindingBtn(AllGetValue);

        gameObject.SetActive(false);
        return true;
    }

    public IEnumerator CreateFragment()
    {
        gameObject.SetActive(true);

        for (int i = 0; i < Manager.Ui.bagSlotFragment.Count; i++)
        {
            BagSlotFragment curBag = Manager.Ui.bagSlotFragment[i];
            Debug.Log(curBag.myItem);
            Debug.Log(curBag);
            if (curBag.myItem == null)
                break;

            Debug.Log("¿Ö ¾ÈµÅ");
            AdjustmentFragment adj = Manager.Ui.CreateUi<AdjustmentFragment>("Fragment/AdjustmentFragment", GetObject((int)Objects.AdjustmentContent).transform);
            adj.SetImage(curBag.itemImage.sprite, curBag.myItem.itemData.ItemName, curBag.itemCount, curBag.myItem.itemData.Money);
            yield return new WaitForSeconds(0.3f);
        }
    }

    private void AllGetValue()
    {
        float value = 0;
        for(int i = 0; i < Manager.Ui.bagSlotFragment.Count; i++)
        {
            BagSlotFragment curBag = Manager.Ui.bagSlotFragment[i];
            if (curBag.myItem == null)
                break;

            foreach(var one in Manager.Player.itemHole.GetComponentsInChildren<Item_Base>())
            {
                if (one.gameObject.CompareTag("OnePiece"))
                {
                    if (GameManager.curTrager + 1 < Stages.trager.Length)
                    {
                        GameManager.curTrager++;
                        Manager.Stage.OkTrager(GameManager.curTrager);
                    }
                }
            }
            
            value += curBag.myItem.itemData.Money * curBag.itemCount;
        }

        foreach (var fragemtn in GetObject((int)Objects.AdjustmentContent).transform.GetComponentsInChildren<AdjustmentFragment>())
            Destroy(fragemtn.gameObject);

        Manager.Game.Money += value;

        Manager.Ui.Inventory.ReBack();
        gameObject.SetActive(false);
    }
}
