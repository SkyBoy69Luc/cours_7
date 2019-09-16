using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour {

    Rigidbody rbd;
    public int lifeSpan = 3;
    public int bulletSpeed = 1;
    public int BulletDamage = 1;
    private float TimeLeafToLive;

    // Use this for initialization
    void Start () {
        rbd = GetComponent<Rigidbody>();
        TimeLeafToLive = lifeSpan;

    }
	
	// Update is called once per frame
	void Update () {

        rbd.MovePosition(rbd.position + transform.forward * bulletSpeed * Time.deltaTime);
        ApplyLifeSpan();

	}

    private void ApplyLifeSpan()
    {
        TimeLeafToLive -= Time.deltaTime;
        if (TimeLeafToLive <0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    public void OnTriggerEnter(Collider otherObject)
    {
        Damagable damagable = otherObject.GetComponentInParent<Damagable>();

        if (damagable != null)
        {
            damagable.TakeDamage(BulletDamage);
        }
        Die();
    }
}
