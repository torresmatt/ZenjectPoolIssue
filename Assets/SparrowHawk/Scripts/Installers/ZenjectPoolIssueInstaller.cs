using SparrowHawk.Scripts.Weapon.Ammo.Bullet;
using UnityEngine;
using Zenject;

namespace SparrowHawk.Scripts.Installers
{
    public class ZenjectPoolIssueInstaller : MonoInstaller
    {
        [SerializeField] private GameObject _bulletPrefab;

        public override void InstallBindings()
        {
            Container.BindMemoryPool<BulletView, BulletView.Factory>()
                .FromSubContainerResolve()
                .ByNewPrefab(_bulletPrefab)
                .UnderTransformGroup("Ammo");
        }
    }
}