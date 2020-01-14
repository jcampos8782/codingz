/*
 Function to remove duplicates from an unsorted linked list.
*/

function removeDuplicates(list) {
  let m = {}
  let current = list.get();
  let last = null;

  while(current != null) {
    // If the value has already been encountered, squeeze it out.
    // Otherwise, move last to current.
    if (m[current.value]) {
      last.next = current.next;
    } else {
      last = current;
    }

    // Register the value and move current
    m[current.value] = 1;
    current = current.next;
  }
}

let list = function(){
  let root = null;
  let tail = null;

  return {
    add: function(value){
        let node = {
          value: value,
          next: null
        };

        if (root === null) {
          root = node;
          tail = node;
        } else {
          tail.next = node;
        }

        tail = node;
    },

    get: function() {
      return root;
    },

    toString: function() {
      let s = "";
      let c = root;
      while(c != null) {
        s += c.value;
        c = c.next;
      }
      return s;
    },
  }
}();

"aabbaaccbbddeeffggab".split('').forEach(c => list.add(c));
removeDuplicates(list);
console.log(`${list.toString() == "abcdefg" ? "PASS" : "FAIL!!"}`);
