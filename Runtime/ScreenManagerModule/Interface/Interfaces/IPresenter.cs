using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using ScreenManagerModule.Interface.Entities;
namespace ScreenManagerModule.Interface.Interfaces
{
    public interface IPresenter
    {
        public UniTask Initialize(ScreenEntity screen, Dictionary<string, object> screenParamenters);
        public UniTask Close();
    }
}
