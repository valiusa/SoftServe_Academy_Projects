﻿namespace ChessFigureProblem
{
    interface IMap
    {
        byte GetSize { get; }

        void ShowMap(char look);
        void SetOnMap(byte posX, byte posY, char look, ref byte count);
        void SetUserOnMap(byte posX, byte posY, char look, string moves, byte spaces, ref byte countFigure);
        void ClearMap();

        void SetPawnFightPos(ref byte posX,ref byte posY, char look, ref byte count);
        void SetKnightFightPos(byte posX, byte posY);
        void SetBishopFightPos(byte posX, byte posY);
        void SetRookFightPos(byte posX, byte posY);
        void SetQueenFightPos(byte posX, byte posY);
        void SetKingFightPos(byte posX, byte posY);
        void SetUserFightPos(ref byte posX, ref byte posY, string moves, byte spaces, char look, ref byte count);

        bool IsFreeSpace(byte posX, byte posY, char look);
        bool IsMapEmpty();
    }
}
