
function removeDuplicates(arr) {
    let unique = [];
    let repeat = {};
    for (let i = 0; i < arr.length; i++) {
        if (!unique.includes(arr[i])) {
            unique.push(arr[i]);
        }
        if (repeat[arr[i]]) {
            repeat[arr[i]]++;
        } else {
            repeat[arr[i]] = 1;
        }
    }
    console.log("Tekrarsiz array:", unique);
    for (let key in repeat) {
        if (repeat[key] > 1) {
            console.log(`${key} -> ${repeat[key]} defe`);
        }
    }
}
removeDuplicates([1, 2, 3,7,8,7,9,3]);

console.log("-------------------------------------------------------");

//2

function isPalindrome(word) {
    let reversed = "";
    for (let i = word.length - 1; i >= 0; i--) {
        reversed += word[i];
    }
    if (word === reversed) {
        console.log("Palindromdur");
    } else {
        console.log("Palindrom deyil");
    }
}
isPalindrome("kelek");
isPalindrome("salam");
console.log("-------------------------------------------------------");

//3

function countSmallerElements(arr, num) {
    let count = 0;
    for (let i = 0; i < arr.length; i++) {
        if (num < arr[i]) {
            count++;
        }
    }
    console.log(`${num} ededi arrayde ${count} elementden kiçikdir`);
}
countSmallerElements([5, 8, 6, 1, 3], 4);
console.log("-------------------------------------------------------");


//4
function checkNumber(num) {
    let sum = 0;
    for (let i = 1; i < num; i++) {
        if (num % i === 0) {
            sum += i;
        }
    }
    if (sum > num) {
        console.log(num + " Abundant ededdir");
    } else {
        console.log(num + " Deficient ededdir");
    }
}
checkNumber(16);
checkNumber(12);

console.log("-------------------------------------------------------");

//5
function squareArray(arr) {
    let result = [];
    for (let num of arr) {
        result.push(num * num);
    }
    return result;
}
console.log(squareArray([1, 2, 3, 4,5]));

