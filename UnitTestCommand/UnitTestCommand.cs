using Microsoft.VisualStudio.TestTools.UnitTesting;
using CommandFollowAlong;
using CommandFollowAlong.Commands;
using CommandFollowAlong.CommandPattern;

namespace UnitTestCommand
{
    [TestClass]
    public class UnitTestCommand
    {
        GameComponent fakeGameComponent;

        public UnitTestCommand()
        {
            fakeGameComponent = new GameComponent();
        }

        [TestMethod]
        public void TestCommandMoveUp()
        {
            // Arrange
            int originalLocationY = fakeGameComponent.Y;
            Command moveUp = new MoveUpCommand();
            int finalLocaionY;
            int expectedMoveAmount = 1;

            // Act
            moveUp.Execute(fakeGameComponent);
            finalLocaionY = fakeGameComponent.Y;

            // Assert
            Assert.AreEqual(finalLocaionY, originalLocationY + expectedMoveAmount);
        }

        [TestMethod]
        public void TestCommandMoveDown()
        {
            // Arrange
            int originalLocationY = fakeGameComponent.Y;
            Command moveDown = new MoveDownCommand();
            int finalLocaionY;
            int expectedMoveAmount = -1;

            // Act
            moveDown.Execute(fakeGameComponent);
            finalLocaionY = fakeGameComponent.Y;

            // Assert
            Assert.AreEqual(finalLocaionY, originalLocationY + expectedMoveAmount);
        }

        [TestMethod]
        public void TestCommandMoveRight()
        {
            // Arrange
            int originalLocationX = fakeGameComponent.X;
            Command moveRight = new MoveRightCommand();
            int finalLocaionX;
            int expectedMoveAmount = 1;

            // Act
            moveRight.Execute(fakeGameComponent);
            finalLocaionX = fakeGameComponent.X;

            // Assert
            Assert.AreEqual(finalLocaionX, originalLocationX + expectedMoveAmount);
        }

        [TestMethod]
        public void TestCommandMoveLeft()
        {
            // Arrange
            int originalLocationX = fakeGameComponent.X;
            Command moveLeft = new MoveLeftCommand();
            int finalLocaionX;
            int expectedMoveAmount = -1;

            // Act
            moveLeft.Execute(fakeGameComponent);
            finalLocaionX = fakeGameComponent.X;

            // Assert
            Assert.AreEqual(finalLocaionX, originalLocationX + expectedMoveAmount);
        }
    }
}
