namespace ScreenManagerModule.Interface.Entities
{
    public enum ScreenType
    {
        //TODO: need better naming
        Scene,
        Screen
    }
    
    public struct ScreenEntity
    {
        public string ScreenName  { get; private set; }
        public ScreenType ScreenType  { get; private set; }
        public bool IsTopLayer;
        
        //TODO: need better naming
        public static ScreenEntity Screen(string screenName)
        {
            return new ScreenEntity
            {
                ScreenName = screenName,
                ScreenType = ScreenType.Screen,
            };
        }
        
        //TODO: need better naming
        public static ScreenEntity Scene(string screenName, bool isTopLayer = false)
        {
            return new ScreenEntity
            {
                ScreenName = screenName,
                ScreenType = ScreenType.Scene,
                IsTopLayer = isTopLayer
            };
        }
    }
}
