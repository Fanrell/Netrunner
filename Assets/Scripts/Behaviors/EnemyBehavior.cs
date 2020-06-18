using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehavior : CreaturesBehavior
{
    public float distance = 5f;
    private Collider eventPoint;
    private bool isNear = false;
    private NavMeshAgent agent;
    [SerializeField] public List<GameObject> patrol; 
    private int patrolsPoint = 0;
    GameObject point;
    // Start is called before the first frame update

    void OnDrawGizmosSelected() 
    {
        
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position,distance);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, distance/2);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, distance/4);
    }

    void CreatePoint()
    {
        point.transform.position = gameObject.transform.position;
        point.transform.position = new Vector3(point.transform.position.x,0,point.transform.position.z);
    }
    
    override protected void Init()
    {
        maxhp *= ChaosBehaviour.HpBoost;
        curramo = maxamo;
        currhp = maxhp;
    }

    private void Awake()
    {
        Init();
    }
    void Start()
    {

        point = new GameObject();
        GetComponent<SphereCollider>().radius = distance;
        agent = gameObject.GetComponent<NavMeshAgent>();
        CreatePoint();
        patrol.Add(point);
        agent.speed = speed;
    }

/*    void DistanceCheck(Transform target, Transform follower, float distance)
    {
        float pos = Vector3.Distance(target.position,follower.position);
        if(distance >= pos && pos >= 1.2f)
        {
            follower.GetComponent<EnemyBehavior>().toggleStatus(true);
        }
        else
        {
            follower.GetComponent<EnemyBehavior>().toggleStatus(false);
        }

    }*/

    Vector3 Patrol()
    {
        if(Vector3.Distance(transform.position,patrol[patrolsPoint].transform.position) <= 2)
            patrolsPoint++;
        if(patrolsPoint>=patrol.Count)
            patrolsPoint = 0;
        return patrol[patrolsPoint].transform.position;
    }

    // Update is called once per frame
    void Update()
    {       if (isNear == false)
            agent.SetDestination(Patrol());

        else if (isNear == true)
        {
            agent.SetDestination(eventPoint.transform.position);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.transform.tag == "Player")
            toggleStatus(true, other);
        Debug.Log(other);
    }

    public void toggleStatus(bool status, Collider player)
    {
        isNear = status;
        eventPoint = player;
    }
}
