using PerformanceDemo.Game_Core;
using PerformanceDemo.Utilities;
using PerformanceDemo.Particle_System;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using PerformanceDemo.Properties;

namespace PerformanceDemo.Game
{
    public class GameController
    {
        private const double GRAVITY = 0.05;
        private const double DAMPING = 0.8;
        private const double FIRE_SPEED = 5;
        private const int BALL_RADIUS = 10;
        private const int TURRET_MOVE_SPEED = 4;
        private const int TURRET_START_ANGLE =  45;
        private const int TURRET_START_LENGTH = 75;
        private const int TURRET_BASE_WIDTH = 50;
        private const int TURRET_BASE_HEIGHT = 50;
        private const int TURRET_WIDTH = 20;

        private GraphicalManager ballManager;
        private GraphicalManager stickFigureManager;
        private ParticleSystem particleSystem;
        private WorldParameters worldParameters;
        private Turret playerTurret;
        private int ballRadius;
        private Ball selectedBall;
        private Ball rightClickedBall;
        private Vector2 mouseLocation;
        private Vector2 selectedVector;
        private SoundPlayer blastSound;
        private GameSettings gameSettings;

        public GameController(Rectangle worldBoundary, GameSettings pGameSettings)
        {
            ballManager = new GraphicalManager();
            stickFigureManager = new GraphicalManager();
            ballManager.Destroyed += BallManager_Destroyed;

            particleSystem = new ParticleSystem();

            worldParameters = new WorldParameters(GRAVITY, DAMPING, worldBoundary);

            Vector2 startLocation = new Vector2(worldBoundary.X + worldBoundary.Width / 2, worldBoundary.Y + worldBoundary.Height - 25);
            playerTurret = new Turret(startLocation, TURRET_START_ANGLE, TURRET_START_LENGTH,
                TURRET_BASE_WIDTH, TURRET_BASE_HEIGHT, TURRET_WIDTH);

            ballRadius = BALL_RADIUS;

            blastSound = new SoundPlayer(Resources.Blast);

            gameSettings = pGameSettings;

            AllowThrow = true;
            RightArrowPressed = false;
            LeftArrowPressed = false;
            ShouldFire = false;
            Paused = false;
            selectedBall = null;
            rightClickedBall = null;
            mouseLocation = new Vector2(0, 0);
            selectedVector = new Vector2(0, 0);
        }

        private void BallManager_Destroyed(IGraphicalItem graphicalItem)
        {
            if (graphicalItem is StickFigure)
            {
                StickFigure curStickFigure = graphicalItem as StickFigure;
                EmitterSettings emitterSettings = new EmitterSettings();
                emitterSettings.Location = curStickFigure.Position;
                emitterSettings.ParticleColor = Color.White;
                emitterSettings.ParticleCount = 100;
                emitterSettings.ParticleLifeSpan = 100;
                emitterSettings.Radius = 10;
                emitterSettings.Immortal = gameSettings.ImmortalParticles;
                Random emitterRandom = new Random();
                emitterSettings.Velocity = new Vector2(emitterRandom.Next(-10, 10), emitterRandom.Next(-10, 10));
                particleSystem.Emit(emitterSettings);
                blastSound.Play();
            }
        }

        public Rectangle Boundary
        {
            set
            {
                worldParameters.Boundary = value;
            }
            get
            {
                return worldParameters.Boundary;
            }
        }

        public int BallCount => ballManager.Count;

        public int StickFigureCount => stickFigureManager.Count;

        public bool AllowThrow { set; get; }

        public bool ShouldFire { set; get; }

        public bool Paused { set; get; }

        public bool RightArrowPressed { set; get; }

        public bool LeftArrowPressed { set; get; }

        public void Update()
        {
            if (Paused)
            {
                return;
            }

            UpdateTurretPosition();
            playerTurret.Location.Y = Boundary.Y + Boundary.Height - playerTurret.BaseHeight / 2;
            selectedVector.X = mouseLocation.X;
            selectedVector.Y = mouseLocation.Y;

            if (ShouldFire)
            {
                FireTurret();
                ShouldFire = false;
            }

            stickFigureManager.Update(worldParameters);
            ballManager.Update(worldParameters);
            particleSystem.Update(worldParameters);
            CheckCollisions();
        }

        public void CheckCollisions()
        {
            ballManager.CheckCollisions(stickFigureManager);
        }

        private void UpdateTurretPosition()
        {
            int turretDirection = 0;
            if (RightArrowPressed && LeftArrowPressed)
            {
                turretDirection = 0;
            }
            else if (RightArrowPressed)
            {
                turretDirection = TURRET_MOVE_SPEED;
            }
            else if (LeftArrowPressed)
            {
                turretDirection = -TURRET_MOVE_SPEED;
            }

            int halfBaseWidth = TURRET_BASE_WIDTH / 2;
            double newTurretLocation = playerTurret.Location.X + turretDirection;
            if (newTurretLocation - halfBaseWidth >= 0 &&
                newTurretLocation + halfBaseWidth <= Boundary.Width)
            {
                playerTurret.Location.X = newTurretLocation;
            }
        }

        public void ClearAllBalls()
        {
            ballManager.Clear();
        }

        public void ClearAllStickFigures()
        {
            stickFigureManager.Clear();
        }

        public void RotateTurretTowards(int x, int y)
        {
            playerTurret.RotateTowards(x, y);
        }

        public void MouseMove(int mouseX, int mouseY)
        {
            if (Paused)
            {
                return;
            }

            mouseLocation.X = mouseX;
            mouseLocation.Y = mouseY;
            RotateTurretTowards(mouseX, mouseY);
            SnapSelectedBallToMouse(mouseX, mouseY);
        }

        public void SnapSelectedBallToMouse(int mouseX, int mouseY)
        {
            if (selectedBall != null)
            {
                selectedBall.Position.X = mouseX;
                selectedBall.Position.Y = mouseY;
                selectedBall.Velocity.X = 0;
                selectedBall.Velocity.Y = 0;
            }
        }

        public void LeftMouseDown(int mouseX, int mouseY)
        {
            if (Paused)
            {
                Paused = false;
                return;
            }

            mouseLocation.X = mouseX;
            mouseLocation.Y = mouseY;
            Ball foundBall = ballManager.FindItem(mouseLocation) as Ball;
            if (foundBall != null && AllowThrow)
            {
                selectedBall = foundBall;
                selectedBall.EnableGravity = false;
                selectedVector.X = mouseLocation.X;
                selectedVector.Y = mouseLocation.Y;
                SnapSelectedBallToMouse(mouseX, mouseY);
            }
            else
            {
                ShouldFire = true;
            }
        }

        public void LeftMouseUp(int mouseX, int mouseY)
        {
            mouseLocation.X = mouseX;
            mouseLocation.Y = mouseY;

            if (selectedBall != null)
            {
                Vector2 mouseDelta = mouseLocation - selectedVector;
                selectedBall.Velocity = mouseDelta.Normalized * 10;
                Console.WriteLine(selectedBall.Velocity.X.ToString() + "," + selectedBall.Velocity.Y.ToString());
                selectedBall.EnableGravity = true;
                selectedBall = null;
            }
            ShouldFire = false;
        }

        public bool RightMouseDown(int mouseX, int mouseY)
        {
            bool ballFound = false;

            Ball foundBall = ballManager.FindItem(new Vector2(mouseX, mouseY)) as Ball;
            if (foundBall != null)
            {
                rightClickedBall = foundBall;
                ballFound = true;
            }

            return ballFound;
        }

        public void DeleteRightClickBall()
        {
            if (rightClickedBall != null)
            {
                ballManager.RemoveItem(rightClickedBall);
                rightClickedBall = null;
            }
        }

        public void FireTurret()
        {
            double turretAngle = playerTurret.Angle;
            Vector2 ballVelocity = Vector2.FromAngleAndLength(turretAngle, FIRE_SPEED);

            if (gameSettings.Mode == GameMode.Normal)
            {
                Ball myBall = new Ball(ballRadius, playerTurret.EndLocation, ballVelocity);
                ballManager.AddItem(myBall);
            }
            else if (gameSettings.Mode == GameMode.Lion)
            {
                bool optimized = gameSettings.OptimizeGraphics;
                LionBall lionBall = new LionBall(ballRadius, playerTurret.EndLocation, ballVelocity, optimized);
                ballManager.AddItem(lionBall);
            }
        }

        public void AddStickFigure(int x, int y)
        {
            StickFigure figure = new StickFigure(new Vector2(x, y), new Vector2(0, 0), 25, 50, 0.4);
            stickFigureManager.AddItem(figure);
        }

        public void Draw(Graphics graphics)
        {
            ballManager.Draw(graphics);
            stickFigureManager.Draw(graphics);
            playerTurret.Draw(graphics);
            particleSystem.Draw(graphics);
        }
    }
}
