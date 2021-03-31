using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 50f;

    public int damage = 50;
    public GameObject impactEffect;
    public float explosionRadius = 0f;
    private Transform _target;

    public void Seek (Transform _target)
    {
        this._target = _target;
    }

    private void Update()
    {
        if(_target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = _target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if(dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        transform.LookAt(_target);
    }

    void HitTarget()
    {
        GameObject effectInst = Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectInst, 4f);

        if(explosionRadius > 0f)
        {
            Explode();
        }
        else
        {
            Damage(_target);
        }

        
        Destroy(gameObject);
    }

    void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider collider in colliders)
        {
            if(collider.tag == "Enemy")
            {
                Damage(collider.transform);
            }
        }
    }

    void Damage(Transform enemy)
    {
        Enemy e = enemy.GetComponent<Enemy>();

        if (e != null)
        {
            e.TakeDamage(damage);
        }

    }
}
