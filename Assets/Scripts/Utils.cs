using UnityEngine;
using UnityEngine.UI;

public static class Utils {

    static public float AngleDir(Vector2 fwd, Vector2 targetDir)
    {
        Vector3 _fwd = new Vector3(fwd.x, fwd.y, 0f);
        Vector3 _targetDir = new Vector3(targetDir.x, targetDir.y, 0f);
        return AngleDir(_fwd, _targetDir, Vector3.forward);
    }

    static public float AngleDir(Vector3 fwd, Vector3 targetDir, Vector3 up)
    {
        Vector3 perp = Vector3.Cross(fwd, targetDir);
        float dir = Vector3.Dot(perp, up);

        if (dir >= 0.0f)
        {
            return 1.0f;
        }
        else if (dir < 0.0f)
        {
            return -1.0f;
        }

        return 0.0f;
    }

    public static float AngleDiff(Vector2 fwd, Vector2 targetDir)
    {
        float angle = Vector2.Angle(fwd, targetDir);

        return angle * AngleDir(fwd, targetDir) + 180;
    }

    public static void GameLog(string message)
    {
        GameObject.FindGameObjectWithTag("Log").GetComponent<LogManager>().NewLog(message);
    }

    public static void PlaySound(string sound)
    {
        switch (sound)
        {
            case "x1_laser": MonoBehaviour.Instantiate(Resources.Load("Sounds/x1_laser")); break;
            case "x2_laser": MonoBehaviour.Instantiate(Resources.Load("Sounds/x2_laser")); break;
            case "x3_laser": MonoBehaviour.Instantiate(Resources.Load("Sounds/x3_laser")); break;
            case "x4_laser": MonoBehaviour.Instantiate(Resources.Load("Sounds/x4_laser")); break;
            case "rsb_laser": MonoBehaviour.Instantiate(Resources.Load("Sounds/rsb_laser")); break;
            case "cbo_laser": MonoBehaviour.Instantiate(Resources.Load("Sounds/cbo_laser")); break;
            case "rb_laser": MonoBehaviour.Instantiate(Resources.Load("Sounds/rb_laser")); break;

            case "out_of_range": MonoBehaviour.Instantiate(Resources.Load("Sounds/out_of_range")); break;
        }
    }

    public static void FillBar(Image image, float currentAmount, float maxAmount)
    {
        image.fillAmount = currentAmount / maxAmount;
    }
}
