using GameCoreModule.Interface.Installers;
using MultiplayerModule.Interface.Interfaces;
using MultiplayerModule.System.Components;
using MultiplayerModule.System.Manager;
using UnityEngine;
using Zenject;
namespace MultiplayerModule.System.Installers
{
    public class MultiplayerModuleInstaller : ModuleInstallerBase<MultiplayerLocalInstaller>
    {
        [SerializeField] private MultiplayerManagerComponents multiplayerManagerComponents;
        
        protected override string SubContainerName => "Multiplayer";
        
        public override void InstallBindings()
        {
            base.InstallBindings();
            
            BindEntityFromSubContainer<IMultiplayerManager, IMultiplayerManager>().AsCached();
            
            //TODO: bind into subcontainer only
            Container.Bind<MultiplayerManagerComponents>().FromComponentInNewPrefab(multiplayerManagerComponents).AsSingle();
        }
    }

    public class MultiplayerLocalInstaller : Installer
    {
        public override void InstallBindings()
        {
            Container.Bind<IMultiplayerManager>().To<MultiplayerManager>().AsCached();
        }
    }
}