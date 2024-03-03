using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using ScreenManagerModule.Interface.Interfaces;
using Zenject;
namespace ScreenManagerModule.Interface.Entities
{
    public abstract class PresenterBase : IPresenter
    {
        [Inject] protected readonly IScreensManager screensManager;

        protected ScreenEntity screen;
        protected Dictionary<string, object> screenParamenters { get; set; }
        
        async UniTask IPresenter.Initialize(ScreenEntity screen, Dictionary<string, object> screenParamenters)
        {
            this.screen = screen;
            this.screenParamenters = screenParamenters;
            
            await Initialize();
        }
        
        private async UniTask Initialize()
        {
            await BeforeSpawn();
            OnSpawn();
            AfterSpawn();
        }

        protected virtual UniTask BeforeSpawn()
        {
            return UniTask.CompletedTask;
        }

        protected virtual void OnSpawn() {}

        protected virtual void AfterSpawn() {}

        protected T GetScreenParameter<T>(string parameterId, T defaultValue = default(T))
        {
            return screenParamenters.TryGetValue(parameterId, out var parameter)
                ? (T)parameter
                : defaultValue;
        }

        protected async UniTask Close()
        {
            await BeforeClose();
            await OnClose();
            await AfterClose();
        }

        protected virtual UniTask BeforeClose() => UniTask.CompletedTask;
        protected virtual UniTask OnClose()
        {
            screensManager.OnScreenClose(screen);
            return UniTask.CompletedTask;
        }
        protected virtual UniTask AfterClose() => UniTask.CompletedTask;

        async UniTask IPresenter.Close()
        {
            await Close();
        }
    }

    public abstract class ScenePresenterBase : PresenterBase
    {
        
    }
    
    public abstract class ScreenPresenterBase<TView> : PresenterBase where TView : IView
    {
        protected TView View;

        protected abstract string ViewPrefabName { get; }

        protected override void OnSpawn()
        {
            screensManager.GetView(ViewPrefabName, screen, out View);
        }

        protected override async UniTask OnClose()
        {
            View.Destroy();
            
            await base.OnClose();
        }
    }
}
