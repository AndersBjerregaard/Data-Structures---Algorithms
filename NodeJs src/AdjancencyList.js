
// From a starting node. Traverse in a given direction untill a dead end is hit, afterwards change direction.
const depthFirstPrint = (graph, source) => {
    // Traversing depth first makes use of a stack datastructure.
    // Initialize the stack starting from the given parameter source node.
    const stack = [ source ];

    // Run the algorithm for as long as the stack is not empty.
    // As the purpose of the algorithm is to push and pop from the stack, as we traverse the graph.
    while (stack.length > 0) {
        // Pop the stack to evaluate the current node being looked at.
        const current = stack.pop();
        // The theory behind the implementation of this algorithm, is rooted in the thought that a node is being 'processed'
        // when it leaves the stack - not when it enters.
        console.log(current);

        // Evaluate all of current's neighbours. And push them to the stack.
        for (let neighbour of graph[current]) {
            // Take not that it'll be the last neighbour being pushed that'll also be popped.
            stack.push(neighbour);
        }
    }
}

// The recursive implementation of a depth first traversal, takes advantage of the call stack in synchronous code execution,
// to achieve the same result as a tabular / iterative approach.
// Take not that this recursive function does not have a base case, which might seem impractical or as a security flaw in runtime.
// But since this is an algorithm for a graph illustrated as an adjacency list, said base case responsibility is seen in the 
// adjacency list datastructure itself: It being when a value to a certain key is empty or null. That way, no iteration through 
// a processed node's 'neighbours' will occour.
const depthFirstRecursive = (graph, source) => {
    console.log(source);
    for (let neighbour of graph[source]) {
        depthFirstPrint(graph, neighbour);
    }
}

// It is practically impossible to implement a breadth first traversal recursively. As there'll be a stack structure that's gonna 
// 'fight' against the queue structure (which is characteristic of a breadth first traversal).
const breadthFirstPrint = (graph, source) => {
    // The implementation of this datastructure is essentially an array.
    // But with the usage of the array.push and array.shift methods: The characteristics of a queue structure will be achieved.
    const queue = [source];

    while (queue.length > 0) {
        const current = queue.shift();
        console.log(current);
        
        // Evaluate each neighbour
        for (let neighbour of graph[current]) {
            queue.push(neighbour);
        }
    }
}

// A graph illustrated as an adjancency list datastructure.
// An adjancency list is essentially a map-like datastructure, whose values to a certain key indicate relation to said key.
// Or in other words 'neighbours'.
// This backing datastructure is important, in order to attain constant time for lookup.
const graph = {
    a: ['b', 'c'],
    b: ['d'],
    c: ['e'],
    d: ['f'],
    e: [],
    f: []
};

// Time and Space complexity
// n = # nodes
// e (or n^2) = # edges
// Time = O(n^2)
// Space: O(n)

// Tests

// The 'a' parameter indicates starting node.
// Take not that both output are valid in terms of depth first traversal constraints. The 'direction' taken by the runtime 
// just happens to be different.
depthFirstPrint(graph, 'a'); // acebdf
depthFirstRecursive(graph, 'a') // abdfce

breadthFirstPrint(graph, 'a'); // acbedf