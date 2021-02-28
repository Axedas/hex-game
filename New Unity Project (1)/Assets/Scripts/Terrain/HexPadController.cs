using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexPadController : MonoBehaviour
{
    private bool triggered;
    Material m_Material;
    // Start is called before the first frame update
    void Start()
    {
        m_Material = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void changeColor()
    {
        m_Material.color = Color.white;  
    }

    void OnCollisionEnter(Collision collision) 
    {
        if (m_Material != null)
        {
            m_Material.color = Color.white;
        }
        Destroy(gameObject, (float)1.5);
    }
}
