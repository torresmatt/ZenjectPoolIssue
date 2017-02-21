using System;
using UnityEngine;
using Zenject;

namespace SparrowHawk.Scripts.Weapon.Ammo.Bullet
{
    public class BulletController : IInitializable, IDisposable, IFixedTickable
    {
        private readonly BulletView.Factory _bulletPool;
        private readonly BulletModel _bulletModel;
        private readonly BulletView _bulletView;

        private float _startTime;

        private BulletController(BulletView.Factory bulletPool, BulletModel bulletModel, BulletView bulletView)
        {
            _bulletPool = bulletPool;
            _bulletModel = bulletModel;
            _bulletView = bulletView;

            // This is a workaround for Initialize firing after OnSpawn the first time around.
            _bulletView.Spawned += HandleSpawned;
            _bulletView.Collided += HandleCollided;
        }

        public void Initialize()
        {
            Debug.Log("BulletController Initialized.");
            // _bulletView.Spawned += HandleSpawned;
            // _bulletView.Collided += HandleCollided;
        }

        public void Dispose()
        {
            _bulletView.Spawned -= HandleSpawned;
            _bulletView.Collided -= HandleCollided;
        }

        public void FixedTick()
        {
            if (IsExpired()) Die();

            _bulletView.transform.position += _bulletView.transform.right * _bulletModel.Speed * Time.deltaTime;
        }

        private void HandleSpawned()
        {
            _startTime = Time.realtimeSinceStartup;
        }

        private void HandleCollided(Collision2D other)
        {
            // Do stuff
            Die();
        }

        private bool IsExpired()
        {
            return (Time.realtimeSinceStartup - _startTime > _bulletModel.LifeTime) || !_bulletView.IsVisible;
        }

        private void Die()
        {
            _bulletPool.Despawn(_bulletView);
        }
    }
}