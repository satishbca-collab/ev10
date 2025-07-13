/**
 * @param {number} n
 * @return {string[][]}
 */
var solveNQueens = function(n) {
    const board = [], result= [];

    for(let i = 0; i < n; i++){
        board[i] = [];
        for(let j = 0; j < n; j++){
            board[i][j] = '.';
        }
    }

    Helper(board,0, result);
    return result;
};

function Helper(board, index, result){
    const n = board.length;
    if(index == n){
        result.push(transform(board));
        return;
    }

    for(let i = 0; i < n; i++){
        if(issafe(board, index, i)){
            board[index][i] = 'Q';
            Helper(board, index + 1, result);
            board[index][i] = '.';
        }
    }
}

function issafe(board, x, y){
    const n = board.length;

    for(let i = x - 1; i >= 0; i--){
        if(board[i][y] == 'Q') return false;
    }

    for(let i = x - 1, j = y - 1; i >= 0 && j >= 0; i--, j--){
        if(board[i][j] == 'Q') return false;
    }

    for(let i = x - 1, j = y + 1; i >= 0 && j < n; i--, j++){
        if(board[i][j] == 'Q') return false;
    }

    return true;
}

function transform(board){
    const n = board.length;
    var str = [];
    for(let i = 0; i < n; i++){
        str.push(board[i].join(''));
    }
    return str;
}