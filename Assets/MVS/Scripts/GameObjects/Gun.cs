using MVS.Static;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField]
    private Transform _shootPoint;
    [SerializeField]
    private Magazine _insertedMagazine;
    [SerializeField]
    private Transform _magazineSlot;

    private void Awake()
    {
        PlayerInput.OnShoot += Shoot;
    }

    public void Shoot()
    {
        if (!gameObject.activeInHierarchy)
            return;
        
        BulletObject bullet = _insertedMagazine.TopMostBullet;
        if (bullet == null)
            return;
        
        GameObject spawnedBullet = Instantiate(bullet.AssociatedPrefab, _shootPoint.transform.position, Quaternion.identity, null);
        spawnedBullet.transform.rotation = Quaternion.FromToRotation(spawnedBullet.transform.forward, transform.forward);

        Rigidbody bulletRigidbody = spawnedBullet.GetComponent<Rigidbody>();
        bulletRigidbody.velocity = bulletRigidbody.transform.forward * bullet.StartingVelocity;
        bulletRigidbody.mass = bullet.Mass;
    }
}
