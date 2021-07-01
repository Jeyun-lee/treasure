using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wayGizmo : MonoBehaviour
{
    public Color color = Color.red;
    public float radius = 0.3f;
    // Start is called before the first frame update

    private void OnDrawGizmos()
    {
        Gizmos.color = color;
        Gizmos.DrawSphere(transform.position, radius);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
