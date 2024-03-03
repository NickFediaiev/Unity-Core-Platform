using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using ScreenManagerModule.Interface.Entities;
using ScreenManagerModule.Interface.Interfaces;
using ScreenManagerModule.System.Components;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;
namespace ScreenManagerModule.System.Managers
{
    public class ScreensManager : IScreensManager
    {
        [Inject] private DiContainer container;
        [Inject] private readonly RootScreensCanvas canvas;
        
        private readonly Dictionary<ScreenEntity, IPresenter> presenters = new();
        
        public async void OpenScreen(ScreenEntity screen, Dictionary<string, object> parameters = null)
        {
            if (screen.ScreenType == ScreenType.Scene)
            {
                await ClosePresenters();
                await SceneManager.LoadSceneAsync(screen.ScreenName, LoadSceneMode.Single);
                await CleanResources();
            }
            
            var presenter = container.ResolveId<IPresenter>(screen);
            await presenter.Initialize(screen, parameters);
            
            presenters.Add(screen, presenter);
        }
        
        public void GetView<TView>(string viewPrefabName, ScreenEntity screen, out TView view) where TView : IView
        {
            view = container.InstantiatePrefabResourceForComponent<TView>(viewPrefabName, screen.IsTopLayer ? canvas.TopLayer : canvas.StandardLayer);
        }

        public void OnScreenClose(ScreenEntity screen)
        {
            presenters.Remove(screen);
        }

        private async Task ClosePresenters()
        {
            var openedPresenters = presenters.Where(e => !e.Key.IsTopLayer).Select(e => e.Value).ToArray();
            foreach (var presenter in openedPresenters)
                await presenter.Close();
        }
        
        private async UniTask CleanResources()
        {
            await Resources.UnloadUnusedAssets();
            GC.Collect();
        }
    }
}
