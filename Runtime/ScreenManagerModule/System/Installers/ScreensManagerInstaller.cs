using GameCoreModule.Interface.Installers;
using ScreenManagerModule.System.Components;
using ScreenManagerModule.System.Managers;
using UnityEngine;
using Zenject;
namespace ScreenManagerModule.System.Installers
{
    public class ScreensManagerInstaller : ModuleInstallerBase<ScreensManagerLocalInstaller>
    {
        [SerializeField] private RootScreensCanvas rootScreensCanvas;

        protected override string SubContainerName => "ScreensManager";
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<ScreensManager>().AsSingle();
            
            Container.Bind<RootScreensCanvas>().FromComponentInNewPrefab(rootScreensCanvas).AsSingle();
        }
    }

    public class ScreensManagerLocalInstaller : Installer
    {
        public override void InstallBindings()
        {
            
        }
    }
}
