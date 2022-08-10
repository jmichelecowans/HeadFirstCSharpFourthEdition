using HideAndSeek;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace HideAndSeekTests
{
    [TestClass]
    public class GameControllerTests
    {
        GameController _gameController;

        [TestInitialize]
        public void Initialize()
        {
            _gameController = new GameController();
        }

        [TestMethod]
        public void TestMovement()
        {
            Assert.AreEqual("Entry", _gameController.CurrentLocation.Name);
            Assert.IsFalse(_gameController.Move(Direction.Up));
            Assert.AreEqual("Entry", _gameController.CurrentLocation.Name);
            Assert.IsTrue(_gameController.Move(Direction.East));
            Assert.AreEqual("Hallway", _gameController.CurrentLocation.Name);
            Assert.IsTrue(_gameController.Move(Direction.Up));
            Assert.AreEqual("Landing", _gameController.CurrentLocation.Name);
            Assert.IsFalse(_gameController.Move(Direction.In));
            Assert.AreNotEqual("Pantry", _gameController.CurrentLocation.Name);
        }

        [TestMethod]
        public void TestParseInput()
        {
            var initialStatus = _gameController.Status;
            Assert.AreEqual("That's not a valid direction", _gameController.ParseInput("X"));
            Assert.AreEqual(initialStatus, _gameController.Status);
            Assert.AreEqual("There's no exit in that direction", _gameController.ParseInput("Up"));
            Assert.AreEqual(initialStatus, _gameController.Status);
            Assert.AreEqual("Moving East", _gameController.ParseInput("East"));
            Assert.AreEqual("You are in the Hallway. You see the following exits:"
                + Environment.NewLine + " - the Bathroom is to the North"
                + Environment.NewLine + " - the Living Room is to the South"
                + Environment.NewLine + " - the Entry is to the West"
                + Environment.NewLine + " - the Kitchen is to the Northwest"
                + Environment.NewLine + " - the Landing is Up"
                + Environment.NewLine + "You have not found any opponents", _gameController.Status);
            Assert.AreEqual("Moving South", _gameController.ParseInput("South"));
            Assert.AreEqual("You are in the Living Room. You see the following exits:"
                + Environment.NewLine + " - the Hallway is to the North"
                + Environment.NewLine + "Someone could hide behind the curtain"
                + Environment.NewLine + "You have not found any opponents", _gameController.Status);
            Assert.AreEqual("Moving North", _gameController.ParseInput(Environment.NewLine + "\t   NoRTh    "));
        }

        [TestMethod]
        public void TestParseCheck()
        {
            Assert.IsFalse(_gameController.GameOver);

            // Clear the hiding places and hide the opponents in specific rooms
            House.ClearHidingPlaces();
            var joe = _gameController.Opponents.ToList()[0];
            (House.GetLocationByName("Garage") as LocationWithHidingPlace).Hide(joe);
            var bob = _gameController.Opponents.ToList()[1];
            (House.GetLocationByName("Kitchen") as LocationWithHidingPlace).Hide(bob);
            var ana = _gameController.Opponents.ToList()[2];
            (House.GetLocationByName("Attic") as LocationWithHidingPlace).Hide(ana);
            var owen = _gameController.Opponents.ToList()[3];
            (House.GetLocationByName("Attic") as LocationWithHidingPlace).Hide(owen);
            var jimmy = _gameController.Opponents.ToList()[4];
            (House.GetLocationByName("Kitchen") as LocationWithHidingPlace).Hide(jimmy);

            // Check the Entry -- there are no players hiding there
            Assert.AreEqual(1, _gameController.MoveNumber);
            Assert.AreEqual("There is no hiding place in the Entry", _gameController.ParseInput("Check"));
            Assert.AreEqual(2, _gameController.MoveNumber);

            // Move to the Garage
            _gameController.ParseInput("Out");
            Assert.AreEqual(3, _gameController.MoveNumber);

            // We hid Joe in the Garage, so validate ParseInput's return value and the properties
            Assert.AreEqual("You found 1 opponent hiding behind the car", _gameController.ParseInput("check"));
            Assert.AreEqual("You are in the Garage. You see the following exits:"
                + Environment.NewLine + " - the Entry is In"
                + Environment.NewLine + "Someone could hide behind the car"
                + Environment.NewLine + "You have found 1 of 5 opponents: Joe", _gameController.Status);
            Assert.AreEqual("4: Which direction do you want to go (or type 'check'): ", _gameController.Prompt);
            Assert.AreEqual(4, _gameController.MoveNumber);

            // Move to the bathroom, where nobody is hiding
            _gameController.ParseInput("In");
            _gameController.ParseInput("East");
            _gameController.ParseInput("North");

            // Check the Bathroom to make sure nobody is hiding there
            Assert.AreEqual("Nobody was hiding behind the door", _gameController.ParseInput("check"));
            Assert.AreEqual(8, _gameController.MoveNumber);

            // Check the Bathroom to make sure nobody is hiding there
            _gameController.ParseInput("South");
            _gameController.ParseInput("Northwest");
            Assert.AreEqual("You found 2 opponents hiding next to the stove", _gameController.ParseInput("check"));
            Assert.AreEqual("You are in the Kitchen. You see the following exits:"
                + Environment.NewLine + " - the Hallway is to the Southeast"
                + Environment.NewLine + "Someone could hide next to the stove"
                + Environment.NewLine + "You have found 3 of 5 opponents: Joe, Bob, Jimmy", _gameController.Status);
            Assert.AreEqual("11: Which direction do you want to go (or type 'check'): ", _gameController.Prompt);
            Assert.AreEqual(11, _gameController.MoveNumber);
            Assert.IsFalse(_gameController.GameOver);

            // Head up to the Landing, then check the Pantry (nobody's hiding there)
            _gameController.ParseInput("Southeast");
            _gameController.ParseInput("Up");
            Assert.AreEqual(13, _gameController.MoveNumber);
            _gameController.ParseInput("South");
            Assert.AreEqual("Nobody was hiding inside a cabinet", _gameController.ParseInput("check"));
            Assert.AreEqual(15, _gameController.MoveNumber);
            // Check the Attic to find the last two opponents, make sure the game is over
            _gameController.ParseInput("North");
            _gameController.ParseInput("Up");
            Assert.AreEqual(17, _gameController.MoveNumber);
            Assert.AreEqual("You found 2 opponents hiding in a trunk", _gameController.ParseInput("check"));
            Assert.AreEqual("You are in the Attic. You see the following exits:"
                + Environment.NewLine + " - the Landing is Down"
                + Environment.NewLine + "Someone could hide in a trunk"
                + Environment.NewLine + "You have found 5 of 5 opponents: Joe, Bob, Jimmy, Ana, Owen", _gameController.Status);
            Assert.AreEqual("18: Which direction do you want to go (or type 'check'): ", _gameController.Prompt);
            Assert.AreEqual(18, _gameController.MoveNumber);
            Assert.IsTrue(_gameController.GameOver);
        }
    }
}