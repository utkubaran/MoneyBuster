using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UVLightController : MonoBehaviour, IInteractable
{
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
        transform.rotation = Quaternion.Euler(activeRotation);
    }

    public void GoBackStation()
    {
        transform.position = stationPos;
        transform.rotation = stationRot;
    }
}
