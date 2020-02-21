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
        # To turn on lights where each light around was on (1), shift left and right and perform a bitwise AND
        left_shift = light_sequence << 1
        right_shift = light_sequence >> 1
        tomorrow = left_shift & right_shift

        # To turn on lights where each light around was off (0), complement and then perform the same shifting
        # and bitwise AND. Remember that the lights just beyond the end of our bits are assumed to be always
        # off. That means in our shifts we need to flip the high end bit in the right shift and the low end
        # bit in left shift
        complement = light_sequence ^ 0xFF
        left_shift = ((complement << 1) | 0x1) & 0xFF
        right_shift = ((complement >> 1) | 0x80) & 0xFF

        # Now perform an OR of the two sets of bits to determine which lights would be on on this day.
        tomorrow |= left_shift & right_shift & 0xFF
        light_sequence = tomorrow

        day -= 1

    return list(map(lambda n: int(n), "{0:08b}".format(light_sequence)))
