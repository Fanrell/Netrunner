using UnityEngine;

public class WeaponBehavior : MonoBehaviour
{
    public int damage = 5;
    public float range = 30f;
    public float inpactForce =30f; 
    public ParticleSystem flash;
    public Object hitEffect;
    public Camera cam;

    private AudioSource gunSound;
    private void Start()
    {
        gunSound = GetComponent<AudioSource>();
    }

    public void Shoot()
    {
        RaycastHit hit;
        flash.Play();
        gunSound.Play();
        if( Physics.Raycast(cam.transform.position,cam.transform.forward, out hit, range)   )
        {
            Debug.DrawLine(cam.transform.position, cam.transform.forward, Color.red);
            if(hit.transform.tag == "Enemy" || hit.transform.tag == "Player")
            {
                hit.transform.GetComponent<EnemyBehavior>().TakeDamaged(damage);
                if(hit.rigidbody != null)
                    hit.rigidbody.AddForce(-hit.normal * inpactForce);
            }
            GameObject flar = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal)) as GameObject;
        }
    }

}
