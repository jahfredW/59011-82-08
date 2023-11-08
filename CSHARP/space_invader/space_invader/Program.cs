// See https://aka.ms/new-console-template for more information
using space_invader;
using System;
using System.Threading.Tasks;

namespace space_invader;
class GameLoop
{
    private Space space;
    public async Task RunGame()
    {

        Console.CursorVisible = false;

        space = new Space(10, 10);

        space.display();

        do
        {
            Console.Clear();

            space.InvaderMove();

            space.display();

            var keyInfo = await Task.Run(() => Console.ReadKey(intercept: true));

            await HandleKey(keyInfo.Key);

            



        } while (true);


        

    }
    public async Task HandleKey(ConsoleKey key)
    {
        object value = await space.HandleKey(key);

    }



}

class Program
{
    static async Task Main()
    {
        var space_invader = new GameLoop();
        await space_invader.RunGame();
    }
}


