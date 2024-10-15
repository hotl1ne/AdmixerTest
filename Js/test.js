var sudoku =[
    [5, 3, 4, 6, 7, 8, 9, 1, 2],
    [6, 7, 2, 1, 9, 5, 3, 4, 8],
    [1, 9, 8, 3, 4, 2, 5, 6, 7],
    [8, 5, 9, 7, 6, 1, 4, 2, 3],
    [4, 2, 6, 8, 5, 3, 7, 9, 1],
    [7, 1, 3, 9, 2, 4, 8, 5, 6],
    [9, 6, 1, 5, 3, 7, 2, 8, 4],
    [2, 8, 7, 4, 1, 9, 6, 3, 5],
    [3, 4, 5, 2, 8, 6, 1, 7, 9]];

function validSudoku(sudoku)
{
    const seen = new Set();
    for(let i = 0; i<9; i++)
    {
        for(let j = 0; j<9; j++)
        {
            const num = sudoku[i][j];

            const rowKey = `${num} in row ${i}`;
            const colKey = `${num} in col ${j}`;
            const boxKey = `${num} in box ${Math.floor(i / 3)}-${Math.floor(j / 3)}`;

            if (seen.has(rowKey) || seen.has(colKey) || seen.has(boxKey)) {
                return false;
            }

            seen.add(rowKey);
            seen.add(colKey);
            seen.add(boxKey);
        }
    }
    return true; 
}

console.log(validSudoku(sudoku));