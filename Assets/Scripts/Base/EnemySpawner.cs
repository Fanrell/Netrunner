using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private GameObject[] enemies;
    public float duration = 2;
    // Start is called before the first frame update
    void Start()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        Debug.Log(enemies.Length);
    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject x in enemies)
        {
            if (x.GetComponent<EnemyBehavior>().dTime != 0 && x.GetComponent<EnemyBehavior>().dTime + (duration/ChaosBehaviour.SpawnBoost) < Time.time)
            {
                x.SetActive(true);
                x.GetComponent<EnemyBehavior>().dTime = 0;
                x.GetComponent<EnemyBehavior>().toggleStatus(false, null);
                x.GetComponent<EnemyBehavior>().Init();
            }
        }
    }
}
