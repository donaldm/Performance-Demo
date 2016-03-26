using PerformanceDemo.Game_Core;
using PerformanceDemo.Renderers;
using PerformanceDemo.Utilities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace PerformanceDemo.Game
{
    class GameController
    {
        private const double GRAVITY = 0.05;
        private const double DAMPING = 0.8;
        private const double FIRE_SPEED = 5;
        private const int BALL_RADIUS = 10;
        private const int TURRET_MOVE_SPEED = 4;
        private const int TURRET_START_ANGLE = 45;
        private const int TURRET_START_LENGTH = 75;
        private const int TURRET_BASE_WIDTH = 50;
        private const int TURRET_BASE_HEIGHT = 50;
        private const int TURRET_WIDTH = 20;

        private BallManager ballManager;
        private StickFigureManager stickFigureManager;
        private WorldParameters worldParameters;
        private Turret playerTurret;
        private int ballRadius;
        private bool allowThrow;
        private bool rightArrowPressed;
        private bool leftArrowPressed;
        private bool shouldFire;
        private bool paused;
        private Ball selectedBall;
        private Ball rightClickedBall;
        private Vector2 mouseLocation;
        private Vector2 selectedVector;

        public GameController(Rectangle worldBoundary)
        {
            ballManager = new BallManager(worldBoundary);
            stickFigureManager = new StickFigureManager(worldBoundary);

            worldParameters = new WorldParameters(GRAVITY, DAMPING);

            Vector2 startLocation = new Vector2(worldBoundary.X + worldBoundary.Width / 2, worldBoundary.Y + worldBoundary.Height - 25);
            playerTurret = new Turret(startLocation, TURRET_START_ANGLE, TURRET_START_LENGTH,
                TURRET_BASE_WIDTH, TURRET_BASE_HEIGHT, TURRET_WIDTH);

            ballRadius = BALL_RADIUS;

            allowThrow = true;
            rightArrowPressed = false;
            leftArrowPressed = false;
            shouldFire = false;
            paused = false;
            selectedBall = null;
            rightClickedBall = null;
            mouseLocation = new Vector2(0, 0);
            selectedVector = new Vector2(0, 0);
        }

        public Rectangle Boundary
        {
            set
            {
                ballManager.Boundary = value;
                stickFigureManager.Boundary = value;
            }
            get
            {
                return ballManager.Boundary;
            }
        }

        public int BallCount
        {
            get
            {
                return ballManager.Count;
            }
        }

        public bool AllowThrow
        {
            set
            {
                allowThrow = value;
            }
            
            get
            {
                return allowThrow;
            }
        }

        public bool ShouldFire
        {
            set
            {
                shouldFire = value;
            }

            get
            {
                return shouldFire;
            }
        }

        public bool Paused
        {
            set
            {
                paused = value;
            }

            get
            {
                return paused;
            }
        }

        public bool RightArrowPressed
        {
            set
            {
                rightArrowPressed = value;
            }

            get
            {
                return rightArrowPressed;
            }
        }

        public bool LeftArrowPressed
        {
            set
            {
                leftArrowPressed = value;
            }

            get
            {
                return leftArrowPressed;
            }
        }

        public void Update()
        {
            if (paused)
            {
                return;
            }

            UpdateTurretPosition();
            playerTurret.Location.Y = Boundary.Y + Boundary.Height - playerTurret.BaseHeight / 2;
            selectedVector.X = mouseLocation.X;
            selectedVector.Y = mouseLocation.Y;

            if (shouldFire)
            {
                FireTurret();
                shouldFire = false;
            }

            stickFigureManager.Update(worldParameters);
            ballManager.Update(worldParameters);
            CheckCollisions();
        }

        public void CheckCollisions()
        {
            List<Ball> ballsToDestroy = new List<Ball>();
            List<StickFigure> stickFiguresToDestroy = new List<StickFigure>();

            foreach(Ball curBall in ballManager.Balls)
            {
                Rectangle ballRect = curBall.CalculateBoundingBox();
                foreach(StickFigure stickFigure in stickFigureManager.StickFigures)
                {
                    Rectangle stickRect = stickFigure.CalculateBoundingBox();

                    if (ballRect.IntersectsWith(stickRect))
                    {
                        ballsToDestroy.Add(curBall);
                        stickFiguresToDestroy.Add(stickFigure);
                    }
                }
            }

            DestroyBalls(ballsToDestroy);
            DestroyStickFigures(stickFiguresToDestroy);
        }

        public void DestroyBalls(List<Ball> balls)
        {
            foreach(Ball curBall in balls)
            {
                ballManager.RemoveBall(curBall);
            }
        }

        public void DestroyStickFigures(List<StickFigure> stickFigures)
        {
            foreach(StickFigure stickFigure in stickFigures)
            {
                stickFigureManager.RemoveStickFigure(stickFigure);
            }
        }

        private void UpdateTurretPosition()
        {
            int turretDirection = 0;
            if (rightArrowPressed && leftArrowPressed)
            {
                turretDirection = 0;
            }
            else if (rightArrowPressed)
            {
                turretDirection = TURRET_MOVE_SPEED;
            }
            else if (leftArrowPressed)
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

        public void RotateTurretTowards(int x, int y)
        {
            playerTurret.RotateTowards(x, y);
        }

        public void MouseMove(int mouseX, int mouseY)
        {
            if (paused)
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
            if (paused)
            {
                paused = false;
                return;
            }

            mouseLocation.X = mouseX;
            mouseLocation.Y = mouseY;
            Ball foundBall = ballManager.FindBall(mouseLocation);
            if (foundBall != null && allowThrow)
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

            Ball foundBall = ballManager.FindBall(new Vector2(mouseX, mouseY));
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
                ballManager.RemoveBall(rightClickedBall);
                rightClickedBall = null;
            }
        }

        public void FireTurret()
        {
            double turretAngle = playerTurret.Angle;
            Vector2 ballVelocity = Vector2.FromAngleAndLength(turretAngle, FIRE_SPEED);

            Ball myBall = new Ball(ballRadius, playerTurret.EndLocation, ballVelocity);
            ballManager.AddBall(myBall);
        }

        public void AddStickFigure(int x, int y)
        {
            StickFigure figure = new StickFigure(new Vector2(x, y), new Vector2(0, 0), 25, 50, 10);
            stickFigureManager.AddStickFigure(figure);
        }

        public void Draw(Graphics graphics)
        {
            ballManager.Draw(graphics);
            stickFigureManager.Draw(graphics);
            TurretRenderer turretRenderer = new TurretRenderer(playerTurret);
            turretRenderer.Draw(graphics);
        }
    }
}
