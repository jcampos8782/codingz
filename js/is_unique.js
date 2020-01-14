/*
 Determines if a string has all unique characters
*/
function isUnique(str) {
  // Blow up the string and reduce the characters into a hash of keys.
  // If count of keys is same length as original string, then all
  // characters were unique.
  return Object.keys(str.split('').reduce((acc,b) => {
    acc[b] = 1;
    return acc;
  }, {})).length === str.length;
}

let tests = [
  ["abccdΩa", false],
  ["abcdefg", true],
  ["the quick-brown_fax", true],
  ["this quick brown fox", false]
];

console.log("isUnique()");
tests.map(a => console.log(`${isUnique(a[0]) === a[1] ? "PASS" : "FAIL!"}`));
