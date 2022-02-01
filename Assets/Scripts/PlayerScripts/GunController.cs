using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GunController : MonoBehaviour
{
    [Header("Parameters")]
    
    int maxAmmo;
    int currentAmmo;
    int bulletNo = 3;
    int bulletCounter;
    float range;
    float fireRate;
    float reloadTime;
    float nextTimeToFire = 0f;
    float spreadX = 2f;
    float spreadY = 1.5f;
    bool isReloading = false;
    bool isPistol;


    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Text ammoText;
    [SerializeField] Animator animator;
    [SerializeField] WeaponSettings weaponSettings;
    [SerializeField] Camera fpsCam;
    [SerializeField] Transform muzzlePos;
    void Start()
    {
        SetValues();
    }

    void SetValues()
    {
        range = weaponSettings.Range;
        fireRate = weaponSettings.FireRate;
        maxAmmo = weaponSettings.MaxAmmo;
        reloadTime = weaponSettings.ReloadTime;
        isPistol = weaponSettings.IsPistol;
        currentAmmo = maxAmmo;
        ammoText.text = "MAGAZINE = " + currentAmmo.ToString() + "/" + maxAmmo.ToString();
    }
    private void OnEnable()
    {
        isReloading = false;
        animator.SetBool("Reloading", false);
        ammoText.text = "MAGAZINE = " + currentAmmo.ToString() + "/" + maxAmmo.ToString();

    }
    void Update()
    {
        if (LevelManager.gameState==GameState.Normal)
        {
            if (isReloading)
            {
                return;
            }
            if (currentAmmo <= 0)
            {
                StartCoroutine(ReloadFunc());
                return;
            }
            if (isPistol)
            {
                if (Input.GetButtonDown("Fire1") && Time.time >= nextTimeToFire)
                {
                    nextTimeToFire = Time.time + 1f / fireRate;
                    Shoot();
                }
            }
            else if (!isPistol)
            {
                if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
                {
                    nextTimeToFire = Time.time + 1f / fireRate;
                    Shoot();
                }
            }
        }
    }

    void Shoot() //Unity Tutorial
    {
        currentAmmo-=bulletNo;
        ammoText.text = "MAGAZINE = " + currentAmmo.ToString() + "/" + maxAmmo.ToString();
        
        Ray ray = fpsCam.ViewportPointToRay(new Vector3(.5f, .5f, 0));
        RaycastHit hit;
        Vector3 targetPoint;
        if (Physics.Raycast(ray,out hit,range))
        {
            targetPoint = hit.point;
        }
        else
        {
            targetPoint = ray.GetPoint(range);
        }

        Vector3 direction = targetPoint - muzzlePos.position;
        float x = Random.Range(-spreadX,spreadX);
        float y = Random.Range(-spreadY,spreadY);

        Vector3 directionWithSpread = direction + new Vector3(x, y, 0);
        for (int i = 0; i < bulletNo; i++)
        {
            GameObject myBullet = Instantiate(bulletPrefab, muzzlePos.position, Quaternion.identity);
            myBullet.transform.forward = directionWithSpread.normalized;
            myBullet.GetComponent<BulletController>().BulletMovement();
            Destroy(myBullet, 1.3f);
            
        }
        bulletCounter += bulletNo;
        ammoText.transform.GetChild(0).GetComponent<Text>().text = "Bullet Counter = " + bulletCounter;

    }


    IEnumerator ReloadFunc()
    {
        isReloading = true;

        Debug.Log("Reloading");
        animator.SetBool("Reloading", true);

        yield return new WaitForSeconds(reloadTime-.25f);

        animator.SetBool("Reloading", false);

        yield return new WaitForSeconds(.25f);

        currentAmmo = maxAmmo;
        ammoText.text = "MAGAZINE = " + currentAmmo.ToString() + "/" + maxAmmo.ToString();

        isReloading = false;
    }
}
