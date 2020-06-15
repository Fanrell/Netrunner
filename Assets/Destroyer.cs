using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    public float lifeTime = .5f;
    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject,lifeTime);
    }
}
