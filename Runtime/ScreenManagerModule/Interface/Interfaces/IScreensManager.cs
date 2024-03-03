using System.Collections.Generic;
using ScreenManagerModule.Interface.Entities;
namespace ScreenManagerModule.Interface.Interfaces
{
    public interface IScreensManager
    {
        void OpenScreen(ScreenEntity screen, Dictionary<string, object> parameters = null);
        void GetView<TView>(string viewPrefabName, ScreenEntity screen, out TView view) where TView : IView;
        void OnScreenClose(ScreenEntity screen);
    }
}
