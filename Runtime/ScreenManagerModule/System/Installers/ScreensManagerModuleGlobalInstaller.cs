using ScreenManagerModule.System.Components;
using ScreenManagerModule.System.Managers;
using UnityEngine;
using Zenject;
namespace ScreenManagerModule.System.Installers
{
    public class ScreensManagerGlobalInstaller : MonoInstaller
    {
        [SerializeField] private RootScreensCanvas rootScreensCanvas;
        
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<ScreensManager>().AsSingle();
            
            Container.Bind<RootScreensCanvas>().FromComponentInNewPrefab(rootScreensCanvas).AsSingle();
        }
    }
}
