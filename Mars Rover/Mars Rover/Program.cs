using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*  
 *  Mars Rover Application
 *  Created by Crystal Richards
 *  Purpose: To Explore Mars by systematically taking photographs of a plateau using two rovers 
 *  The Applicaiton allows a driver to control the movements of two rovers by giving the system
 *  the location of the rovers and the movements to be made
 *  The driver is also responsible for telling the computer the size of the plateau by giving it
 *  the coordinates of the North Eastern most point on the graph
 *  The computer accepts two numbers separated by spaces for the coordinates and the letters
 *  N S E or W for directions along with L or R or M for movements.
 *  All together the user will need to type in at least 5 lines of commands to pilot the rovers:
 *  1) Size of plateau (giving coordinates of the top-rightmost coordinate < x y > 
 *  2) Location and Direction of the first Rover < x y d > 
 *  3) Movments of the first Rover (any number of L's R's and M's) <LRM>
 *  4) Location and Direction of the second Rover < x y d > 
 *  5) Movments of the second Rover (any number of L's R's and M's) <LRM>
 *  
 *  Key:
 *  N/S/E/W stands for the direction in which the rover is facing: North, South, East, or West and
 *  L/R/M stands for the rovers movements of left, right, or forward respectively
 */

namespace Mars_Rover
{
    
    class Program
    {
        //Struct containing the coordinates and direction of a rover
        public struct Rover
        {
            public int x;
            public int y;
            public char direction;
        }
        static void Main(string[] args)
        {
            //Initialize two rovers: Sending to Mars
            Rover rover1 = new Rover();
            Rover rover2 = new Rover();
            //Prompt user for size of plateau to begin
            Console.WriteLine("Welcome Explorer. Please enter the size of the plateau field. <x y>");
            int[] plateau = { -1, -1 };
            bool valid = false;
            int i;
            //refresh input until user provides valid coordinates for plateau
            while (!valid)
            {
                string[] temp = Console.ReadLine().Split(' ', ',');
                i = 0;
                if (!Validate(ref plateau, ref i, temp))
                {
                    Console.WriteLine("Oops, the coordinates you entered aren't quite right. Please re-enter the coordinates.");
                    //j = 0;
                }
                else
                {
                    Console.WriteLine("The coordinates you entered were {0},{1}", plateau[0], plateau[1]);
                    valid = true;
                }
            }
            /******************************************************************************************************************/
            //Rover 1 Commands
            Console.WriteLine("Please enter the location of Rover-One and its direction. <x y N/S/E/W>");
            string[] loc = Console.ReadLine().Split(' ', ',');
            while (!Validate(plateau, loc, rover1))
            {
                Console.WriteLine("Please ensure your are entering valid coordinates in the form <x y d>");
                loc = Console.ReadLine().Split(' ', ',');
            }
            Console.WriteLine("Please enter the list of movements you would like Rover-One to make using only these letters L/R/M");
            char[] rover1Move = Console.ReadLine().ToUpper().ToCharArray();
            while (!Validate(rover1Move))
            {
                Console.WriteLine("Please ensure you are entering only values L/R/M");
                rover1Move = Console.ReadLine().ToUpper().ToCharArray();
            }
            /******************************************************************************************************************/
            //Rover 2 Commands
            Console.WriteLine("Please enter the location of Rover-One and its direction. <x y N/S/E/W>");
            loc = Console.ReadLine().Split(' ', ',');
            while (!Validate(plateau, loc, rover2))
            {
                Console.WriteLine("Please ensure your are entering valid coordinates in the form <x y d>");
                loc = Console.ReadLine().Split(' ', ',');
            }
            Console.WriteLine("Please enter the list of movements you would like Rover-One to make using only these letters L/R/M");
            char[] rover2Move = Console.ReadLine().ToUpper().ToCharArray();
            while (!Validate(rover2Move))
            {
                Console.WriteLine("Please ensure you are entering only values L/R/M");
                rover2Move = Console.ReadLine().ToUpper().ToCharArray();
            }
            /******************************************************************************************************************/
            //Time for Movement Checks
            Move(plateau, rover1, rover2, rover1Move);
            Move(plateau, rover2, rover1, rover2Move);
            Console.WriteLine("Rovers have completed their mission. Rover-One has stopped at ({0},{1}) facing {2}, and Rover-Two has stopped at ({3},{4}) facing {5}.", rover1.x, rover1.y, rover1.direction, rover2.x, rover2.y, rover2.direction);
            Console.ReadKey();
        }
        /**************************************************************************************************************************/
        //Methods
        public static bool Validate(char[] movements)
        {
            for (int i = 0; i < movements.Length; i++)
            {
                if (movements[i] != 'L' && movements[i] != 'R' && movements[i] != 'M')
                    return false;
            }
            return true;
        }
        //Method for validating user input and the location of the rover
        public static bool Validate(int[] board, string[] loc, Rover rover)
        {
            int i = 0;
            int[] roverCoord = { -1, -1 };
            if (Validate(ref roverCoord, ref i, loc))
            {
                //eliminate all empty space from user, check if they entered a direction after leading spaces
                while (i <= loc.Length - 1)
                {
                    if (loc[i] != "")
                    {
                        break;
                    }
                    else
                        i++;
                }
                //Check: If no more elements are in the array, user did not enter a direction   
                if (i > loc.Length - 1)
                {
                    Console.WriteLine("Oops, you didn't enter a direction.");
                    return false;
                }
                //Check if direction is valid
                loc[i] = loc[i].ToUpper();
                if (loc[i] == "N" || loc[i] == "S" || loc[i] == "E" || loc[i] == "W")
                {
                    //check if rover is on the plateau
                    if (roverCoord[0] <= board[0] && roverCoord[1] <= board[1])
                    {
                        rover.x = roverCoord[0];
                        rover.y = roverCoord[1];
                        rover.direction = loc[i][0];
                        return true;
                    }
                    else
                        Console.WriteLine("Oops, your rover is not on the plateau. Please check your rover is within the bounds (0,0) , ({0},{1}).", board[0], board[1]);
                }
                else
                    Console.WriteLine("Oops, your direction doesnt seem right. Ensure you are using the letters N, S, E, or W.");
            }
            Console.WriteLine("The values you entered are {0} {1} {2}", roverCoord[0], roverCoord[1], loc[i]);
            return false;
        }
        //Method to validate user input and ensure it contains coordinates
        public static bool Validate(ref int[] coord, ref int i, string[] userInput)
        {
            int j = 0;
            //check that the first two values typed in are numbers
            for (i = 0; i < userInput.Length; i++)
            {
                if (Int32.TryParse(userInput[i], out int num))
                {
                    if(num < 0)
                    {
                        Console.WriteLine("Oops, Coordinates cannot be negative.");
                        break;
                    }
                    coord[j] = num;
                    if (++j == 2)
                        break;
                }
                //due to splitting we must check for empty spaces in the array
                else if (userInput[i] != "")
                    break;
            }
            //set to next array element for rover
            i++;
            if (coord[1] == -1)
                return false;
            else
                return true;
        }
        //Method for validating the movement and moving a rover
        public static bool Move(int[] board, Rover rover, Rover rover2, char[] movements)
        {
            for (int i = 0; i < movements.Length; i++)
            {
                if (movements[i] == 'L')
                    Left(rover);
                else if (movements[i] == 'R')
                    Right(rover);
                else
                {
                    if (!Forward(board, rover, rover2))
                    {
                        Console.WriteLine("Unable to complete command, rover stopped at location {0},{1} facing {2}", rover.x, rover.y, rover.direction);
                        return false;
                    }
                }
            }
            return false;
        }
        //Method for changing a rover's direction Counter-Clockwise
        public static void Left(Rover rover)
        {

        }
        //Method for changing a rover's direction Clockwise
        public static void Right(Rover rover)
        {

        }
        //Method for moving a rover forward one space (if valid, check for collisions and out of bounds)
        public static bool Forward(int[] board, Rover rover, Rover rover2)
        {
            return false;
        }
    }
}
