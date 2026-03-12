# Console Chess Game ♟️

A fully functional Chess System developed in **C#** and **.NET 10.0**. This project was built to practice advanced Logic of Programming, Object-Oriented Programming (OOP) principles, and C# best practices.

## 🚀 Features

- **Full Chess Rules:** Includes all standard movements for every piece.
- **Move Validation:** Prevents illegal moves and handles "Check" and "Checkmate" logic.
- **Captured Pieces Tracking:** Displays captured pieces for both players during the match.
- **Console Interface:** A clean and interactive command-line interface with highlighted possible moves.

## 🛠️ Technical Concepts Applied

- **Inheritance & Polymorphism:** Each piece type (King, Knight, Rook, etc.) inherits from a base `Piece` class.
- **Encapsulation:** Using properties with private setters and protected methods to ensure board integrity.
- **Data Structures:** Implementation of `HashSets` to manage pieces in game and captured pieces efficiently.
- **Exception Handling:** Custom `BoardException` to handle invalid moves or board states.

## 🎮 How to Run

1. Make sure you have the **.NET 10 SDK** installed.
2. Clone the repository:
   ```bash
   git clone https://github.com/HayziVV/Chess-Game.git
3. Run the application

📝 Notation
K: King

N: Knight

B: Bishop

R: Rook

Q: Queen

P: Pawn
