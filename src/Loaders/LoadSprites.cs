using System;
using System.IO;
using System.Collections.Concurrent;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Mg.Temp {
    public class LoadSprites : Game {
        const string SPRITES_PATH = "Content/sprites/";
        public ConcurrentDictionary<string, Texture2D> sprites;

        public LoadSprites(GraphicsDevice graphicsDevice) {
            sprites = new ConcurrentDictionary<string, Texture2D>();

            string[] fileEntries = Directory.GetFiles(SPRITES_PATH);

            Array.ForEach(fileEntries, (filePath) => {
                loadTexture(graphicsDevice, filePath);
            });
        }

        private void loadTexture(
            GraphicsDevice graphicsDevice,
            string spritePath
        ) {
            string spriteName;
            Texture2D sprite;

            spriteName = spritePath.Replace(SPRITES_PATH, "");
            spriteName = spriteName.Replace(".png", "");

            using (Stream spriteFile = File.OpenRead(spritePath))
                sprite = Texture2D.FromStream(graphicsDevice, spriteFile);

            sprites[spriteName] = sprite;
        }
    }
}
