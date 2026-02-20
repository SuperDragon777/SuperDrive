using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PrometeoTouchInput : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    public bool changeScaleOnPressed = false;
    [HideInInspector]
    public bool buttonPressed = false;
    RectTransform rectTransform;
    Vector3 initialScale;
    float scaleDownMultiplier = 0.85f;

    void Start(){
      rectTransform = GetComponent<RectTransform>();
      if(rectTransform == null){
        rectTransform = gameObject.AddComponent<RectTransform>();
      }
      initialScale = rectTransform.localScale;
    }

    public void OnPointerDown(PointerEventData eventData){
      buttonPressed = true;
      if(changeScaleOnPressed && rectTransform != null){
        rectTransform.localScale = initialScale * scaleDownMultiplier;
      }
    }

    public void OnPointerUp(PointerEventData eventData){
      buttonPressed = false;
      if(changeScaleOnPressed && rectTransform != null){
        rectTransform.localScale = initialScale;
      }
    }

    public void ButtonDown(){
      OnPointerDown(null);
    }

    public void ButtonUp(){
      OnPointerUp(null);
    }

}
