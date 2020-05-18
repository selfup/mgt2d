namespace Mg.Temp {
    public struct ConfigModel {
        public PlayerConfigModel Player { get; set; }
    }

    public struct PlayerConfigModel {
        public string Sprite { get; set; }
        public int SpriteSize { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
    }
}
