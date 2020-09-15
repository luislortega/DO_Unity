using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

//Clasa care se ocupa de sloturile din barele de actiune\\
public class ActionSlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public QItem embeddedItem;
    public Image itemIcon;
    public Text itemQuantity;
    ItemsControlManager itemsControlManagerScript;

    void Start()
    {
        itemsControlManagerScript = GameObject.FindGameObjectWithTag("UI_ItemsControlMenu").GetComponent<ItemsControlManager>();
    }

    void Update()
    {
        if(Input.GetMouseButtonUp(0) && itemsControlManagerScript.itemCurrentlyDragging != null && _isPonterOnSlot)
        {
            embeddedItem = itemsControlManagerScript.itemCurrentlyDragging;
            UpdateCurrentItem();
            itemsControlManagerScript.itemCurrentlyDragging = null;
        }
    }

    bool _isPonterOnSlot;
    public void OnPointerEnter(PointerEventData eventData)
    {
        _isPonterOnSlot = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _isPonterOnSlot = false;
    }

    void UpdateCurrentItem()
    {
        itemIcon.sprite = embeddedItem.itemIcon;
        itemQuantity.text = embeddedItem.itemQuantity.ToString();
    }

    public void UseItem()
    {
        if(embeddedItem!= null)
        {
            embeddedItem.Use();
        }
    }
}
