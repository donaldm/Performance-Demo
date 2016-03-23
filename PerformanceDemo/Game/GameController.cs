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
 
        private GraphicalBallManager graphicalBallManager;
        private WorldParameters worldParameters;
        private Turret playerTurret;
        private int ballRadius;
        private bool rightArrowPressed;
        private bool leftArrowPressed;
        private bool shouldFire;
        private Ball selectedBall;
        private Vector2 mouseLocation;
        private Vector2 selectedVector;

        public GameController(Rectangle worldBoundary)
        {
            graphicalBallManager = new GraphicalBallManager(worldBoundary);
            worldParameters = new WorldParameters(GRAVITY, DAMPING);

            Vector2 startLocation = new Vector2(worldBoundary.X + worldBoundary.Width / 2, worldBoundary.Y + worldBoundary.Height - 25);
            playerTurret = new Turret(startLocation, TURRET_START_ANGLE, TURRET_START_LENGTH, 
                TURRET_BASE_WIDTH, TURRET_BASE_HEIGHT, TURRET_WIDTH);

            ballRadius = BALL_RADIUS;

            rightArrowPressed = false;
            leftArrowPressed = false;
            shouldFire = false;
            selectedBall = null;
            mouseLocation = new Vector2(0, 0);
            selectedVector = new Vector2(0, 0);
        }

        public Rectangle Boundary
        {
            set
            {
                graphicalBallManager.Boundary = value;
            }
            get
            {
                return graphicalBallManager.Boundary;
            }
        }

        public int BallCount
        {
            get
            {
                return graphicalBallManager.Count;
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
            UpdateTurretPosition();
            playerTurret.Location.Y = Boundary.Y + Boundary.Height - playerTurret.BaseHeight / 2;
            selectedVector.X = mouseLocation.X;
            selectedVector.Y = mouseLocation.Y;

            if ( shouldFire )
            {
                FireTurret();
                shouldFire = false;
            }

            graphicalBallManager.Update(worldParameters);
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

            playerTurret.Location.X += turretDirection;
        }

        public void ClearAllBalls()
        {
            graphicalBallManager.Clear();
        }

        public void RotateTurretTowards(int x, int y)
        {
            playerTurret.RotateTowards(x, y);
        }

        public void MouseMove(int mouseX, int mouseY)
        {
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
            mouseLocation.X = mouseX;
            mouseLocation.Y = mouseY;
            Ball foundBall = graphicalBallManager.FindBall(mouseLocation);
            if (foundBall != null)
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

        public void FireTurret()
        {
            double turretAngle = playerTurret.Angle;
            Vector2 ballVelocity = Vector2.FromAngleAndLength(turretAngle, FIRE_SPEED);

            Ball myBall = new Ball(ballRadius, playerTurret.EndLocation, ballVelocity);
            graphicalBallManager.AddBall(myBall);
        }

        public void Draw(Graphics graphics)
        {
            graphicalBallManager.Draw(graphics);
            TurretRenderer turretRenderer = new TurretRenderer(playerTurret);
            turretRenderer.Draw(graphics);
        }
    }
}
