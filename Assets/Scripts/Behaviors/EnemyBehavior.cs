using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehavior : CreaturesBehavior
{
    public float distance = 5f;
    public float periodShoot = 0f;
    [SerializeField]public GameObject[] pointsList;
    private Collider eventPoint;
    private bool isNear = false;
    private NavMeshAgent agent;
    [SerializeField] public List<Transform> patrol = new List<Transform>(); 
    private int patrolsPoint = 0;
    private GameObject point;
    private float timePeriodShoot = 0f;
    private float maxSpeed;
    private int mod = 1;
    public WeaponBehavior weapon;



    void OnDrawGizmosSelected() 
    {
        
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position,distance);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, distance/2);
    }

    void CreatePoint()
    {
        point.transform.position = gameObject.transform.position;
        point.transform.position = new Vector3(point.transform.position.x,0,point.transform.position.z);
    }
    
    override public void Init()
    {
        weapon = GetComponentInChildren<WeaponBehavior>();
        maxhp *= ChaosBehaviour.HpBoost;
        curramo = maxamo;
        currhp = maxhp;
        weapon.damage *= ChaosBehaviour.DmgBoost;
    }

    private void Awake()
    {
        Init();
    }

    private void GetPoints()
    {
        foreach (GameObject x in pointsList)
        {
            patrol.Add(x.transform);
        }


    }

    void Start()
    {
        GetPoints();
        point = new GameObject();
        GetComponent<SphereCollider>().radius = distance;
        agent = gameObject.GetComponent<NavMeshAgent>();
        CreatePoint();
        patrol.Add(point.transform);
        maxSpeed = speed;

    }


    Vector3 Patrol()
    {
        if (Vector3.Distance(transform.position, patrol[patrolsPoint].transform.position) <= 2)
            patrolsPoint += mod;
        if (patrolsPoint == patrol.Count - 1)
            mod = -1;
        if (patrolsPoint == 0)
            mod = 1;
        return patrol[patrolsPoint].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        agent.speed = speed;
        if (isNear == false)
            agent.SetDestination(Patrol());

        else if (isNear == true)
        {
            behaviourCheck();
        }
        if (Time.time > slowTime)
        {
            agent.speed = maxSpeed;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.transform.tag == "Player")
            toggleStatus(true, other);
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Player")
            toggleStatus(false, null);
    }

    private void behaviourCheck()
    {
        agent.SetDestination(eventPoint.transform.position);
        if(eventPoint.transform.tag == "Player" && Vector3.Distance(this.transform.position, eventPoint.transform.position) <= distance / 2)
        {
            if(Time.time >= timePeriodShoot)
            {   
                weapon.Shoot(Random.Range(1,101));
                timePeriodShoot = Time.time + periodShoot;
            }
        }
    }

    public void toggleStatus(bool status, Collider player)
    {
        isNear = status;
        eventPoint = player;
    }
}
