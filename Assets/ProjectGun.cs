using UnityEngine;
using TMPro;

public class ProjectGun : MonoBehaviour
{
    //bullet
    public GameObject bullet;

    //bullet force
    public float shootForce, upwardForce;

    //Gun stats
    public float timeBetweenShooting, spread, reloadTime, timeBetweenShots;
    public int magSize, bulletPer;
    public bool allowHold;

    int bulletLeft, bulletShot;

    //recoil
    public Rigidbody playerRb;
    public float recoilForce;

    //bools
    bool shooting, readyToShoot, reloading;

    //reference
    public Camera fpsCam;
    public Transform attackPoint;

    //graphic
    public GameObject muzzleFlash;
    public TextMeshProUGUI ammunitionDisplay;

    //bug fixing
    public bool allowInvoke = true;

    private void Awake()
    {
        //to see if magazine is full or not
        bulletLeft = magSize;
        readyToShoot = true;
    }

    private void Update()
    {
        MyInput();

        //set ammo display if exist
        if (ammunitionDisplay != null)
            ammunitionDisplay.SetText(bulletLeft / bulletPer + " / " + magSize / bulletPer);
    }

    private void MyInput()
    {
        //to make sure if its allowed to hold button down and take corresponding input
        if (allowHold) shooting = Input.GetKey(KeyCode.Mouse0);
        else shooting = Input.GetKeyDown(KeyCode.Mouse0);

        //reloading
        if (Input.GetKeyDown(KeyCode.R) && bulletLeft < magSize && !reloading) Reload();
        //reload auto when trying to shoot with empty mag
        if (readyToShoot && shooting && !reloading && bulletLeft <= 0) Reload();

        //shoot
        if (readyToShoot && shooting && !reloading && bulletLeft > 0)
        {
            bulletShot = 0;

            Shoot();
        }
    }

    private void Shoot()
    {
        readyToShoot = false;

        //Pinpoint exact hit location using raycast
        Ray ray = fpsCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        //check if the ray hits anything
        Vector3 targetPoint;
        if (Physics.Raycast(ray, out hit))
            targetPoint = hit.point;
        else
            targetPoint = ray.GetPoint(75); //point far away from the player

        //Calculate direction from attackpoint to targetpoint
        Vector3 directionWithoutSpread = targetPoint - attackPoint.position;

        //calculate spread
        float x = Random.Range(-spread, spread);
        float y = Random.Range(-spread, spread);

        //calculate new direction with spread
        Vector3 directionWithSpread = directionWithoutSpread + new Vector3(x, y, 0);

        //instantiate bullet.projectile
        GameObject currentBullet = Instantiate(bullet, attackPoint.position, Quaternion.identity);
        //rotate bullet
        currentBullet.transform.forward = directionWithSpread.normalized;

        //add force to bullet
        currentBullet.GetComponent<Rigidbody>().AddForce(directionWithSpread.normalized * shootForce, ForceMode.Impulse);
        currentBullet.GetComponent<Rigidbody>().AddForce(fpsCam.transform.up * upwardForce, ForceMode.Impulse);

        //instantiate muzzle flash if one exist
        if (muzzleFlash != null)
            Instantiate(muzzleFlash, attackPoint.position, Quaternion.identity);



        bulletLeft--;
        bulletShot++;

        //invoke reset shot function if not invoke
        if (allowInvoke)
        {
            Invoke("ResetShot", timeBetweenShooting);
            allowInvoke = false;

            //Add recoil
            playerRb.AddForce(-directionWithSpread.normalized * recoilForce, ForceMode.Impulse);
        }

        //if more than one bulletper make sure to repeat the shot function
        if (bulletShot < bulletPer && bulletLeft > 0)
            Invoke("Shoot", timeBetweenShots);
    }

    private void ResetShot()
    {
        //allow shooting & invoking
        readyToShoot = true;
        allowInvoke = true;
    }

    private void Reload()
    {
        reloading = true;
        Invoke("ReloadFinished", reloadTime);
    }

    private void ReloadFinished()
    {
        bulletLeft = magSize;
        reloading = false;
    }


}
