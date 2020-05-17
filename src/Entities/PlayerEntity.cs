using Microsoft.Xna.Framework.Graphics;

namespace Mg.Temp {
    public struct PlayerEntity {
        public Texture2D texture;
        public string name;
        public int health;
        public bool isColliding;
        public bool isTakingDamage;
        public bool isMovingRight;
        public bool isMovingLeft;
        public bool isMovingUp;
        public bool isMovingDown;
        public bool isJumping;
        public bool isOnFloor;
    }
}
