import collections


class LruCache:

    # The cache will hold a key and a reference to an object in the linked list.
    # This will allow for O(1) lookups, removals, and updates in the queue
    __cache = None

    # deque is a doubly-linked list internally and provides O(1) removal and appends
    # This structure will hold the objects themselves.
    __queue = None

    def __init__(self, capacity):
        self.__capacity = capacity
        self.__queue = collections.deque()
        self.__cache = {}

    def get(self, key):
        if key not in self.__cache:
            return None

        # Pull the item from the cache and place it back at the end of the queue.
        item = self.__cache[key]
        self.__queue.remove(item)
        self.__queue.append(item)
        return item[1]

    def put(self, key, value):
        # If the key is already in the cache, move it to the back of the queue
        # Since we aren't changing the size of the queue, we don't need to perform
        # a capacity check
        if key in self.__cache:
            self.__queue.remove(self.__cache[key])
        # If the cache is at capacity, remove the oldest entry from the cache
        elif len(self.__cache) == self.__capacity:
            del self.__cache[self.__queue.popleft()[0]]

        # Create a tuple that will be referenced in the list and by the cache.
        item = (key, value)
        self.__cache[key] = item
        self.__queue.append(item)
