using UnityEngine;
using TMPro;

public class version_text : MonoBehaviour
{
    [Header("UI")]
    public TMP_Text versionLabel;

    [Header("Format")]
    public string format = "Version {0}";

    private void Awake()
    {
        if (versionLabel == null)
        {
            versionLabel = GetComponent<TMP_Text>();
        }

        if (versionLabel == null)
        {
            Debug.LogWarning("[version_text] No versionLabel assigned.");
            return;
        }

        string appVersion = Application.version;
        versionLabel.text = string.Format(format, appVersion);
    }
}
