using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogText : MonoBehaviour {

    [HideInInspector] public LogManager logManager;

    public float fadeInIntensity;
    public int stayTime;

    [HideInInspector] public float currentPosY;


    void Start()
    { 
        StartCoroutine("FadeIn");
        StartCoroutine("LifeTime");
        transform.SetParent(logManager.transform);
        transform.localScale = Vector3.one;
    }

    IEnumerator LifeTime()
    {
        yield return new WaitForSeconds(stayTime);
        logManager.currentLogsNumber--;
        logManager.currentCoordY += GetComponent<RectTransform>().sizeDelta.y;
        for (int i = logManager.logs.IndexOf(this) + 1; i <= logManager.logs.Count - 1; i++)
        {
            Vector2 logPosition = logManager.logs[i].GetComponent<RectTransform>().localPosition;
            logManager.logs[i].GetComponent<RectTransform>().localPosition = new Vector2(0, logPosition.y + 18); 
        }
        logManager.logs.Remove(this);
        Destroy(gameObject);
    }

    IEnumerator FadeIn()
    {
        for (float f = 0f; f <= 1; f += fadeInIntensity)
        {
            Color c = GetComponent<Text>().color;
            c.a = f;
            GetComponent<Text>().color = c;
            yield return null;
        }
    }
}