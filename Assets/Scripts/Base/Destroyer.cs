using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    public float lifeTime = .5f;
    private Light flare;
    void Start() 
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject,lifeTime);
    }
}
