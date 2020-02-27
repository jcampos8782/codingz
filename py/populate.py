"""
Write a function which accepts as arguments the dimensions of a grid and a grid of 1s and 0s which represent populated
and unpopulated nodes. Nodes become populated if their directly adjacent neighboring node (up, down, left, or right) is
populated. The function should populate the argument grid and return the number of steps required to populate the entire
grid.
"""


def populate(rows: int, cols: int, grid: [[int]]) -> int:
    # First find all unpopulated nodes and add them to a set
    unpopulated = set((row, col) for row in range(rows) for col in range(cols) if grid[row][col] == 0)

    # If there are no ones return.
    if len(unpopulated) == rows * cols:
        return float("inf")

    # Each iteration of this while loop will increment the steps required by one
    # It will continue until all nodes have been populated
    steps = 0
    while len(unpopulated) != 0:
        # Any nodes with a populated neighbor should be populated in this step
        to_populate = set((row, col) for (row, col) in unpopulated if neighbor_populated(grid, row, col))

        for (row, col) in to_populate:
            grid[row][col] = 1

        unpopulated -= to_populate
        steps += 1

    return steps


def neighbor_populated(grid: [[int]], row: int, col: int) -> bool:
    # Ensure no wrapping by checking the column bounds
    left = col > 0 and grid[row][col - 1] == 1
    right = col < len(grid[row]) - 1 and grid[row][col + 1] == 1
    up = row > 0 and grid[row - 1][col] == 1
    down = row < len(grid) - 1 and grid[row + 1][col] == 1
    return up or down or left or right
