﻿/*
ChessLib, a chess data structure library

MIT License

Copyright (c) 2017-2019 Rudy Alex Kohn

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/

namespace Chess.Test.Move
{
    using Rudz.Chess;
    using Rudz.Chess.Enums;
    using Rudz.Chess.Types;
    using Xunit;

    public sealed class MoveNotationTests
    {
        [Fact]
        public void FanRankAmbiguationPositiveTest()
        {
            // Tests both knights moving to same square for Rank ambiguity

            const string fen = "8/6k1/8/8/8/8/1K1N1N2/8 w - - 0 1";
            const EMoveNotation notation = EMoveNotation.Fan;

            var movingPiece = new Piece(EPieces.WhiteKnight);
            var fromOneSquare = new Square(ESquare.d2);
            var fromTwoSquare = new Square(ESquare.f2);
            var toSquare = new Square(ESquare.e4);

            var uniChar = movingPiece.GetUnicodeChar();
            var toSquareString = toSquare.GetSquareString();

            var expectedPrimary = $"{uniChar}{fromOneSquare.FileChar()}{toSquareString}";
            var expectedSecondary = $"{uniChar}{fromTwoSquare.FileChar()}{toSquareString}";

            var g = new Game();
            g.NewGame(fen);

            var w1 = new Move(movingPiece, fromOneSquare, toSquare);
            var w2 = new Move(movingPiece, fromTwoSquare, toSquare);

            var actualPrimary = w1.ToNotation(g.State, notation);
            var actualSecondary = w2.ToNotation(g.State, notation);

            Assert.Equal(expectedPrimary, actualPrimary);
            Assert.Equal(expectedSecondary, actualSecondary);
        }

        [Fact]
        public void FanRankFileAmbiguationPositiveTest()
        {
            // Tests both knights moving to same square for Rank ambiguity

            const string fen = "8/6k1/8/8/8/8/1K1N1N2/8 w - - 0 1";
            const EMoveNotation notation = EMoveNotation.Fan;

            var movingPiece = new Piece(EPieces.WhiteKnight);
            var fromOneSquare = new Square(ESquare.d2);
            var fromTwoSquare = new Square(ESquare.g5);
            var toSquare = new Square(ESquare.e4);

            var uniChar = movingPiece.GetUnicodeChar();
            var toSquareString = toSquare.GetSquareString();

            var expectedPrimary = $"{uniChar}{fromOneSquare.FileChar()}{toSquareString}";
            var expectedSecondary = $"{uniChar}{fromTwoSquare.FileChar()}{toSquareString}";

            var g = new Game();
            g.NewGame(fen);

            var w1 = new Move(movingPiece, fromOneSquare, toSquare);
            var w2 = new Move(movingPiece, fromTwoSquare, toSquare);

            var actualPrimary = w1.ToNotation(g.State, notation);
            var actualSecondary = w2.ToNotation(g.State, notation);

            Assert.Equal(expectedPrimary, actualPrimary);
            Assert.Equal(expectedSecondary, actualSecondary);
        }

        [Fact]
        public void FanFileAmbiguationPositiveTest()
        {
            // Tests both knights moving to same square for File ambiguity

            const string fen = "8/6k1/8/8/3N4/8/1K1N4/8 w - - 0 1";
            const EMoveNotation notation = EMoveNotation.Fan;

            var movingPiece = new Piece(EPieces.WhiteKnight);
            var fromOneSquare = new Square(ESquare.d2);
            var fromTwoSquare = new Square(ESquare.d4);
            var toSquare = new Square(ESquare.f3);

            var uniChar = movingPiece.GetUnicodeChar();
            var toSquareString = toSquare.GetSquareString();

            var expectedPrimary = $"{uniChar}{fromOneSquare.RankOfChar()}{toSquareString}";
            var expectedSecondary = $"{uniChar}{fromTwoSquare.RankOfChar()}{toSquareString}";

            var g = new Game();
            g.NewGame(fen);

            var w1 = new Move(movingPiece, fromOneSquare, toSquare);
            var w2 = new Move(movingPiece, fromTwoSquare, toSquare);

            var actualPrimary = w1.ToNotation(g.State, notation);
            var actualSecondary = w2.ToNotation(g.State, notation);

            Assert.Equal(expectedPrimary, actualPrimary);
            Assert.Equal(expectedSecondary, actualSecondary);
        }

        [Fact]
        public void SanRankAmbiguationPositiveTest()
        {
            // Tests both knights moving to same square for Rank ambiguity

            const string fen = "8/6k1/8/8/8/8/1K1N1N2/8 w - - 0 1";
            const EMoveNotation notation = EMoveNotation.San;

            var movingPiece = new Piece(EPieces.WhiteKnight);
            var fromOneSquare = new Square(ESquare.d2);
            var fromTwoSquare = new Square(ESquare.f2);
            var toSquare = new Square(ESquare.e4);

            var uniChar = movingPiece.GetPieceChar();
            var toSquareString = toSquare.GetSquareString();

            var expectedPrimary = $"{uniChar}{fromOneSquare.FileChar()}{toSquareString}";
            var expectedSecondary = $"{uniChar}{fromTwoSquare.FileChar()}{toSquareString}";

            var g = new Game();
            g.NewGame(fen);

            var w1 = new Move(movingPiece, fromOneSquare, toSquare);
            var w2 = new Move(movingPiece, fromTwoSquare, toSquare);

            var actualPrimary = w1.ToNotation(g.State, notation);
            var actualSecondary = w2.ToNotation(g.State, notation);

            Assert.Equal(expectedPrimary, actualPrimary);
            Assert.Equal(expectedSecondary, actualSecondary);
        }

        [Fact]
        public void SanRankFileAmbiguationPositiveTest()
        {
            // Tests both knights moving to same square for Rank ambiguity

            const string fen = "8/6k1/8/8/8/8/1K1N1N2/8 w - - 0 1";
            const EMoveNotation notation = EMoveNotation.San;

            var movingPiece = new Piece(EPieces.WhiteKnight);
            var fromOneSquare = new Square(ESquare.d2);
            var fromTwoSquare = new Square(ESquare.g5);
            var toSquare = new Square(ESquare.e4);

            var uniChar = movingPiece.GetPieceChar();
            var toSquareString = toSquare.GetSquareString();

            var expectedPrimary = $"{uniChar}{fromOneSquare.FileChar()}{toSquareString}";
            var expectedSecondary = $"{uniChar}{fromTwoSquare.FileChar()}{toSquareString}";

            var g = new Game();
            g.NewGame(fen);

            var w1 = new Move(movingPiece, fromOneSquare, toSquare);
            var w2 = new Move(movingPiece, fromTwoSquare, toSquare);

            var actualPrimary = w1.ToNotation(g.State, notation);
            var actualSecondary = w2.ToNotation(g.State, notation);

            Assert.Equal(expectedPrimary, actualPrimary);
            Assert.Equal(expectedSecondary, actualSecondary);
        }

        [Fact]
        public void SanFileAmbiguationPositiveTest()
        {
            // Tests both knights moving to same square for File ambiguity

            const string fen = "8/6k1/8/8/3N4/8/1K1N4/8 w - - 0 1";
            const EMoveNotation notation = EMoveNotation.San;

            var movingPiece = new Piece(EPieces.WhiteKnight);
            var fromOneSquare = new Square(ESquare.d2);
            var fromTwoSquare = new Square(ESquare.d4);
            var toSquare = new Square(ESquare.f3);

            var uniChar = movingPiece.GetPieceChar();
            var toSquareString = toSquare.GetSquareString();

            var expectedPrimary = $"{uniChar}{fromOneSquare.RankOfChar()}{toSquareString}";
            var expectedSecondary = $"{uniChar}{fromTwoSquare.RankOfChar()}{toSquareString}";

            var g = new Game();
            g.NewGame(fen);

            var w1 = new Move(movingPiece, fromOneSquare, toSquare);
            var w2 = new Move(movingPiece, fromTwoSquare, toSquare);

            var actualPrimary = w1.ToNotation(g.State, notation);
            var actualSecondary = w2.ToNotation(g.State, notation);

            Assert.Equal(expectedPrimary, actualPrimary);
            Assert.Equal(expectedSecondary, actualSecondary);
        }

        [Fact]
        public void LanRankAmbiguationPositiveTest()
        {
            // Tests both knights moving to same square for Rank ambiguity

            const string fen = "8/6k1/8/8/8/8/1K1N1N2/8 w - - 0 1";
            const EMoveNotation notation = EMoveNotation.Lan;

            var movingPiece = new Piece(EPieces.WhiteKnight);
            var fromOneSquare = new Square(ESquare.d2);
            var fromTwoSquare = new Square(ESquare.f2);
            var toSquare = new Square(ESquare.e4);

            var uniChar = movingPiece.GetPieceChar();
            var toSquareString = toSquare.GetSquareString();

            var expectedPrimary = $"{uniChar}{fromOneSquare.GetSquareString()}-{toSquareString}";
            var expectedSecondary = $"{uniChar}{fromTwoSquare.GetSquareString()}-{toSquareString}";

            var g = new Game();
            g.NewGame(fen);

            var w1 = new Move(movingPiece, fromOneSquare, toSquare);
            var w2 = new Move(movingPiece, fromTwoSquare, toSquare);

            var actualPrimary = w1.ToNotation(g.State, notation);
            var actualSecondary = w2.ToNotation(g.State, notation);

            Assert.Equal(expectedPrimary, actualPrimary);
            Assert.Equal(expectedSecondary, actualSecondary);
        }

        [Fact]
        public void LanRankFileAmbiguationPositiveTest()
        {
            // Tests both knights moving to same square for Rank ambiguity

            const string fen = "8/6k1/8/8/8/8/1K1N1N2/8 w - - 0 1";
            const EMoveNotation notation = EMoveNotation.Lan;

            var movingPiece = new Piece(EPieces.WhiteKnight);
            var fromOneSquare = new Square(ESquare.d2);
            var fromTwoSquare = new Square(ESquare.g5);
            var toSquare = new Square(ESquare.e4);

            var uniChar = movingPiece.GetPieceChar();
            var toSquareString = toSquare.GetSquareString();

            var expectedPrimary = $"{uniChar}{fromOneSquare.GetSquareString()}-{toSquareString}";
            var expectedSecondary = $"{uniChar}{fromTwoSquare.GetSquareString()}-{toSquareString}";

            var g = new Game();
            g.NewGame(fen);

            var w1 = new Move(movingPiece, fromOneSquare, toSquare);
            var w2 = new Move(movingPiece, fromTwoSquare, toSquare);

            var actualPrimary = w1.ToNotation(g.State, notation);
            var actualSecondary = w2.ToNotation(g.State, notation);

            Assert.Equal(expectedPrimary, actualPrimary);
            Assert.Equal(expectedSecondary, actualSecondary);
        }

        [Fact]
        public void LanFileAmbiguationPositiveTest()
        {
            // Tests both knights moving to same square for File ambiguity

            const string fen = "8/6k1/8/8/3N4/8/1K1N4/8 w - - 0 1";
            const EMoveNotation notation = EMoveNotation.Lan;

            var movingPiece = new Piece(EPieces.WhiteKnight);
            var fromOneSquare = new Square(ESquare.d2);
            var fromTwoSquare = new Square(ESquare.d4);
            var toSquare = new Square(ESquare.f3);

            var uniChar = movingPiece.GetPieceChar();
            var toSquareString = toSquare.GetSquareString();

            var expectedPrimary = $"{uniChar}{fromOneSquare.GetSquareString()}-{toSquareString}";
            var expectedSecondary = $"{uniChar}{fromTwoSquare.GetSquareString()}-{toSquareString}";

            var g = new Game();
            g.NewGame(fen);

            var w1 = new Move(movingPiece, fromOneSquare, toSquare);
            var w2 = new Move(movingPiece, fromTwoSquare, toSquare);

            var actualPrimary = w1.ToNotation(g.State, notation);
            var actualSecondary = w2.ToNotation(g.State, notation);

            Assert.Equal(expectedPrimary, actualPrimary);
            Assert.Equal(expectedSecondary, actualSecondary);
        }

        [Fact]
        public void RanRankAmbiguationPositiveTest()
        {
            // Tests both knights moving to same square for Rank ambiguity

            const string fen = "8/6k1/8/8/8/8/1K1N1N2/8 w - - 0 1";
            const EMoveNotation notation = EMoveNotation.Ran;

            var movingPiece = new Piece(EPieces.WhiteKnight);
            var fromOneSquare = new Square(ESquare.d2);
            var fromTwoSquare = new Square(ESquare.f2);
            var toSquare = new Square(ESquare.e4);

            var uniChar = movingPiece.GetPieceChar();
            var toSquareString = toSquare.GetSquareString();

            var expectedPrimary = $"{uniChar}{fromOneSquare.GetSquareString()}-{toSquareString}";
            var expectedSecondary = $"{uniChar}{fromTwoSquare.GetSquareString()}-{toSquareString}";

            var g = new Game();
            g.NewGame(fen);

            var w1 = new Move(movingPiece, fromOneSquare, toSquare);
            var w2 = new Move(movingPiece, fromTwoSquare, toSquare);

            var actualPrimary = w1.ToNotation(g.State, notation);
            var actualSecondary = w2.ToNotation(g.State, notation);

            Assert.Equal(expectedPrimary, actualPrimary);
            Assert.Equal(expectedSecondary, actualSecondary);
        }

        [Fact]
        public void RanRankFileAmbiguationPositiveTest()
        {
            // Tests both knights moving to same square for Rank ambiguity

            const string fen = "8/6k1/8/8/8/8/1K1N1N2/8 w - - 0 1";
            const EMoveNotation notation = EMoveNotation.Ran;

            var movingPiece = new Piece(EPieces.WhiteKnight);
            var fromOneSquare = new Square(ESquare.d2);
            var fromTwoSquare = new Square(ESquare.g5);
            var toSquare = new Square(ESquare.e4);

            var uniChar = movingPiece.GetPieceChar();
            var toSquareString = toSquare.GetSquareString();

            var expectedPrimary = $"{uniChar}{fromOneSquare.GetSquareString()}-{toSquareString}";
            var expectedSecondary = $"{uniChar}{fromTwoSquare.GetSquareString()}-{toSquareString}";

            var g = new Game();
            g.NewGame(fen);

            var w1 = new Move(movingPiece, fromOneSquare, toSquare);
            var w2 = new Move(movingPiece, fromTwoSquare, toSquare);

            var actualPrimary = w1.ToNotation(g.State, notation);
            var actualSecondary = w2.ToNotation(g.State, notation);

            Assert.Equal(expectedPrimary, actualPrimary);
            Assert.Equal(expectedSecondary, actualSecondary);
        }

        [Fact]
        public void RanFileAmbiguationPositiveTest()
        {
            // Tests both knights moving to same square for File ambiguity

            const string fen = "8/6k1/8/8/3N4/8/1K1N4/8 w - - 0 1";
            const EMoveNotation notation = EMoveNotation.Ran;

            var movingPiece = new Piece(EPieces.WhiteKnight);
            var fromOneSquare = new Square(ESquare.d2);
            var fromTwoSquare = new Square(ESquare.d4);
            var toSquare = new Square(ESquare.f3);

            var uniChar = movingPiece.GetPieceChar();
            var toSquareString = toSquare.GetSquareString();

            var expectedPrimary = $"{uniChar}{fromOneSquare.GetSquareString()}-{toSquareString}";
            var expectedSecondary = $"{uniChar}{fromTwoSquare.GetSquareString()}-{toSquareString}";

            var g = new Game();
            g.NewGame(fen);

            var w1 = new Move(movingPiece, fromOneSquare, toSquare);
            var w2 = new Move(movingPiece, fromTwoSquare, toSquare);

            var actualPrimary = w1.ToNotation(g.State, notation);
            var actualSecondary = w2.ToNotation(g.State, notation);

            Assert.Equal(expectedPrimary, actualPrimary);
            Assert.Equal(expectedSecondary, actualSecondary);
        }
    }
}