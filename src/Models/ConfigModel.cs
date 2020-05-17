namespace Mg.Temp {
    public class ConfigModel {
        public PlayerConfigModel Player { get; set; }
    }

    public class PlayerConfigModel {
        public int SpriteSize { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }
    }

}
