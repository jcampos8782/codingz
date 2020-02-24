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
"""


def get_lights_for_day_n(day, lights):
    # convert the "lights" array to a sequence of bits
    light_sequence = 0x0

    for light in lights:
        light_sequence |= light
        light_sequence <<= 1

    # Undo the last shift
    light_sequence >>= 1

    while day > 0:
        """
         Perform a left shift and a right shift of the bits which can be used to solve which lights come on for 
         day n+1.
         
         There are two cases:
            1) Lights in both neighbors are ON. Performing an AND of the left and right shifts will give you which lights
               should come on for this case.
            2) Lights in both neighbors are OFF. Performing an OR of the left and right shift will place a 0 where neither
               neighbor had a light on. Perform an XOR with 0xFF to determine which lights come on in this case.
        
        Perform an OR of the previous two cases to figure out which lights come on for day n + 1.
        Finally, we care only about the 8 houses. AND with 0xFF to gain the solution. 
        """
        left_shift = light_sequence << 1
        right_shift = light_sequence >> 1
        tomorrow = ((left_shift & right_shift) | ((left_shift | right_shift) ^ 0xFF)) & 0xFF

        # Set light_sequence for the next iteration and subtract a day
        light_sequence = tomorrow
        day -= 1

    return list(map(lambda n: int(n), "{0:08b}".format(light_sequence)))
