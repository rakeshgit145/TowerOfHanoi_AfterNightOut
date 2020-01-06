# Tower of Hanoi - after a night out!

This is a console application & has been created in .Net Core 2.0. It's Unit Test Project is created using MS Test. 

#### Reference for the question:-

Below is the reference for the question.
[Indorse - Tower of Hanoi After a NightOut](https://indorse.io/assignments/5ce909ccc5e3380001ed8b3e)

### About the Problem

The Tower of Hanoi (commonly also known as the **Towers of Hanoi(ToH)**), is a puzzle invented by E. Lucas in 1883. It is also known as the Tower of Brahma puzzle and appeared as an intelligence test as per Vedic Indian Culture.

The time to compute number of moves for any "n" number of disk increases exponentially & the worst case time complexity for recursive algorithm for this problem is <img src="https://latex.codecogs.com/svg.latex?\large&space;O(2^n)" title="\large O(2^n)" />.

We all know that mathematical formula to take out the number of moves for ToH are:-

Recursive Mathematical formula is:-

<img src="https://latex.codecogs.com/svg.latex?\large&space;T_n&space;=&space;2T_{n-1}&space;&plus;1" title="\large T_n = 2T_{n-1} +1" />

and the General formula proved by Mathematical Induction is:-

<img src="https://latex.codecogs.com/svg.latex?\large&space;T_n=&space;2^n-1" title="\large T_n= 2^n-1" />

### Example to Illustrate Complexity

Illustrating the problem with using the recursive approach to solve this problem is that it becomes extremely expensive to compute as the number of disk increases.

For example:- Let say that n=64, then let see how much time a computer would take to compute the number of moves for the same.
Let's suppose that, present day computers can perform a single calculation in microSeconds, then,

According to the general formula of ToH, number of moves for n=64 is:

<img src="https://latex.codecogs.com/svg.latex?\large&space;Number&space;of&space;Moves&space;=&space;2^{64}&space;-1=&space;18446744073709551615" title="\large Number of Moves = 2^{64} -1= 18446744073709551615" />

if, the compute time of today's CPU is in microseconds for executing single instruction then also, 

**18446744073709551615 seconds ≃ 584942417355.072 years**
both divides by <img src="https://latex.codecogs.com/svg.latex?\large&space;10^6" title="\large 10^6" /> would give,
**18446744073709.551615 seconds ≃ 584942.417355072 years**

Even to compute the number of moves for n = 64, this approach is computationally so expensive that computing only a single value of n = 64, it would take nearly 585 thousands of year on any average computer at present.

So computing this using reccursive algorithm is not even feasible for even 1 value of large disk count. Computing the same for sum of all values in range of (1-10000) is not feasible.
This Problem lies in that set of computational problems which is only feasible with infinite time & Infinite resource(Memory).

### Alternative approach with respect to this Problem

Many people have published algorithms for solving towers of Hanoi game move by move. However, solving a Tower of Hanoi game with 64 disks move by move needs a long time and so one might want a solution for skipping a few billion moves. In order to do so, one just needs an algorithm to calculate the state (positions of all disks) of the game for a given move number. That is why solving this problem is only feasible using the mathematical formula.

### Dependency and project execution flow

#### Execution flow
- The **ToH_AfterNightOut** project deal with the implementation for the tower of Hanoi problem based on our problem statement and the **ToHUnitTests** project is a unit test project with uses MS Test and is for testing the **ToH_AfterNightOut** project.
- To use this project open the project using its solution file in visual studio, then build and run the project.
- For the unit test run all test cases in Test Explorer.

#### Dependency
- Dot net core 2.0.
- MS Test for unit test project.
- IDE environmnet visual studio.
- Git for version control.

### UnitTest Project
+ The unit test project uses data driven approach for testing the expected values for each case.
+ The DataSource Attribute's, TestContext.DataRow property isn't available for dotnet Core so we had to use a work around for this using DynamicData Attribute.
+ Reference
	- [Answer on StackOverflow](https://stackoverflow.com/a/53113431/8010021)
	- [Issue raised on .net Core Official Github Repo](https://stackoverflow.com/a/53113431/8010021)
+ If the test case project doesn't work then please open TestCasesData folder & then open  **ToHTestCases.json** file properties. There please check "Copy to Output Directory" property is set to "Copy if newer".

### Reference

[Clifford's Tower of Hanoi Formula](http://www.clifford.at/hanoi/)
[Formula & Research papers related to Tower of Hanoi](http://mathworld.wolfram.com/TowerofHanoi.html)
