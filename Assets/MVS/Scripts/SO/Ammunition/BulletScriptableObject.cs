using UnityEngine;

[CreateAssetMenu(fileName = "Bullet", menuName = "ScriptableObjects/Ammunition/Bullet")]
public class BulletObject : ScriptableObject
{
    public string Name;
    public float Damage;
    public float Recoil;
    [Tooltip("In kg")]
    public float Mass;
    public float StartingVelocity;

    [Space(10)]
    public GameObject AssociatedPrefab;
}
