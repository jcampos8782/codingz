class Stack {
  constructor(){
    this.items = [];
  }

  push(item) {
    this.items[this.items.length] = item;
  }

  pop() {
    if (this.isEmpty()) return null;
    return this.items.splice(this.items.length - 1, 1)[0];
  }

  peek() {
    if (this.isEmpty()) return null;
    return this.items[this.items.length - 1];
  }

  isEmpty() {
    return this.items.length === 0;
  }
}

let q = new Stack();
"abcdefg".split('').forEach(c => q.push(c));

let s = "";
while(!q.isEmpty()) {
  s += q.pop();
}

console.log(s);
