using System.Diagnostics;

Console.OutputEncoding = System.Text.Encoding.UTF8;

Stopwatch start = new Stopwatch();
bool exit = true;
string tenGame = "Game Đoán Số";

while (exit)
{
    KetQua(start, tenGame);
    //NguoiChoiChon();
    if (NguoiChoiChon() == 'y')
    {
        exit = true;
    }
    else
    {
        exit = false;
    }
}

static void HuongDanGame(string tenGame)
{
    Console.WriteLine($"Chào mừng bạn đã đến với {tenGame}");
    Console.WriteLine("Chúng ta hãy cùng nhau tìm hiểu luật chơi nhé!");
    Console.WriteLine("Bạn sẽ có 3 lượt đoán trong 1 lần chơi. Nếu bạn đoán đúng trong lần chơi thứ nhất thì " +
        "sẽ cho Win ngay lập tức không cần đến lượt đoán 2 và 3");
}

static int GiaTriNhapVao()
{
    //HuongDanGame();
    int soHopLe;
    while (true)
    {
        Console.WriteLine("Mời bạn nhập vào một số bạn đoán nó là đúng: ");

        string userInput = Console.ReadLine();
        if (int.TryParse(userInput, out soHopLe))
        {
            if (soHopLe <= 0 || soHopLe > 100)
            {
                Console.WriteLine("Hãy nhập một số có giá trị nằm trong khoảng 1 - 100!!!");
                Console.WriteLine("Giá trị bạn đã nhập là: " + userInput);
            }
            else
            {
                Console.WriteLine("Giá trị bạn đã nhập là: " + userInput);
                return soHopLe;
            }
        }
        else
        {
            Console.WriteLine($"Phải là một số nguyên có giá trị từ 1 - 100!!!\nGiá trị bạn đã nhập là: {userInput}");
        }

    }
}
static int SoNgauNhien()
{
    Random random = new Random();
    int numberRandom = random.Next(1, 101);
    return numberRandom;
}

static bool SoSanh(int soNgauNhien, int soNguoiChoiDoan, int soluotchoi)
{
    if (soNgauNhien < soNguoiChoiDoan)
    {
        Console.WriteLine($"Số của bạn đoán lớn hơn số của chương trình đưa ra!");
        Console.WriteLine($"Bạn đã đoán sai {soluotchoi} / 3, bạn còn {3 - soluotchoi} lượt đoán!");
        return false;
    }
    else if (soNgauNhien > soNguoiChoiDoan)
    {
        Console.WriteLine("Số của bạn đoán nhỏ hơn số của chương trình đưa ra!");
        Console.WriteLine($"Bạn đã đoán sai {soluotchoi} / 3, bạn còn {3 - soluotchoi} lượt đoán!");
        return false;
    }
    else
    {
        Console.WriteLine($"Bạn đã đoán đúng!\nSố chương trình cho là: {soNgauNhien}");
        return true;
    }
}

static void KetQua(Stopwatch st, string tenGame)
{
    Console.Clear();
    HuongDanGame(tenGame);
    st.Reset();
    st.Start();
    int soNgauNhien = SoNgauNhien();
    int soLuotChoi = 0;
    while (soLuotChoi < 3)
    {
        int soNguoiChoiDoan = GiaTriNhapVao();
        soLuotChoi++;
        if (SoSanh(soNgauNhien, soNguoiChoiDoan, soLuotChoi))
        {
            Console.WriteLine($"Bạn đã thắng ở lượt: {soLuotChoi}");
            st.Stop();
            Console.WriteLine($"Thời gian bạn chơi: {st.Elapsed.TotalSeconds:F2} giây.");
            return;
        }
    }
    Console.WriteLine($"Bạn đã thua! Số đúng là: {soNgauNhien}");
    st.Stop();
    Console.WriteLine($"Thời gian bạn chơi: {st.Elapsed.TotalSeconds:F2} giây.");
}

static char NguoiChoiChon()
{

    char chonChoi;
    while (true)
    {
        Console.WriteLine("Bạn có muốn tiếp tục chơi ván mới không? Nếu muốn hãy ấn Y/y Nếu không hãy ấn N/n!");
        string choosePlayer = Console.ReadLine().ToLower();
        if (char.TryParse(choosePlayer, out chonChoi))
        {
            if (chonChoi == 'y')
            {
                Console.WriteLine("Bạn đã chọn chơi tiếp ván mới!");
                return chonChoi;
            }
            else if (chonChoi == 'n')
            {
                Console.WriteLine("Bạn đã lựa chọn không chơi tiếp @@@");
                Console.WriteLine("Cảm ơn bạn đã chơi trò chơi.\nXin chào và hẹn gặp lại!");
                return chonChoi;
            }

            else
            {
                Console.WriteLine("Bạn phải nhập Y/y nếu chơi tiếp và N/n nếu bạn không chơi tiếp!");
            }
        }
        else
        {
            Console.WriteLine("Bạn phải nhập ký tự Y/y hoặc N/n!!!");
        }
    }
}




