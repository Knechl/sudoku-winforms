## Sudoku

A Windows Forms Sudoku game written in C#. Generate, play, and solve Sudoku puzzles with three difficulty levels.

### Features

* Generates a complete 9×9 solution using backtracking.  
* Masks cells based on difficulty: Easy (34), Medium (30), Hard (26).  
* Pre-filled cells are colored light blue and locked for editing.  
* Validates user input:  
  * Correct entries lock immediately.  
  * Incorrect entries turn red and increment a “fail” counter.  
  * After three mistakes, the board locks.  
* “Show Solution” reveals the full puzzle and locks all cells.  
* “Reset Game” clears the board, resets errors, and stops the current game.  
* “Solve Custom Puzzle” lets you enter your own numbers; the built-in solver completes the rest and highlights new entries in light green. 

### Usage

1. Run `Sudoku.exe`.  
2. Select a difficulty level and click **New Game**.  
3. Fill numbers (1–9) into empty cells:  
   - Correct entries become locked.  
   - Wrong entries turn red; three mistakes lock the board.  
4. Click **Show Solution** to reveal the full solved board.  
5. Click **Reset Game** to clear the board and reset errors.  
6. To solve a custom puzzle:  
   1. Manually enter numbers into the grid.  
   2. Click **Solve Custom Puzzle**.  
      - The solver fills remaining cells; your original entries stay locked and new ones are highlighted in green.  
