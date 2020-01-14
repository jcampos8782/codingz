// A function to determine if a string is a permutation of another

function isPermutation(a,b) {
  // Sort the character arrays, rejoin them as a string, and then compare
  return a.split('').sort().join() == b.split('').sort().join();
}

let tests = [
  ["abc123", "312cab", true],
  ["a b c d", "d cb a ", true],
  ["abcd", "addb", false]
]

tests.map(a => console.log(`${isPermutation(a[0], a[1]) === a[2] ? "PASS" : "FAIL!"}`));
