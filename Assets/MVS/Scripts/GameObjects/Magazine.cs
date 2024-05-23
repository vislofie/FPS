using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Magazine : MonoBehaviour
{
    [SerializeField]
    private BulletObject[] _allowedBullets;
    [SerializeField]
    private List<BulletObject> _bulletsInside = new List<BulletObject>();
    [SerializeField]
    private int _maxAmount;

    private void Awake()
    {
        for (int i = _bulletsInside.Count - 1; i >= 0; i--)
        {
            if (!_allowedBullets.Contains(_bulletsInside[i]))
            {
                _bulletsInside.Remove(_bulletsInside[i]);
            }
        }
    }

    private void OnValidate()
    {
        if (_bulletsInside.Count > _maxAmount)
        {
            _bulletsInside.RemoveRange(_maxAmount - 1, _bulletsInside.Count - _maxAmount);
        }
    }

    public BulletObject TopMostBullet
    {
        get
        {
            if (_bulletsInside.Count > 0)
            {
                BulletObject bullet = _bulletsInside[0];
                _bulletsInside.Remove(bullet);
                return bullet;
            }
            
            return null;
        }
    }
}
