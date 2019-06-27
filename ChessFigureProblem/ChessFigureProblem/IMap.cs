namespace ChessFigureProblem
{
    interface IMap
    {
        byte GetSize { get; }

        void ShowMap(char look);
        void SetOnMap(byte posX, byte posY, char look);

        void SetPawnFightPos(ref byte posX,ref byte posY, char look);
        void SetKnightFightPos(byte posX, byte posY);
        void SetBishopFightPos(byte posX, byte posY);
        void SetRookFightPos(byte posX, byte posY);
        void SetQueenFightPos(byte posX, byte posY);
        void SetKingFightPos(byte posX, byte posY);

        bool IsFreeSpace(byte posX, byte posY, char look);
    }
}
