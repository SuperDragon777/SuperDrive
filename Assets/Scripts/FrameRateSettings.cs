using UnityEngine;

public class FrameRateSettings : MonoBehaviour
{
    [Header("VSync")]
    public bool enableVSync = false;

    [Header("Target FPS")]
    public int targetFrameRate = 60;

    void Awake()
    {
        Apply();
    }

    public void Apply()
    {
        if (enableVSync)
        {
            QualitySettings.vSyncCount = 1;
            Application.targetFrameRate = -1;
        }
        else
        {
            QualitySettings.vSyncCount = 0;
            Application.targetFrameRate = targetFrameRate;
        }
    }

#if UNITY_EDITOR
    void OnValidate()
    {
        Apply();
    }
#endif
}