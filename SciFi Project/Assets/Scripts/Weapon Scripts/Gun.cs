using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    // Public variables for gun
    public float damage = 10f;
    public float range = 100f;
    public float impactForce = 15f;
    public float fireRate = 15f;
    public bool autoFire = false;

    public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    //public GameObject impactEffect;

    //Timer for auto-fire
    private float nextTimeToFire = 0f;

    // Audio & Animation Variables
    private AudioSource m_shootingSound;
    private Animator anim;

    private void Start()
    {
        m_shootingSound = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            autoFire = true;
        }

        if (Input.GetButtonDown("Fire1") && autoFire == false)
        {
            m_shootingSound.Play();
            anim.Play("GunFiring");
            Shoot();
        }

        if (Input.GetButtonDown("Fire1") && autoFire == true && Time.time >= nextTimeToFire)
        {
            m_shootingSound.Play();
            anim.Play("GunFiring");
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }
    }
void Shoot()
    {
        muzzleFlash.Play();              // Plays the muzzle flash when gun is fired

        RaycastHit hit;

        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

           Target target = hit.transform.GetComponent<Target>();
            if(target != null)
            {
                target.TakeDamage(damage);
            }

            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }
            //GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
           // Destroy(impactGO, 2f);
        }
    }

    // Toggles the semi-auto to full-auto fire state
    void ToggleShoot()
    {
        if(Input.GetKey(KeyCode.Alpha1))
        {
            autoFire = !autoFire;
        }
    }
}
