using System;
using SparrowHawk.Scripts.Extension;
using UnityEngine;
using Zenject;

namespace SparrowHawk.Scripts.Weapon.Ammo.Bullet
{
    public class BulletView : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private Rigidbody2D _rigidbody2D;

        public event Action Enabled;
        public event Action Spawned;
        public event Action Despawned;
        public event Action<Collision2D> Collided;

        void OnEnable()
        {
            if (Enabled != null) Enabled();
        }

        public bool IsVisible
        {
            get { return _spriteRenderer.isVisible; }
        }

        public Rigidbody2D Rigidbody2D
        {
            get { return _rigidbody2D; }
        }

        public Vector3 Position
        {
            get { return transform.position; }
            set { transform.position = value; }
        }

        public Quaternion Rotation
        {
            get { return transform.rotation; }
            set { transform.rotation = value; }
        }

        protected void OnSpawned()
        {
            Spawned.Raise();
        }

        protected void OnDespawned()
        {
            Despawned.Raise();
        }

        void OnCollisionEnter2D(Collision2D other)
        {
            if (Collided != null) Collided(other);
        }

        public class Factory : MonoMemoryPool<BulletSettings, BulletView>
        {
            protected override void OnCreated(BulletView item)
            {
                Debug.Log("Bullet created.");
            }

            protected override void OnSpawned(BulletView item)
            {
                Debug.Log("Bullet spawned.");
                item.gameObject.SetActive(true);
                item.OnSpawned();
            }

            protected override void OnDespawned(BulletView item)
            {
                item.gameObject.SetActive(false);
                item.OnDespawned();
            }

            protected override void Reinitialize(BulletSettings bulletSettings, BulletView item)
            {
                item.Rotation = Quaternion.identity;
                item.Position = Vector3.zero;
            }
        }
    }
}