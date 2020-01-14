/*
 Determines if a string has all unique characters
*/
function isUnique(str) {
  // Blow up the string and sort it. If two adjacent characters
  // are the same, the string does not have unique characters
  let sortedCharArray = str.split('').sort();
  for(i = 1; i < sortedCharArray.length; i++) {
    if(sortedCharArray[i - 1] === sortedCharArray[i]) {
      return false;
    }
  }
  return true;
}

function isUnique2(str) {
    let chars = {};
    str.split('').forEach(c => chars[c] = true);
    return Object.keys(chars).length === str.length;
}

let tests = [
  ["abccdΩa", false],
  ["abcdefg", true]
];

console.log("isUnique()");
tests.map(a => console.log(`${isUnique(a[0]) === a[1] ? "PASS" : "FAIL!"}`));
console.log("\n");

console.log("isUnique2()");
tests.map(a => console.log(`${isUnique2(a[0]) === a[1] ? "PASS" : "FAIL!"}`));
