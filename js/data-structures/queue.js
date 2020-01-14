class Queue {
  constructor() {
    this.items = [];
  }

  add(item) {
    this.items[this.items.length] = item;
  }

  remove() {
    if (this.isEmpty()) return null;
    return this.items.splice(0,1)[0];
  }

  peek() {
    if (this.isEmpty()) return null;
    return this.items[0];
  }

  isEmpty() {
    return this.items.length === 0;
  }
}

let q = new Queue();
"abcdefg".split('').forEach(c => q.add(c));

let s = "";
while(!q.isEmpty()) {
  s += q.remove();
}

console.log(s);
