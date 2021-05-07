using MacApp05Game.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace MacApp05Game.Controllers
{
    public class AsteroidController
    {
        private readonly List<Sprite> Asteroids;
        private SoundEffect explosionEffect;

        public AsteroidController()
        {
            Asteroids = new List<Sprite>();
        }

        /// <summary>
        /// Create an animated sprite of a copper asteroid
        /// which could be collected by the player for a score
        /// </summary>
        public void CreateAsteroid(GraphicsDevice graphics, Texture2D asteroidImage)
        {
            explosionEffect = SoundController.GetSoundEffect("Explosion");


            Sprite asteroid = new Sprite()
            {
                Image = asteroidImage,
                Position = new Vector2(1800,100),
                Direction = new Vector2(-1, 0),
                Speed = 100,
                Scale = 0.2f,
                Rotation = MathHelper.ToRadians(3),
                RotationSpeed = 2f,
            };

            Asteroids.Add(asteroid);
        }

        public void HasCollided(PlayerSprite player)
        {
            foreach (Sprite asteroid in Asteroids)
            {
                if (asteroid.HasCollided(player) && asteroid.IsAlive)
                {
                    explosionEffect.Play();

                    asteroid.IsActive = false;
                    asteroid.IsAlive = false;
                    asteroid.IsVisible = false;
                }
            }
        }

        public void Update(GameTime gameTime)
        {
            foreach (Sprite asteroid in Asteroids)
            {
                asteroid.Update(gameTime);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Sprite asteroid in Asteroids)
            {
                asteroid.Draw(spriteBatch);
            }
        }
    }

}

