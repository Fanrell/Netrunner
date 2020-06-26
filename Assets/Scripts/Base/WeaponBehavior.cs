using UnityEngine;

public class WeaponBehavior : MonoBehaviour
{
    public int damage = 5;
    public float range = 30f;
    public float inpactForce = 30f; 
    public ParticleSystem dmgFlash;
    public ParticleSystem slowFlash;
    public Object hitEffect;
    public Object slowEffect;
    public Camera cam;
    private string type = "damageble";

    private AudioSource gunSound;
    private void Start()
    {
        gunSound = GetComponent<AudioSource>();
    }

    public void Shoot()
    {
        
        RaycastHit hit;
        if(type == "damageble")
            dmgFlash.Play();
        if (type == "slow")
            slowFlash.Play();
        gunSound.Play();
        if( Physics.Raycast(cam.transform.position,cam.transform.forward, out hit, range)   )
        {
            Debug.DrawLine(cam.transform.position, cam.transform.forward, Color.red);
            if(hit.transform.tag == "Enemy")
            {
                hit.transform.GetComponent<EnemyBehavior>().TakeDamaged(damage,type);
            }
            if(hit.transform.tag == "Player")
            {
                hit.transform.GetComponent<PlayerBehavior>().TakeDamaged(damage, type);
            }

            if (hit.rigidbody != null)
                hit.rigidbody.AddForce(-hit.normal * inpactForce);
            if (type == "damageble")
            {
                GameObject flar = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal)) as GameObject;
            }
            if (type == "slow")
            {
                GameObject flar = Instantiate(slowEffect, hit.point, Quaternion.LookRotation(hit.normal)) as GameObject;
            }
        }
    }

    public void Shoot(int v)
    {
        AttackTypeSwitch(v);

        RaycastHit hit;
        if (type == "damageble")
            dmgFlash.Play();
        if (type == "slow")
            slowFlash.Play();
        gunSound.Play();
        if (Physics.Raycast(dmgFlash.transform.position, dmgFlash.transform.right, out hit, range))
        {
            Debug.DrawLine(dmgFlash.transform.position, dmgFlash.transform.right, Color.red);
            if (hit.transform.tag == "Enemy")
            {
                hit.transform.GetComponent<EnemyBehavior>().TakeDamaged(damage, type);
            }
            if (hit.transform.tag == "Player")
            {
                hit.transform.GetComponent<PlayerBehavior>().TakeDamaged(damage, type);
            }

            if (hit.rigidbody != null)
                hit.rigidbody.AddForce(-hit.normal * inpactForce);
            if (type == "damageble")
            {
                GameObject flar = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal)) as GameObject;
            }
            if (type == "slow")
            {
                GameObject flar = Instantiate(slowEffect, hit.point, Quaternion.LookRotation(hit.normal)) as GameObject;
            }
        }
    }

    public void AttackTypeSwitch()
    {
        if (type == "damageble")
            type = "slow";
        else if (type == "slow")
            type = "damageble";
        Debug.Log(type);
    }

    public void AttackTypeSwitch(int v)
    {
        if (v %2 != 0)
            type = "slow";
        else if (v % 2 == 0)
            type = "damageble";
        Debug.Log(type);
    }

}
