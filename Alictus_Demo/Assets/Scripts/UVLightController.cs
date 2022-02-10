using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UVLightController : MonoBehaviour, IInteractable
{
    [SerializeField]
    private GameObject UVLightFX;

    [SerializeField]
    private GameObject maskObj;
    
    private Vector3 stationPos;

    private Quaternion stationRot;

    private Vector3 activeRotation = new Vector3(35f, 0f, 90f);

    private void Start()
    {
        stationPos = transform.position;
        stationRot = transform.rotation;
    }

    public void OnDrag()
    {
        LeanTween.rotate(this.gameObject, activeRotation, 0.25f);
    }

    public void GoBackStation()
    {
        LeanTween.move(this.gameObject, stationPos, 0.5f);
        LeanTween.rotate(this.gameObject, stationRot.eulerAngles, 0.25f);
    }
}
