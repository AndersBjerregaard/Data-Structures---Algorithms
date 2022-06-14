// Given two sorted integer arrays, `X[]` and `Y[]` of size `m` and `n` each, 
// in-place merge elements of `X[]` with elements of array `Y[]` by maintaining the sorted order, 
// i.e., fill `X[]` with the first `m` smallest elements and fill `Y[]` with remaining elements.

const mergeArrays = (x = [], y = []) => {
    // Instantiate a variable for the given index of array 'x' to interpret
    let i = 0
    
    while (i < x.length) {
        // Instantiate a variable for the given index of array 'y' to interpret
        let k = 0;

        while (k < y.length) {
            
            

            k++;
        }

        i++;
    }
}

// Tests
console.log(mergeArrays([1, 4, 7, 8, 10], [2, 3, 9])); 
// X[] = [1, 2, 3, 4, 7]
// Y[] = [8, 9, 10]