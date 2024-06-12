using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class UserAccount
{
    public string name;
    public int rank;
    public float winRate;
    public string type;
    public int skin;
    public UserAccount(string _name,int _rank, float _winRate, string _type, int _skin)
    {
        name = _name;
        rank = _rank;
        winRate = _winRate;
        type = _type;
        skin = _skin;

    }
}
internal class Program
{
    static void Main(string[] args)
    {
        
        List<UserAccount> list = new List<UserAccount>();
        list.Add(new UserAccount("Sơn Tùng", 10, 55.5f, "Ca Nhạc", 50));
        list.Add(new UserAccount("Đen Vâu", 5, 70, "Ca Nhạc", 10));
        list.Add(new UserAccount("Độ Mixi", 1, 90, "ALL", 2));
        list.Add(new UserAccount("bà Tuyết Diamond", 3, 60.5f, "Âm thực", 10));
        list.Add(new UserAccount("PewPew", 4, 55.5f, "live", 50));
        list.Add(new UserAccount("Liên Minh", 2, 85.5f, "Game", 200));
        list.Add(new UserAccount("Liên Quân", 11, 55.5f, "Game", 200));
        list.Add(new UserAccount("Fifa 4", 9, 55.5f, "Game", 150));
        list.Add(new UserAccount("CSGO", 8, 55.5f, "Game", 1000));
        list.Add(new UserAccount("CSGO", 6, 85.5f, "Game", 500));

        Console.WriteLine();
        Console.WriteLine("Sắp xếp danh sách UserAccount theo “Rank” giảm dần ");
        var sortedDescendingRank = list.OrderByDescending(n => n.rank);
        Console.WriteLine("Mảng sau khi sắp xếp giảm dần:");
        foreach (var User in sortedDescendingRank)
        {
            Console.WriteLine(""+User.name+"|"+User.rank+"|"+User.winRate +"|"+User.type+ "|"+ User.skin);
        }

        Console.WriteLine();
        Console.WriteLine("Sắp xếp danh sách UserAccount theo “Name” và “Skin” giảm dần ");
        var sortedDescendingName = list.OrderByDescending(n => n.name).ThenBy(n=>n.skin);
        Console.WriteLine("Mảng sau khi sắp xếp giảm dần:");
        foreach (var User in sortedDescendingName)
        {
            Console.WriteLine("" + User.name + "|" + User.rank + "|" + User.winRate + "|" + User.type + "|" + User.skin);
        }


        Console.WriteLine();
        Console.WriteLine("Liệt kê danh sách các người có Name bắt đầu bằng ký tự “B” ");
        var StarWithB = list.Where(user=>user.name.StartsWith("b"));
        foreach (var User in StarWithB)
        {
            Console.WriteLine("" + User.name + "|" + User.rank + "|" + User.winRate + "|" + User.type + "|" + User.skin);
        }
        //
        Console.WriteLine();
        Console.WriteLine("Xuất ra màn hình danh sách các người có “WinRate” > 50 ");
        var WinRatehon50 = list.SkipWhile(user => user.winRate <= 50f);
        foreach (var User in WinRatehon50)
        {
            Console.WriteLine("" + User.name + "|" + User.rank + "|" + User.winRate + "|" + User.type + "|" + User.skin);
        }

        Console.WriteLine();
        Console.WriteLine("Tìm người có WinRate cao nhất");
        var highestWinRateUser = list.Aggregate((acc, x) => acc.winRate > x.winRate ? acc : x);
        Console.WriteLine("" + highestWinRateUser.name + "|" + highestWinRateUser.rank + "|" + highestWinRateUser.winRate + "|" + highestWinRateUser.type + "|" + highestWinRateUser.skin);


        Console.WriteLine();
        Console.WriteLine("Cho biết danh sách UserAccount có bao nhiêu tài khoản? ");
        var count = list.Count();
        Console.WriteLine("Số lượng tài khoản là: " + count);
        //
        var groupedByType = list.ToLookup(user => user.type);

        Console.WriteLine("Danh sách key/Count theo trường 'Type':");
        foreach (var group in groupedByType)
        {
            Console.WriteLine($"Type: {group.Key}, Count: {group.Count()}");
            foreach (var user in group)
            {
                Console.WriteLine($"Name: {user.name}, Rank: {user.rank}, WinRate: {user.winRate}, Skin: {user.skin}");
            }
            Console.WriteLine();
        }
    }
}
