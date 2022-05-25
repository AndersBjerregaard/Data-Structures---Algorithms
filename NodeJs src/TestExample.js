// Load Unit.js module
var test = require('unit.js');

describe('example', function(){
    it('example variable', function(){
        var example = 'hello world';

        test.string(example);
    })
})