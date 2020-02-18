class MinHeap:

    __heap = [-0]

    def __init__(self): pass

    def insert(self, value):
        self.__heap.append(value)
        self.__sift_up()

    def pop(self):
        if len(self.__heap) == 1:
            return None

        minimum = self.__heap[1]

        if len(self.__heap) == 2:
            self.__heap.pop()
        else:
            self.__heap[1] = self.__heap.pop()
            self.__sift_down()

        return minimum

    def __sift_up(self):
        idx = len(self.__heap) - 1
        parent = idx >> 1
        while idx > 1 and self.__heap[idx] < self.__heap[parent]:
            tmp = self.__heap[idx]
            self.__heap[idx] = self.__heap[parent]
            self.__heap[parent] = tmp
            idx = parent
            parent = idx >> 1

    def __sift_down(self):
        idx = 1
        size = len(self.__heap)

        while idx < size:
            minimum = self.__heap[idx]
            left = idx << 1
            right = left + 1
            swap = None

            if left < size and self.__heap[left] < minimum:
                minimum = self.__heap[left]
                swap = left
            if right < size and self.__heap[right] < minimum:
                swap = right

            if swap is None:
                break

            tmp = self.__heap[swap]
            self.__heap[swap] = self.__heap[idx]
            self.__heap[idx] = tmp

            idx = swap
