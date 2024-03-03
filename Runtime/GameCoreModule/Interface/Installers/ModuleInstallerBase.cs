using Zenject;
namespace GameCoreModule.Interface.Installers
{
    public abstract class ModuleInstallerBase<TInternalInstaller> : MonoInstaller
        where TInternalInstaller : Installer
    {
        protected abstract string SubContainerName { get; }
        
        public override void InstallBindings()
        {
            var subContainer = Container.CreateSubContainer();
            subContainer.Install<TInternalInstaller>();
            
            Container.Bind<DiContainer>()
                .WithId(SubContainerName)
                .FromInstance(subContainer)
                .AsCached();
        }

        protected ScopeConcreteIdArgConditionCopyNonLazyBinder BindEntityFromSubContainer<TInterface, TSubContainerEntity>(object identifier = null) where TSubContainerEntity : TInterface
        {
            return Container.Bind<TInterface>()
                .WithId(identifier)
                .To<TSubContainerEntity>()
                .FromSubContainerResolve()
                .ByInstanceGetter(SubContainerInstanceGetter);
            
            /*Container.ResolveId<DiContainer>(SubContainerName).Bind<TInterface>()
                .WithId(identifier)
                .To<TEntity>().AsTransient();*/
        }

        private DiContainer SubContainerInstanceGetter(InjectContext containerContext)
        {
            return containerContext.Container.ResolveId<DiContainer>(SubContainerName);
        }
    }
}
