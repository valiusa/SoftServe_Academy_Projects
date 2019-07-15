namespace ChessFigureProblem
{
    interface IFigure
    {
        char GetFight { get; }
        char GetLook { get; }
        char SetLook { set; }

        void SetPawnFightPos(ref byte posX, ref byte posY, ref byte count, char[,] board, byte size);
        void SetKnightFightPos(byte posX, byte posY, char[,] board, byte size);
        void SetBishopFightPos(byte posX, byte posY, char[,] board, byte size);
        void SetRookFightPos(byte posX, byte posY, char[,] board, byte size);
        void SetQueenFightPos(byte posX, byte posY, char[,] board, byte size);
        void SetKingFightPos(byte posX, byte posY, char[,] board, byte size);
    }
}
