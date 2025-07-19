class TwoStacks {
    // constructor for twoStacks()
    constructor() {
        this.arr = [];
        for(let i = 0; i < 200; i++){
            this.arr[i] = -1;
        }
        this.top1 = -1;
        this.top2 = 200;
    }

    // Function to push an integer into the stack1.
    push1(x) {
        // code here
        this.top1++;
        this.arr[this.top1] = x;
    }

    // Function to push an integer into the stack2.
    push2(x) {
        
        // code here
        this.top2--;
        this.arr[this.top2] = x;
    }

    // Function to remove an element from top of the stack1.
        
    pop1() {
        // code here
        if(this.top1 === -1) return -1;
        const result = this.arr[this.top1];
        this.top1--;
        return result;
    }

        
    // Function to remove an element from top of the stack2.
    pop2() {
        // code here
         if(this.top2 === 200) return -1;
        const result = this.arr[this.top2];
        this.top2++;
        return result;
    }
}