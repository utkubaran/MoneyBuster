using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UVLightController : MonoBehaviour, IInteractable
{

    private Vector3 stationPos;

    private Vector3 offset;

    private void Start()
    {
        stationPos = transform.position;
    }

    public void OnInteracted()
    {

    }

    public void GoBackStation()
    {
        transform.position = stationPos;
    }
}
