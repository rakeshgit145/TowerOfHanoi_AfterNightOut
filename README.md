#Tower of Hanoi - after a night out!

####Reference for the question:-

Below is the reference for the question.
[Indorse - Tower of Hanoi After a NightOut](https://indorse.io/assignments/5ce909ccc5e3380001ed8b3e)

### About the Problem

The Tower of Hanoi (commonly also known as the **Towers of Hanoi(ToH)**), is a puzzle invented by E. Lucas in 1883. It is also known as the Tower of Brahma puzzle and appeared as an intelligence test as per Vedic Indian Culture.

The time to compute number of moves for any "n" number of disk increases exponentially & the worst case time complexity for reccursive algorithm for this problem is $$O(2^n$$).

We all know that mathematical formula to take out the number of moves for ToH are:-

Recursive Mathematical formula is:-

$$T(n) = 2T_{n-1}  +1 $$

and the General formula proved by Mathematical Induction is :-

$$ T(n)= 2^n-1 $$

###Example to Illustrate Complexity

To Illustrate the problem with using the reccursive approach to solve this problem is that it becomes extremely expensive to compute as the number of disk increases.

For example:- Let say that n=64, then let see how much time a computer would take to compute the number of moves for the same.
Lets suppose that, present day computers can perform a single calculation in microSeconds, then,

According to the general formula of ToH, number of moves for n=64 is:

$$Number of Moves = 2^{64} -1= 18446744073709551615$$
if, the compute time of todays cpu is in microseconds for executing single instruction then also, 

**18446744073709551615 seconds  ~= 584942417355.072 years**
both divides by $$10^6$$ would give,
**18446744073709.551615 seconds  ~= 584942.417355072 years**

Even to compute the number of moves for n = 64, this approach is computationally so expensive that computing only single value of n = 64, it would take nearly 585 thousands of year on any average computer at present.

So computing this using reccursive algorithm is not even feasible for even 1 value of large disk count. Computing the same for sum of all values in range of (1-10000) is not feasible.
This Problem lies in that set of computational problem which is only feasible with infinite time & Infinite resource(Memory).

###Alternative approach with respect to this Problem

Many people have published algorithms for solving a towers of Hanoi game move by move. However - solving a Tower of Hanoi game with 64 disks move by move needs a long time and so one might want a solution for skipping a few billion moves. In order to do so one just needs an algorithm to calculate the state (positions of all disks) of the game for a given move number. That is why solving this problem is only feasible using the mathematical formula.

###Reference

[Clifford's Tower of Hanoi Formula](http://www.clifford.at/hanoi/)
[Formula & Research papers related to Tower of Hanoi](http://mathworld.wolfram.com/TowerofHanoi.html)
