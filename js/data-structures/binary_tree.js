// Use a closure instead of a class because why not?
let binaryTree = function() {
    let tree = []
    let _currentNode = 0;

    function _printInOrder(i, s = []) {
      if (tree[i] === null || tree[i] === undefined) return;
      _printInOrder((i * 2) + 1, s);
      s[s.length] = tree[i];
      _printInOrder((i * 2) + 2, s);
      return s;
    }

    function _printPreOrder(i, s = []) {
      if (tree[i] === null || tree[i] === undefined) return;
      s[s.length] = tree[i];
      _printPreOrder((i * 2) + 1, s);
      _printPreOrder((i * 2) + 2, s);
      return s;
    }

    function _printPostOrder(i, s = []) {
      if (tree[i] === null || tree[i] === undefined) return;
      _printPostOrder((i * 2) + 1, s);
      _printPostOrder((i * 2) + 2, s);
      s[s.length] = tree[i];
      return s;
    }

    return {
      add: function(i) {
        tree[_currentNode++] = i;
      },

      inOrder: function() {
        return _printInOrder(0);
      },

      preOrder: function() {
        return _printPreOrder(0);
      },

      postOrder: function() {
        return _printPostOrder(0);
      },
    }
}();

Array.from({length:100}, (_,i) => i).forEach(i => binaryTree.add(i));
console.log(`In order traversal: ${binaryTree.inOrder().join(',')}`);
console.log(`Pre order traversal: ${binaryTree.preOrder().join(',')}`);
console.log(`Post order traversal: ${binaryTree.postOrder().join(',')}`);
