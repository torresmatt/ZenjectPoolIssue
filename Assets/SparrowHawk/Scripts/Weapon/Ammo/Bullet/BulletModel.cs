using Zenject;

namespace SparrowHawk.Scripts.Weapon.Ammo.Bullet
{
    public class BulletModel
    {
        private readonly BulletSettings _bulletSettings;

        [Inject]
        public BulletModel(BulletSettings bulletSettings)
        {
            _bulletSettings = bulletSettings;
        }

        public int Damage
        {
            get { return _bulletSettings.Damage; }
        }

        public float Speed
        {
            get { return _bulletSettings.Speed; }
        }

        public float LifeTime
        {
            get { return _bulletSettings.LifeTime; }
        }
    }
}