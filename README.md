# Mars-Rover
# Created by Crystal Richards

Objective: obtaining user input and translating it into commands. 

   Purpose: To Explore Mars by systematically taking photographs of a plateau using two rovers 
   The Applicaiton allows a driver to control the movements of two rovers by giving the system
   the location of the rovers and the movements to be made
   The driver is also responsible for telling the computer the size of the plateau by giving it
   the coordinates of the North Eastern most point on the graph
   The computer accepts two numbers separated by spaces for the coordinates and the letters
   N S E or W for directions along with L or R or M for movements.
   All together the user will need to type in at least 5 lines of commands to pilot the rovers:
   1) Size of plateau (giving coordinates of the top-rightmost coordinate < x y > 
   2) Location and Direction of the first Rover < x y d > 
   3) Movments of the first Rover (any number of L's R's and M's) <LRM>
   4) Location and Direction of the second Rover < x y d > 
   5) Movments of the second Rover (any number of L's R's and M's) <LRM>
   
   Key:
   N/S/E/W stands for the direction in which the rover is facing: North, South, East, or West and
   L/R/M stands for the rovers movements of left, right, or forward respectively
   
   
   
   
# Introduction 
This is a quick list of requirements for an application we would like you to write in C#.  The application 
should work and provide unit tests that pass.  The application should accept input from a file; you can 
define the file format.  The application can be a console or GUI application. 
# Code Test: Mars Rover
A squad of robotic rovers are to be landed by NASA on a plateau on Mars. This plateau, which is 
curiously rectangular, must be navigated by the rovers so that their on-board cameras can get a 
complete view of the surrounding terrain to send back to Earth. 
A rover's position and location is represented by a combination of x and y co-ordinates and a letter 
representing one of the four cardinal compass points. The plateau is divided up into a grid to simplify 
navigation. An example position might be 0, 0, N, which means the rover is in the bottom 
left corner and facing North. 
In order to control a rover, NASA sends a simple string of letters. The possible letters are 'L', 'R' and 'M'. 
'L' and 'R' makes the rover spin 90 degrees left or right respectively, without moving from its current 
spot. 'M' means move forward one grid point, and maintains the same heading. 
You can assume that the square directly North from (x, y) is (x, y+1). 
# Input
The first line of input is the upper-right coordinates of the plateau, the lower-left coordinates are 
assumed to be 0, 0. 
The rest of the input is information pertaining to the rovers that have been deployed. Each rover has 
two lines of input. The first line gives the rover's position, and the second line is a series of instructions 
telling the rover how to explore the plateau. 
The position is made up of two integers and a letter separated by spaces, corresponding to the x and y 
co-ordinates and the rover's orientation. 
Each rover will be finished sequentially, which means that the second rover won't start to move until the 
first one has finished moving. 
# Output 
The output for each rover should be its final co-ordinates and heading. 
