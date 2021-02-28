using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class DeathBox : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }


    void OnTriggerEnter(Collider obj) 
    {
        obj.transform.position = new Vector3(0, 0, 0);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
