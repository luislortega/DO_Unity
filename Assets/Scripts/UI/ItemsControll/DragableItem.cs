using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

//Clasa care se ocupa de itemele din meniurile de arme, tech-uri, abilitati, etc. Permite tragerea itemelor cu mouse-ul si plasarea in sloturile de actiune\\
public class DragableItem : MonoBehaviour, IDragHandler
{
    ItemsControlManager itemsControlManagerScript;
    public GameObject template;
    public QItem itemAttached;


    void Start()
    {
        itemsControlManagerScript = GameObject.FindGameObjectWithTag("UI_ItemsControlMenu").GetComponent<ItemsControlManager>();
    }

    [HideInInspector] public bool _hasInstatiatedTemplate;
    [HideInInspector] public bool _hasSentTheItem;
    GameObject _item;
    public void OnDrag(PointerEventData eventData)
    {
        if (!_hasInstatiatedTemplate)
        {
            _item = Instantiate(template, transform.position, Quaternion.identity);
            _item.GetComponent<ItemFadeOut>().origin = this;
            _hasInstatiatedTemplate = true;
        }
        _item.transform.position = Input.mousePosition;
        _item.transform.SetParent(GameObject.Find("Canvas").transform);
        _item.GetComponent<RectTransform>().localScale = Vector3.one;
        _item.GetComponentInChildren<Image>().sprite = itemAttached.itemIcon;

        if (!_hasSentTheItem)
        {
            itemsControlManagerScript.itemCurrentlyDragging = GetComponent(typeof(QItem)) as QItem;
            _hasSentTheItem = true;
        }
    }
}
