using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCasts : MonoBehaviour
{
    [SerializeField] LayerMask breathingLayer;
    float maxDistance = 100f;

    // Update is called once per frame
    void Update()
    {
        Ray rayRight = new(transform.position, transform.right);
        Ray rayLeft = new(transform.position, -transform.right);
        
        if(Physics.Raycast(rayLeft, out RaycastHit hit, maxDistance, breathingLayer) || Physics.Raycast(rayRight, out hit, maxDistance, breathingLayer))
        {
            Destroy(hit.collider.gameObject);
        }
        
    }

    void OnDrawGizmos()
    {
        
    }
}
