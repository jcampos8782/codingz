"""
Imagine there are eight houses in a row, each with their light on or their light off on day n.
On day n + 1, a house will turn its lights on if either both neighbors had their lights on or both neighbors
had their lights off on the previous day. The two houses on the left end has no neighbor to its left and the
house on the right end has no neighbor to its right, so on day n+1 they will only turn their light on if on day
n their neighbor had their light off.

Write a function which determines the state of the lights on a specified day.

The functions input is a number which represents the day to determine the state of the lights and an initial state
of the lights represented as an array of 1s and 0s.

For example:
def get_lights_for_day(10, [0,0,1,1,0,1,0,0]

Output should be an array of 1s and 0s which represent the state of the lights on day n.

For an explanation of this solution, visit https://medium.com/analytics-vidhya/interview-question-neighbors-lights-7b7940dd36f6
"""
import functools


def get_lights_for_day_n(day, lights):
    light_sequence = functools.reduce(lambda a, b: (a << 1) | b, lights)

    while day > 0:
        left_shift = light_sequence << 1
        right_shift = light_sequence >> 1
        light_sequence = ((left_shift & right_shift) | ((left_shift | right_shift) ^ 0xFF))
        day -= 1

    return list(map(lambda n: int(n), "{0:08b}".format(light_sequence)))
