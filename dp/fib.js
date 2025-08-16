function fib(n){
    if(n === 0 || n === 1) return n;
    return fib(n-1) + fib(n-2);
}

// Memoisation
function fib(n, memo) {
  // if (n === 0 || n === 1) return n;
  if (memo[n] !== undefined) return memo[n];
  memo[n - 1] = fib(n - 1, memo);
  memo[n - 2] = fib(n - 2, memo);
  memo[n] = memo[n - 1] + memo[n - 2];
  return memo[n];
}
const memo = new Array(41);
memo[0] = 0;
memo[1] = 1;
fib(40, memo);

// Tabulation
function fib1(n) {
  const memo = new Array(n + 1);

  (memo[0] = 0), (memo[1] = 1);
  for (let i = 2; i <= n; i++) {
    memo[i] = memo[i - 1] + memo[i - 2];
  }
  return memo[n];
}

fib1(40);

// Tabulation - space optimised
function fib(n){
    let a = 0, b = 1;
    for(let i = 2; i <= n; i++){
        const sum = a + b;
        a = b;
        b = sum;
    }
    return b;
}