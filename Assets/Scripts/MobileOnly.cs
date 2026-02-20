using UnityEngine;

public class MobileOnly : MonoBehaviour
{
    void Awake()
    {
        #if !UNITY_ANDROID
            Destroy(gameObject);
        #endif
    }
}