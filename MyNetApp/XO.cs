public class XO
{
    private Dictionary<int, char> xo;

    public XO()
    {
        xo = new Dictionary<int, char>();
        foreach (int n in Enumerable.Range(1, 9))
            xo[n] = '.';
    }

    private bool IsWin()
    {
        if (xo[1] == 'x' && xo[2] == 'x' && xo[3] == 'x') {Console.WriteLine("You win!"); return true;}
        if (xo[4] == 'x' && xo[5] == 'x' && xo[6] == 'x') {Console.WriteLine("You win!"); return true;}
        if (xo[7] == 'x' && xo[8] == 'x' && xo[9] == 'x') {Console.WriteLine("You win!"); return true;}

        if (xo[1] == 'x' && xo[4] == 'x' && xo[7] == 'x') {Console.WriteLine("You win!"); return true;}
        if (xo[2] == 'x' && xo[5] == 'x' && xo[8] == 'x') {Console.WriteLine("You win!"); return true;}
        if (xo[3] == 'x' && xo[6] == 'x' && xo[9] == 'x') {Console.WriteLine("You win!"); return true;}

        if (xo[1] == 'x' && xo[5] == 'x' && xo[9] == 'x') {Console.WriteLine("You win!"); return true;}
        if (xo[3] == 'x' && xo[5] == 'x' && xo[7] == 'x') {Console.WriteLine("You win!"); return true;}
        return false;
    }
    private bool Islose()
    {
        if (xo[1] == 'o' && xo[2] == 'o' && xo[3] == 'o') {Console.WriteLine("You lose!"); return true;}
        if (xo[4] == 'o' && xo[5] == 'o' && xo[6] == 'o') {Console.WriteLine("You lose!"); return true;}
        if (xo[7] == 'o' && xo[8] == 'o' && xo[9] == 'o') {Console.WriteLine("You lose!"); return true;}

        if (xo[1] == 'o' && xo[4] == 'o' && xo[7] == 'o') {Console.WriteLine("You lose!"); return true;}
        if (xo[2] == 'o' && xo[5] == 'o' && xo[8] == 'o') {Console.WriteLine("You lose!"); return true;}
        if (xo[3] == 'o' && xo[6] == 'o' && xo[9] == 'o') {Console.WriteLine("You lose!"); return true;}

        if (xo[1] == 'o' && xo[5] == 'o' && xo[9] == 'o') {Console.WriteLine("You lose!"); return true;}
        if (xo[3] == 'o' && xo[5] == 'o' && xo[7] == 'o') {Console.WriteLine("You lose!"); return true;}
        return false;
    }

    public void Game()
    {
        PrintXO();
        while (true)
        {
            if (IsFoolXO()) return;
            UserPlay();
            PrintXO();

            if (IsWin()) return;

            if (IsFoolXO()) return;
            EnemyPlay();
            PrintXO();

            if (Islose()) return;
        }
    }

    private void PrintXO()
    {
        Console.WriteLine("| " + xo[1] + " | " + xo[2] + " | " + xo[3] + " |");
        Console.WriteLine("| " + xo[4] + " | " + xo[5] + " | " + xo[6] + " |");
        Console.WriteLine("| " + xo[7] + " | " + xo[8] + " | " + xo[9] + " |");
    }

    private void UserPlay()
    {
        while (true)
        {
            Console.Write("Введите номер ячейки: ");
            if (int.TryParse(Console.ReadLine(), out int u) && xo.ContainsKey(u) && xo[u] == '.')
            {
                xo[u] = 'x';
                break;
            }
        }
    }

    private void EnemyPlay()
    {
        Random random = new Random();
        while (true)
        {
            int n = random.Next(1, 10);
            if (xo[n] == '.')
            {
                Console.WriteLine("Ход противника: " + n);
                xo[n] ='o';
                break;
            }
        }
    }

    private bool IsFoolXO()
    {
        if (!xo.ContainsValue('.'))
        {
            Console.WriteLine("Ничья!");
            return true;
        }
        return false;
    }
}