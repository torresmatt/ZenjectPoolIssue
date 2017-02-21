using UnityEngine;
using Zenject;

namespace SparrowHawk.Scripts.Weapon.Ammo.Bullet
{
    public class BulletInstaller : MonoInstaller<BulletInstaller>
    {
        [SerializeField] [InjectOptional] private BulletSettings _bulletSettings;

        public override void InstallBindings()
        {
            Container.BindInstance(_bulletSettings).WhenInjectedInto<BulletModel>();
            Container.Bind<BulletModel>().AsSingle();
            Container.BindInterfacesTo<BulletController>().AsSingle();
        }
    }
}