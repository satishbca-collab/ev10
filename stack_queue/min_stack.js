
var MinStack = function() {
    this.arr = [];
};

/** 
 * @param {number} val
 * @return {void}
 */
MinStack.prototype.push = function(val) {
    const n = this.arr.length;
    if(this.arr.length === 0){
        this.arr.push([val, val]);
        return;
    }
    if(val > this.arr[n-1][1]){
        this.arr.push([val, this.arr[n-1][1]]);
    }
    else {
        this.arr.push([val, val]);
    }
};

/**
 * @return {void}
 */
MinStack.prototype.pop = function() {
    const [val, minVal] = this.arr.pop();
    return val;
};

/**
 * @return {number}
 */
MinStack.prototype.top = function() {
    const [val, minVal] = this.arr[this.arr.length-1];
    return val;
};

/**
 * @return {number}
 */
MinStack.prototype.getMin = function() {
    const [val, minVal] = this.arr[this.arr.length-1];
    return minVal;
};

/** 
 * Your MinStack object will be instantiated and called as such:
 * var obj = new MinStack()
 * obj.push(val)
 * obj.pop()
 * var param_3 = obj.top()
 * var param_4 = obj.getMin()
 */