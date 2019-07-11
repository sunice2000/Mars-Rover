using System;
using MarsRover;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MissionMarsTest
{

    [TestClass]
    public class UnitTest1
    {
        //Test Method checks if Rovers are Colliding
        [TestMethod]
        public void TestMethod1()
        {
            Program.Rover rover;
            rover.x = 1;
            rover.y = 1;
            rover.direction = 'N';
            Program.Rover rover2;
            rover2.x = 1;
            rover2.y = 1;
            rover2.direction = 'S';
            Program.Rover rover3;
            rover3.x = 1;
            rover3.y = 0;
            rover3.direction = 'S';

            Assert.IsTrue(Program.Collision(rover, rover2));
            Assert.IsFalse(Program.Collision(rover3, rover2));

        }
        //Test Method checks if directional methods work correctly
        [TestMethod]
        public void TestMethod2()
        {
            Program.Rover rover;
            rover.x = 1;
            rover.y = 1;
            rover.direction = 'N';
            Program.Rover rover2;
            rover2.x = 1;
            rover2.y = 1;
            rover2.direction = 'S';
            Program.Left(ref rover);
            Program.Right(ref rover2);
            Assert.AreEqual(rover.direction, rover2.direction);
        }
        //Test Method checks if rover can move, and when it can't move (off board or into other rover)
        [TestMethod]
        public void TestMethod3()
        {
            Program.Rover rover;
            rover.x = 1;
            rover.y = 1;
            rover.direction = 'N';
            Program.Rover rover2;
            rover2.x = 0;
            rover2.y = 0;
            rover2.direction = 'S';
            int[] board = { 2, 2 };
            Program.Rover rover3;
            rover3.x = 1;
            rover3.y = 0;
            rover3.direction = 'W';
            
            //Rover-One moves up succssfully
            Assert.IsTrue(Program.Forward(board, ref rover, rover2));
            //Rover-Two cannot move off the board
            Assert.IsFalse (Program.Forward(board, ref rover2, rover));
            //Rover-Three cannot move onto Rover-Two
            Assert.IsFalse(Program.Forward(board, ref rover3, rover2));
        }
        //This Method doubles for testing both overloading Validate Functions which take 3 arguments
        //checks for empty string, not enough arguments, negative coordinates, wrong letters used, and letters in wrong place
        [TestMethod]
        public void TestMethod4()
        {
            Program.Rover rover;
            rover.x = 1;
            rover.y = 1;
            rover.direction = 'N';
            int[] board = { 2, 2 };
            string[] str = { };
            string[] str1 = { "1", "2" };
            string[] str2 = { "1", "-2", "N" };
            string[] str3 = { "1", "2", "A" };
            string[] str4 = { "n", "2", "1" };
            string[] str5 = { "1", "2", "n" };
            int i = 0;

            Assert.IsFalse(Program.Validate(board, str, ref rover));
            Assert.IsFalse(Program.Validate(board, str1, ref rover));
            Assert.IsFalse(Program.Validate(board, str2, ref rover));
            Assert.IsFalse(Program.Validate(board, str3, ref rover));
            Assert.IsFalse(Program.Validate(board, str4, ref rover));
            Assert.IsTrue(Program.Validate(board, str5, ref rover));
        }
        //Test Method checks for valid and invalid entries to the Validate method which takes only characters 'L', 'M' or 'R'
        [TestMethod]
        public void TestMethod5()
        {
            Program.Rover rover;
            rover.x = 1;
            rover.y = 1;
            rover.direction = 'N';
            int[] board = { 2, 2 };
            char[] str = { };
            char[] str1 = { 'L', 'A' };
            char[] str2 = { '1', 'M', 'R' };
            char[] str3 = { 'L', 'M', 'R' };

            //Assert.IsFalse(Program.Validate(str)); // Still to Fix
            Assert.IsFalse(Program.Validate(str1));
            Assert.IsFalse(Program.Validate(str2));
            Assert.IsTrue(Program.Validate(str3));
        }
        [TestMethod]
        public void TestMethod_Original()
        {
            Program.Rover rover, rover2;
            rover.x = 1;
            rover.y = 2;
            rover.direction = 'N';
            rover2.x = 3;
            rover2.y = 3;
            rover2.direction = 'E';
            int[] board = { 5, 5 };
            string temp = "LMLMLMLMM";
            char[] move1 = temp.ToCharArray();
            temp = "MMRMMRMRRM";
            char[] move2 = temp.ToCharArray();
            Program.Move(board, ref rover, ref rover2, move1);
            Program.Move(board, ref rover2, ref rover, move2);
            Assert.AreEqual(rover.x, 1);
            Assert.AreEqual(rover.y, 3);
            Assert.AreEqual(rover.direction, 'N');
            Assert.AreEqual(rover2.x, 5);
            Assert.AreEqual(rover2.y, 1);
            Assert.AreEqual(rover2.direction, 'E');
        }

    }
}
