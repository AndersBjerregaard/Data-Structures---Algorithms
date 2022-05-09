// Given an `M × N` integer matrix, shift all its elements by `1` in spiral order.

// Input:

// [
// 	[ 1,  2,  3,  4, 5],
// 	[16, 17, 18, 19, 6],
// 	[15, 24, 25, 20, 7],
// 	[14, 23, 22, 21, 8],
// 	[13, 12, 11, 10, 9]
// ]

// Output:

// [
// 	[25,  1,  2,  3, 4],
// 	[15, 16, 17, 18, 5],
// 	[14, 23, 24, 19, 6],
// 	[13, 22, 21, 20, 7],
// 	[12, 11, 10,  9, 8]
// ]

const shiftMatrix = (matrix = [[]], rowBoundary = matrix[0].length, 
    columnBoundary = matrix.length, index = 0, temp = null) => {

    // Top row
    for (let i = index; i < rowBoundary + index; i++) {
        let current = matrix[index][i];
        matrix[index][i] = temp;
        temp = current;
    }

    // Right-most column
    for (let i = index + 1; i < columnBoundary + index; i++) {
        let current = matrix[i][matrix[0].length - index - 1];
        matrix[i][matrix[0].length - index - 1] = temp;
        temp = current;
    }

    // Bottom row
    for (let i = matrix[0].length - index - 2; i >= index; i--) {
        let current = matrix[matrix.length - index - 1][i];
        matrix[matrix.length - index - 1][i] = temp;
        temp = current;
    }

    // Left-most column
    for (let i = matrix.length - index - 2; i > 0 + index; i--) {
        let current = matrix[i][index];
        matrix[i][index] = temp;
        temp = current;
    }

    // Recursive call
    if (rowBoundary >= 0 && columnBoundary >= 0) {
        return shiftMatrix(matrix, rowBoundary - 2, columnBoundary - 2, index + 1, temp);
    } else {
        matrix[0][0] = temp;
        return matrix;
    }
}

console.log(shiftMatrix([
	[ 1,  2,  3,  4, 5],
	[16, 17, 18, 19, 6],
	[15, 24, 25, 20, 7],
	[14, 23, 22, 21, 8],
	[13, 12, 11, 10, 9]
])) // [
// 	[25,  1,  2,  3, 4],
// 	[15, 16, 17, 18, 5],
// 	[14, 23, 24, 19, 6],
// 	[13, 22, 21, 20, 7],
// 	[12, 11, 10,  9, 8]
// ]

console.log(shiftMatrix([1, 2, 3, 4, 5])) // [5, 1, 2, 3, 4]

console.log(shiftMatrix([
	[ 1,  2,  3,  4, 5,  6 ],
	[20, 21, 22, 23, 24, 7 ],
	[19, 32, 33, 34, 25, 8 ],
	[18, 31, 36, 35, 26, 9 ],
	[17, 30, 29, 28, 27, 10],
    [16, 15, 14, 13, 12, 11]
]))

console.log(shiftMatrix([
    [1, 2, 3, 4],
    [5, 6, 7, 8],
    [9,10,11,12]
]))