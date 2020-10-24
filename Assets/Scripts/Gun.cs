using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 15f;
    public float timeToFire = 0f;
    public int ammo = 10;
    public int maxAmmo = 10;
    public Camera fpsCamera;
    public ParticleSystem muzzleFlash;
    public GameObject hitEffect;

    public Animator gunAnimator;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Stat.ammo = ammo;

        if (Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(Reload());
        }

        if (ammo > 0)
        {
            if (Input.GetKey(KeyCode.Mouse0) && Time.time >= timeToFire)
            {
                timeToFire = Time.time + 1f / fireRate;
                Shoot();
            }
        }
 
    }

    void Shoot()
    {
        muzzleFlash.Play();

        RaycastHit hit;
        if (Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out hit, range))
        {
            Target target = hit.transform.GetComponent<Target>();
            Explosion explosion = hit.transform.GetComponent<Explosion>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }
            if (explosion != null)
            {
                explosion.explode();
            }

            GameObject hitImpact = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(hitImpact, 1f);
        }

        ammo--;
    }

    IEnumerator Reload()
    {
        gunAnimator.SetBool("isReload", true);
        yield return new WaitForSeconds(2f);
        ammo = maxAmmo;
        gunAnimator.SetBool("isReload", false);
    }
}
