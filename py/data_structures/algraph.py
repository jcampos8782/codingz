class AdjacencyListGraph:
    """Graph class which provides both DFS and BFS search capabilities. Uses an Adjacency list for storage"""

    __vertices = {}

    def __init__(self):
        pass

    def add_vertex(self, vertex):
        if vertex not in self.__vertices:
            self.__vertices[vertex] = set([])

    def add_edge(self, v1, v2):
        if v1 in self.__vertices and v2 in self.__vertices:
            self.__vertices[v1].add(v2)
            self.__vertices[v2].add(v1)

    def remove_edge(self, v1, v2):
        if v1 in self.__vertices and v2 in self.__vertices:
            self.__vertices[v1].remove(v2)
            self.__vertices[v2].remove(v1)

    def dfs(self, start):
        self.__search(start, True)

    def bfs(self, start):
        self.__search(start, False)

    def __search(self, start, is_dfs):
        visited = set([])
        to_visit = [start]

        while len(to_visit) != 0:
            v = to_visit.pop()

            if v in visited:
                continue

            visited.add(v)
            print("Visited " + str(v))

            # What differentiates a DFS vs BFS is how we add nodes to the queue
            # DFS we add edges adjacent to this node to the top of the stack
            # BFS we add edges adjacent to this node to the back of the queue
            if is_dfs:
                for e in self.__vertices[v]:
                    to_visit.append(e)
            else:
                for e in self.__vertices[v]:
                    to_visit.insert(0, e)
