using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] GameObject explosionPrefab;
    Material bulletMaterial;
    Vector3 hugeBulletSize;
    Vector3 regularBulletSize;
    void Start()
    {
        SetValues();

        if (GameManager.HugeBulletButton == 1)
        {
            transform.localScale = hugeBulletSize;
        }
        else
        {
            transform.localScale = regularBulletSize;
        }

        if (GameManager.RedBulletButton == 1)
        {
            bulletMaterial.color = Color.red;
        }
        else
        {
            bulletMaterial.color = Color.yellow;
        }

        if (GameManager.ExplosiveBulletButton == 1)
        {
            StartCoroutine(ExplosiveBulletFunc());
        }

    }

    void SetValues()
    {
        bulletMaterial = GetComponent<MeshRenderer>().material;
        hugeBulletSize = new Vector3(3f, 3f, 3f);
        regularBulletSize = transform.localScale;
    }


    public void BulletMovement()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        Vector3 dir = transform.forward;
        rb.AddForce(dir * 20 , ForceMode.Impulse);

    }

    IEnumerator ExplosiveBulletFunc()
    {
        yield return new WaitForSeconds(1);
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
    }
}
