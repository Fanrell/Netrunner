using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class WeaponBehavior : MonoBehaviour
{

    public int gunDamage = 1;
    public float fireRate = .25f;
    public float weaponRange = 50f;
    public float hitForce = 100f;
    public Transform gunEnd;

    public Camera cam;
    private WaitForSeconds shotDuration = new WaitForSeconds(0.07f);
    private AudioSource gunAudio;
    private LineRenderer laserLine;
    private float nextFire;
    private PlayerBehavior player;

    private void Start()
    {
        laserLine = GetComponent<LineRenderer>();
        gunAudio = GetComponent<AudioSource>();
        player = GameObject.Find("Player").GetComponent<PlayerBehavior>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            if (player.curramo > 0)
            {
                StartCoroutine(ShotEffect());

                Vector3 rayOrigin = cam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.0f));
                Debug.DrawRay(this.transform.position, rayOrigin * weaponRange, Color.green);
                RaycastHit hit;
                laserLine.SetPosition(0, gunEnd.position);
                if (Physics.Raycast(rayOrigin, cam.transform.forward, out hit, weaponRange))
                {
                    laserLine.SetPosition(1, hit.point);

                    var health = hit.collider.GetComponent<CreaturesBehavior>();
                    if (health != null)
                    {
                        health.TakeDamaged(gunDamage);
                    }
                    if (hit.rigidbody != null)
                    {
                        hit.rigidbody.AddForce(-hit.normal * hitForce);
                    }
                }
                else
                {
                    laserLine.SetPosition(1, rayOrigin + (this.transform.up * weaponRange));
                }
                player.curramo--;
            }
        }
    }
    private IEnumerator ShotEffect()
    {
        gunAudio.Play();
        laserLine.enabled = true;
        yield return shotDuration;
        laserLine.enabled = false;
    }

/*    public void Updown(float direction)
    {
        this.transform.localRotation = Quaternion.Euler(direction + 90, transform.localRotation.y, transform.localRotation.z);
    }*/
}
