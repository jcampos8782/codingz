class LruCache:

    # The cache will contain objects which maintain pointers to the
    # next and previous entries. This creates a doubly linked list
    # that allows for O(1) operations for all gets and puts.
    __cache = None

    def __init__(self, capacity):
        self.__capacity = capacity
        self.__head = None
        self.__tail = None
        self.__cache = {}

    def get(self, key):
        if key not in self.__cache:
            return None

        # Pull the item from the cache and place it back at the end of the queue.
        item = self.__cache[key]
        self.__splice(item)
        self.__append(item)
        return item.val

    def put(self, key, value):
        # If the key is already in the cache, move it to the back of the queue
        # Since we aren't changing the size of the queue, we don't need to perform
        # a capacity check
        if key in self.__cache:
            item = self.__cache[key]
            self.__splice(item)
        # If the cache is at capacity, remove the oldest entry from the cache
        elif len(self.__cache) == self.__capacity:
            self.__pop()

        item = [key, value, None, self.__head]
        self.__append(item)
        self.__cache[key] = item

    def __splice(self, item):
        # Splice this item out of the list
        prv = item.prv
        nxt = item.nxt

        # If this is the last item in the list, set the prv as the new tail
        if nxt is None:
            self.__tail = prv
        else:
            nxt.prv = prv

        # If this is the first item in the list, set the head
        if prv is None:
            self.__head = nxt
        else:
            prv.nxt = nxt

    def __is_empty(self):
        return len(self.__cache) == 0

    def __append(self, item):
        if not (self.__is_empty() or self.__head == item):
            self.__head.prv = item
            item.nxt = self.__head

        self.__head = item

        if self.__tail is None:
            self.__tail = item

    def __pop(self):
        if not self.__is_empty():
            new_tail = self.__tail.prv
            self.__tail.prv = None
            self.__tail = new_tail

            if self.__tail is not None:
                self.__tail.nxt = None

            # Edge case for a capacity of 1
            if self.__tail == self.__head:
                self.__head = None

    class Node:
        def __init__(self, val=None, nxt=None, prv=None):
            self.val = val
            self.nxt = nxt
            self.prv = prv
