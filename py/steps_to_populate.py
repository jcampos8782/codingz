"""
Write a function which accepts a square array of 1s and 0s which represent populated and unpopulated nodes.
Nodes become populated if their directly adjacent neighboring node (up, down, left, or right) is populated.
This function should return the number of steps it will take for all nodes to become populated.
"""


def steps_to_populate(arr):
    # First find all unpopulated nodes and add them to a set
    unpopulated = set([(row, col) for row in range(len(arr)) for col in range(len(arr[row])) if arr[row][col] == 0])

    # Each iteration of this while loop will increment the steps required by one
    # It will continue until all nodes have been populated
    steps = 0
    while len(unpopulated) != 0:
        # Any nodes with a populated neighbor should be populated in this step
        to_populate = set((row, col) for (row, col) in unpopulated if neighbor_populated(arr, row, col))

        for (row, col) in to_populate:
            arr[row][col] = 1

        unpopulated -= to_populate
        steps += 1

    return steps


def neighbor_populated(arr, row, col):
    # Ensure no wrapping by checking the column bounds
    left = col > 0 and arr[row][col - 1] == 1
    right = col < len(arr[row]) - 1 and arr[row][col + 1] == 1
    up = row > 0 and arr[row - 1][col] == 1
    down = row < len(arr) - 1 and arr[row + 1][col] == 1
    return up or down or left or right
