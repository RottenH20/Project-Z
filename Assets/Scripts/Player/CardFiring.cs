using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardFiring : MonoBehaviour
{
    /* TO DO
     * Shots are being left in the air and never updated
     * Left Weapon line always active
     */

    public int gunDamage = 1;
    public float fireRate = .25f;
    public float weaponRange = 50f;
    public Transform gunEndRight;
    public Transform gunEndLeft;
    public Camera fpsCam;
    public float passiveProcRate = 5;
    public GameObject spherePassive;
    public TrailRenderer tracerEffect;


    private WaitForSeconds shotDuration = new WaitForSeconds(.20f);
    //private AudioSource gunAudio;
    private LineRenderer laserLineRight;
    private LineRenderer laserLineLeft;
    private float nextFire;
    private int layerMask = 10;
    private bool rightWeaponFiring = true;
    private float passiveProcCount;

    void Start()
    {
        laserLineRight = gunEndRight.GetComponent<LineRenderer>();
        laserLineLeft = gunEndLeft.GetComponent<LineRenderer>();
        //gunAudio = GetComponent<AudioSource>();
        gameObject.layer = 8;
        passiveProcCount = passiveProcRate; 
    }

    void Update() 
    {
        if (Input.GetButtonDown("Fire1") && Time.time > nextFire && ClassCard.cooldownQReadyGet()) // Check if dualWeilding
        {
            if (!rightWeaponFiring)
            {
                rightWeaponFiring = true;
            }
            else
            {
                rightWeaponFiring = false;
            }
            nextFire = Time.time + fireRate/2;
            StartCoroutine(ShotEffect());

            Vector3 rayOrigin = fpsCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hit;

            var tracer = Instantiate(tracerEffect, rayOrigin, Quaternion.identity);
            tracer.AddPosition(rayOrigin);

            laserLineRight.SetPosition(0, gunEndRight.position);
            laserLineLeft.SetPosition(0, gunEndLeft.position);

            if (Physics.Raycast(rayOrigin, fpsCam.transform.forward, out hit, weaponRange, ~layerMask) && passiveProcCount != 1)
            {
                //laserLineRight.SetPosition(1, hit.point);
                //laserLineLeft.SetPosition(1, hit.point);
                tracer.transform.position = hit.point;
                passiveProcCount--;
            }
            else if (Physics.Raycast(rayOrigin, fpsCam.transform.forward, out hit, weaponRange, ~layerMask) && passiveProcCount == 1)
            {
                Instantiate(spherePassive, hit.point, Quaternion.identity);
                //laserLineRight.SetPosition(1, hit.point);
                //laserLineLeft.SetPosition(1, hit.point);
                passiveProcCount = passiveProcRate;
            }
            else
            {
                //laserLineRight.SetPosition(1, rayOrigin + (fpsCam.transform.forward * weaponRange));
                //laserLineLeft.SetPosition(1, rayOrigin + (fpsCam.transform.forward * weaponRange));
            } 
        }
        if (Input.GetButtonDown("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            StartCoroutine(ShotEffect());

            Vector3 rayOrigin = fpsCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hit;

            laserLineRight.SetPosition(0, gunEndRight.position);

            var tracer = Instantiate(tracerEffect, rayOrigin, Quaternion.identity);
            tracer.AddPosition(rayOrigin);

            if (Physics.Raycast(rayOrigin, fpsCam.transform.forward, out hit, weaponRange, ~layerMask) && passiveProcCount != 1)
            {
                //laserLineRight.SetPosition(1, hit.point);
                tracer.transform.position = hit.point;
                passiveProcCount--;
            }
            else if (Physics.Raycast(rayOrigin, fpsCam.transform.forward, out hit, weaponRange, ~layerMask) && passiveProcCount == 1)
            {
                Instantiate(spherePassive, hit.point, Quaternion.identity);
                //laserLineRight.SetPosition(1, hit.point);
                tracer.transform.position = hit.point;
                passiveProcCount = passiveProcRate;
            }
            else
            {
                //laserLineRight.SetPosition(1, rayOrigin + (fpsCam.transform.forward * weaponRange));
                tracer.transform.position = hit.point;
            }
        }
    }

    private IEnumerator ShotEffect() 
    {
        //gunAudio.Play();

        if (rightWeaponFiring)
        {
            //laserLineRight.enabled = true;
            yield return shotDuration;
            //laserLineRight.enabled = false;
        }
        else
        {
            //laserLineLeft.enabled = true;
            yield return shotDuration;
            //laserLineLeft.enabled = false;
        }
    }
}
