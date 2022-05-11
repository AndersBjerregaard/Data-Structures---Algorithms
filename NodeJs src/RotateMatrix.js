// Given an `N × M` integer matrix, rotate the matrix by 180 degrees in a clockwise direction. 
// The transformation should be done in-place in quadratic time.

const rotateMatrix = (matrix = [[]]) => {
    // First reverse the order of the arrays
    // Then reverse the order of the elements within all the arrays
    // We do both through a merge sort

    let i = 0;
    // We can instantiate the variable k to the amount of arrays, since we have a constraint
    // that the matrix matrix will always be a square
    let k = matrix.length - 1;
    while (i < k) {
        let temp = matrix[i];
        matrix[i] = matrix[k];
        matrix[k] = temp;

        i++;
        k--;
    }
    
    for (let j = 0; j < matrix.length; j++) {
        i = 0;
        k = matrix[0].length - 1;
        while (i < k) {
            let temp = matrix[j][i];
            matrix[j][i] = matrix[j][k];
            matrix[j][k] = temp;

            i++;
            k--;
        }
    }
    
    return matrix;
}

// Tests
console.log(rotateMatrix([
	[1,  2,  3,  4],
	[5,  6,  7,  8],
	[9,  10, 11, 12],
	[13, 14, 15, 16]
])); // [
// 	[16, 15, 14, 13],
// 	[12, 11, 10, 9],
// 	[8,  7,  6,  5],
// 	[4,  3,  2,  1]
// ]
console.log(rotateMatrix([
    [1,  2,  3,  4, 17],
	[5,  6,  7,  8, 18],
	[9,  10, 11, 12, 19],
	[13, 14, 15, 16, 20]
]));