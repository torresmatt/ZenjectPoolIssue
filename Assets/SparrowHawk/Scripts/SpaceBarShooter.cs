using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using SparrowHawk.Scripts.Weapon.Ammo.Bullet;

public class SpaceBarShooter : MonoBehaviour
{
    BulletView.Factory _bulletPool;

    [SerializeField] BulletSettings _bulletSettings;

    public float LastShootTime { get; set; }

    [Inject]
    void Construct(BulletView.Factory bulletPool)
    {
        _bulletPool = bulletPool;
    }
	
	void Update () 
    {
        if (!IsReadyToFire) return;

	    if (Input.GetKey(KeyCode.Space))
	    {
            BulletView bullet = _bulletPool.Spawn(_bulletSettings);

            bullet.Position = transform.position;
            bullet.Rotation = transform.rotation;
            LastShootTime = Time.realtimeSinceStartup;
	    }
	}

    public bool IsReadyToFire
    {
        get { return Time.realtimeSinceStartup - LastShootTime > .3; }
    }
}
