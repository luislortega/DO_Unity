using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogManager : MonoBehaviour {

    [HideInInspector] public List<LogText> logs = new List<LogText>();
    public GameObject logObjectText;

    public int maxLogs;
    [HideInInspector] public int currentLogsNumber;

    public float currentCoordY;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Utils.GameLog("Enemy targeting device disabled");
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            Utils.GameLog("Weapons system compromised");
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            Utils.GameLog("Weapons system back online");
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            Utils.GameLog("You have successfully finished the ZETA galxy gate");
        }
        DisplayFromQueue();
    }

    public List<string> _waitingLogs = new List<string>();
    void DisplayFromQueue()
    {
        if (_waitingLogs.Count != 0)
        {
            if (currentLogsNumber < maxLogs)
            {
                DisplayLog(_waitingLogs[0]);
                _waitingLogs.RemoveAt(0);
            }
        }
    }

    void DisplayLog(string message)
    {
        GameObject instantiatedLog;

        instantiatedLog = Instantiate(logObjectText);
        RectTransform rectTransform = instantiatedLog.GetComponent<RectTransform>();
        instantiatedLog.transform.SetParent(gameObject.transform);
        rectTransform.localScale = Vector3.one;
        rectTransform.localPosition = new Vector2(0, currentCoordY);
        currentCoordY -= rectTransform.sizeDelta.y;
        instantiatedLog.GetComponent<Text>().text = message;
        instantiatedLog.GetComponent<LogText>().logManager = this;
        instantiatedLog.GetComponent<LogText>().currentPosY = currentCoordY;

        currentLogsNumber++;
        logs.Add(instantiatedLog.GetComponent<LogText>());
    }

    public void NewLog(string message)
    {
        _waitingLogs.Add(message);
    }
}
