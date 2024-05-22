using System.Collections.Generic;
using System.Linq;
using MVS.Static;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField]
    private Transform _shootPoint;
    [SerializeField]
    private List<BulletObject> _bullets = new List<BulletObject>();

    private void Awake()
    {
        PlayerInput.OnShoot += Shoot;
    }

    public void Shoot()
    {
        BulletObject bullet = _bullets.LastOrDefault();
        if (bullet == null)
            return;

        _bullets.Remove(bullet);
        
        GameObject spawnedBullet = Instantiate(bullet.AssociatedPrefab, _shootPoint.transform.position, Quaternion.identity, null);
        spawnedBullet.transform.rotation = Quaternion.FromToRotation(spawnedBullet.transform.forward, transform.forward);

        Rigidbody bulletRigidbody = spawnedBullet.GetComponent<Rigidbody>();
        bulletRigidbody.velocity = bulletRigidbody.transform.forward * bullet.StartingVelocity;
        bulletRigidbody.mass = bullet.Mass;
    }
}
