using System;
using ScreenManagerModule.Interface.Interfaces;
namespace ScreenManagerModule.Interface.Entities
{
    public abstract class SubPresenterBase<TView>where TView : IView
    {
        protected TView view;

        public void InjectView(TView view)
        {
            this.view = view;

            OnInjectView();
        }

        public virtual void Close() {}

        protected virtual void OnInjectView() {}
    }
}
