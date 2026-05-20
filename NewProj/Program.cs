PrintMainDiagonal(8);
Console.WriteLine(Rook(0, 0, 0, 5));
Console.WriteLine(Knight(1, 2, 2, 4));
Console.WriteLine(KnightMinPath(1, 2, 4, 4));
Console.WriteLine(Bishop(1, 1, 4, 4));
Console.WriteLine(BishopBlocked(5, 0, 1, 4, 3, 2));
Console.WriteLine(string.Join(", ", BishopMoves(5,0, 3, 2)));
void PrintMainDiagonal(int matrixSize)
{
    char[,] mtx = new char[matrixSize, matrixSize];

    for (int i = 0; i < matrixSize; i++)
    {
        for (int j = 0; j < matrixSize; j++)
        {
            mtx[i, j] = '*';

            if (i == j)
            {
                mtx[i, j] = '-';
            }

            if (i + j == matrixSize - 1)
            {
                mtx[i, j] = '~';
            }
        }
    }

    for (int i = 0; i < matrixSize; i++)
    {
        for (int j = 0; j < matrixSize; j++)
        {
            Console.Write(mtx[i, j] + " ");
        }
        Console.WriteLine();
    }

}

///Rook
bool Rook(int x1, int y1, int x2, int y2)
{
    return x1 == x2 || y1 == y2;
}

///Knight
bool Knight(int x1, int y1, int x2, int y2)
{
    int dx = Math.Abs(x2 - x1);
    int dy = Math.Abs(y2 - y1);

    return dx * dy == 2;
}

int KnightMinPath(int x1, int y1, int x2, int y2)
{
    int[] dx = { 1, 1, -1, -1, 2, 2, -2, -2 };
    int[] dy = { 2, -2, 2, -2, 1, -1, 1, -1 };

    int[,] distance = new int[8, 8];  
    for (int i = 0; i < 8; i++)
        for (int j = 0; j < 8; j++)
            distance[i, j] = -1;

    distance[x1, y1] = 0;

    for (int step = 0; step < 63; step++)
        for (int x = 0; x < 8; x++)
            for (int y = 0; y < 8; y++)
                if (distance[x, y] == step)
                    for (int i = 0; i < 8; i++)
                    {
                        int nextX = x + dx[i];
                        int nextY = y + dy[i];
                        if (nextX >= 0 && nextX < 8 && nextY >= 0 && nextY < 8 && distance[nextX, nextY] == -1)
                            distance[nextX, nextY] = step + 1;
                    }

    return distance[x2, y2];
}


///Bishop
bool Bishop(int x1, int y1, int x2, int y2)
{
    return Math.Abs(x1 - x2) == Math.Abs(y1 - y2);
}

bool BishopBlocked(int x1, int y1, int x2, int y2, int ox, int oy)
{
    if (Math.Abs(x1 - x2) != Math.Abs(y1 - y2))
        return false;

    if (Math.Abs(ox - x1) == Math.Abs(oy - y1) && Math.Abs(ox - x1) < Math.Abs(x2 - x1))
        return false;

    return true;
}

List<(int, int)> BishopMoves(int x1, int y1, int ox, int oy)
{
    List<(int, int)> moves = new List<(int, int)>();

    int[] dx = { 1, 1, -1, -1 };
    int[] dy = { 1, -1, 1, -1 };

    for (int i = 0; i < 4; i++)
    {
        int x = x1 + dx[i];
        int y = y1 + dy[i];

        while (x >= 0 && x < 8 && y >= 0 && y < 8)
        {
            if (x == ox && y == oy)
                break;

            moves.Add((x, y));
            x += dx[i];
            y += dy[i];
        }
    }

    return moves;
}
