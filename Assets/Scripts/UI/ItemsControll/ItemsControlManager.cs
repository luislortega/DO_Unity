using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Clasa cu functii si variabile generale pentru meniul cu Iteme\\
public class ItemsControlManager : MonoBehaviour {

    [HideInInspector] public QItem itemCurrentlyDragging;
    public ActionSlot[] actionSlots;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            actionSlots[1].UseItem();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            actionSlots[2].UseItem();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            actionSlots[3].UseItem();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            actionSlots[4].UseItem();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            actionSlots[5].UseItem();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            actionSlots[6].UseItem();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            actionSlots[7].UseItem();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            actionSlots[8].UseItem();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            actionSlots[9].UseItem();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            actionSlots[10].UseItem();
        }
        else if (Input.GetKeyDown(KeyCode.F1))
        {
            actionSlots[11].UseItem();
        }
        else if (Input.GetKeyDown(KeyCode.F2))
        {
            actionSlots[12].UseItem();
        }
        else if (Input.GetKeyDown(KeyCode.F3))
        {
            actionSlots[13].UseItem();
        }
        else if (Input.GetKeyDown(KeyCode.F4))
        {
            actionSlots[14].UseItem();
        }
        else if (Input.GetKeyDown(KeyCode.F5))
        {
            actionSlots[15].UseItem();
        }
        else if (Input.GetKeyDown(KeyCode.F6))
        {
            actionSlots[16].UseItem();
        }
        else if (Input.GetKeyDown(KeyCode.F7))
        {
            actionSlots[17].UseItem();
        }
        else if (Input.GetKeyDown(KeyCode.F8))
        {
            actionSlots[18].UseItem();
        }
        else if (Input.GetKeyDown(KeyCode.F9))
        {
            actionSlots[19].UseItem();
        }
        else if (Input.GetKeyDown(KeyCode.F10))
        {
            actionSlots[20].UseItem();
        }

    }
}