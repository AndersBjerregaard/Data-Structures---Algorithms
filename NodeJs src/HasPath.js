// This problem builds upon the fundamentals explained in the contents of the file 'AdjacencyList.js'.

// An acyclic graph is a graph whereas you can never get to where you started through normal means of traversal.
// Cyclic being the opposite of above.

// Write a function, hasPath, that takes in an object representing the adjacency list of a directed acyclic graph
// and two nodes (src, dst). The function should return a boolean indicating whether or not there exists a directed path
// between the source and destination nodes.

// Depth First Traversal approach to the solution. 
// This function is implemented recursively to take advantage of the call stack structure at runtime.
const hasPathDepthFirst = (graph, src, dst) => {
    // Base case
    if (src === dst) return true;

    // Evaluate each neighbour
    for (let neighbour of graph[src]) {
        // If at any point the destination node is hit. Return true to the top caller.
        if (hasPathDepthFirst(graph, neighbour, dst) === true) {
            return true;
        }
    }

    // Only return false after the loop, to make sure every possible path has been evaluated.
    return false;
};

const hasPathBreadthFirst = (graph, src, dst) => {
    const queue = [src];

    while (queue.length > 0) {
        const current = queue.shift();
        // Base case
        if (current === dst) return true;

        // Evaluate each neighbour
        for (let neighbour of graph[current]) {
            queue.push(neighbour);
        }
    }

    // Like the other implementation. Only return false after every possible path has been evaluated.
    return false;
};

// Tests

// Load Unit.js module
var test = require('unit.js');

describe('HasPath.js tests', function(){
    it('test_00', function(){
        const graph = {
            f: ['g', 'i'],
            g: ['h'],
            h: [],
            i: ['g', 'k'],
            j: ['i'],
            k: []
        };

        test.assert(hasPathDepthFirst(graph, 'f', 'k') === true);
        test.assert(hasPathBreadthFirst(graph, 'f', 'k') === true);
    });

    it('test_01', function(){
        const graph = {
            f: ['g', 'i'],
            g: ['h'],
            h: [],
            i: ['g', 'k'],
            j: ['i'],
            k: []
        };

        test.assert(hasPathDepthFirst(graph, 'f', 'j') === false);
        test.assert(hasPathBreadthFirst(graph, 'f', 'j') === false);
    });

    it('test_02', function(){
        const graph = {
            f: ['g', 'i'],
            g: ['h'],
            h: [],
            i: ['g', 'k'],
            j: ['i'],
            k: []
        };

        test.assert(hasPathDepthFirst(graph, 'i', 'h') === true);
        test.assert(hasPathBreadthFirst(graph, 'i', 'h') === true);
    });

    it('test_03', function(){
        const graph = {
            v: ['x', 'w'],
            w: [],
            x: [],
            y: ['z'],
            z: [],
        };

        test.assert(hasPathDepthFirst(graph, 'v', 'w') === true);
        test.assert(hasPathBreadthFirst(graph, 'v', 'w') === true);
    });

    it('test_04', function(){
        const graph = {
            v: ['x', 'w'],
            w: [],
            x: [],
            y: ['z'],
            z: [],
        };

        test.assert(hasPathDepthFirst(graph, 'v', 'z') === false);
        test.assert(hasPathBreadthFirst(graph, 'v', 'z') === false);
    });
});