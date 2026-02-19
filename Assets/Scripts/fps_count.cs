using UnityEngine;
using TMPro;

public class fps_count : MonoBehaviour
{
    [Header("UI")]
    public TMP_Text fpsText;

    [Header("Settings")]
    public float updateInterval = 0.5f;

    private float _accumulatedTime;
    private int _frames;
    private float _timeLeft;

    private void Start()
    {
        if (fpsText == null)
        {
            Debug.LogWarning("[fps_count] No fpsText assigned");
        }

        _timeLeft = updateInterval;
    }

    private void Update()
    {
        _timeLeft -= Time.unscaledDeltaTime;
        _accumulatedTime += Time.unscaledDeltaTime;
        _frames++;

        if (_timeLeft <= 0.0f)
        {
            float fps = _frames / _accumulatedTime;

            if (fpsText != null)
            {
                fpsText.text = $"FPS: {fps:0}";
            }

            _timeLeft = updateInterval;
            _accumulatedTime = 0f;
            _frames = 0;
        }
    }
}
