namespace ChessFigureProblem
{
    interface IMap
    {
        byte GetSize { get; }

        void ShowMap(char look);
        void SetOnMap(Point point, ChessFigure figure, ref byte count);
        void SetUserOnMap(Point point, CustomFigure figure, string moves, byte spaces, ref byte countFigure);
        void ClearMap();

        bool IsFreeSpace(byte posX, byte posY, ChessFigure figure);
        bool IsMapEmpty();
    }
}
