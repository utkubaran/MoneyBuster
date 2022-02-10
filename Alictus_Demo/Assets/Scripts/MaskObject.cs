using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaskObject : MonoBehaviour
{
    [SerializeField]
    private GameObject[] maskObj;

    void Start()
    {
        for(int i = 0; i < maskObj.Length; i++)
        {
            maskObj[i].GetComponent<MeshRenderer>().material.renderQueue = 2002;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
