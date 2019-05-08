using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        ApiManager mess1 = new ApiManager(new SMSFactory());
        mess1.SendMess();
        mess1.AlertExpansion();

        ApiManager mess2 = new ApiManager(new AudioFactory());
        mess2.SendMess();
        mess2.AlertExpansion();

        ApiManager mess3 = new ApiManager(new VideoFactory());
        mess3.SendMess();
        mess3.AlertExpansion();

        Console.ReadLine();
    }
}
//абстрактный тип сообщенния
abstract class TypeOfMessege
{
    public abstract void SendMess();
}
// абстрактный класс разришение 
abstract class Expansion
{
    public abstract void AlertExpansion();
}

// класс SMS
class SimpleMessege : TypeOfMessege
{
    public override void SendMess()
    {
        Console.WriteLine("Type: You are send SMS");
    }
}
// класс видео сообщение
class  VideoMessege : TypeOfMessege
{
    public override void SendMess()
    {
        Console.WriteLine("Type: You are send Video messege");
    }
}
// класс  аудио сообщение
class AudioMessege : TypeOfMessege
{
    public override void SendMess()
    {
        Console.WriteLine("Type: You are send Audio messege");
    }
}
// формат текст
class TxtFormat : Expansion
{
    public override void AlertExpansion()
    {
        Console.WriteLine("Fromat: .txt");
    }
}
// формат мп4
class Mp4Format : Expansion
{
    public override void AlertExpansion()
    {
        Console.WriteLine("Fromat: .mp4");
    }
}
// формат мп3
class Mp3Format : Expansion
{
    public override void AlertExpansion()
    {
        Console.WriteLine("Fromat: .mp3");
    }
}

// класс абстрактной фабрики
abstract class Messege
{
    public abstract TypeOfMessege CreateType();
    public abstract Expansion CreateExpansion();
}
// Фабрика создания летящего героя с арбалетом
class SMSFactory : Messege
{
    public override Expansion CreateExpansion()
    {
        return new TxtFormat();
    }

    public override TypeOfMessege CreateType()
    {
        return new SimpleMessege();
    }
}
// Фабрика видео сообщения с форматом мп4
class VideoFactory : Messege
{
    public override Expansion CreateExpansion()
    {
        return new Mp4Format();
    }

    public override TypeOfMessege CreateType()
    {
        return new VideoMessege();
    }
}

class AudioFactory : Messege
{
    public override Expansion CreateExpansion()
    {
        return new Mp3Format();
    }

    public override TypeOfMessege CreateType()
    {
        return new AudioMessege();
    }
}
// клиент - сам супергерой
class ApiManager
{
    private TypeOfMessege typeofmessege;
    private Expansion expansion;
    public ApiManager(Messege factory)
    {
        typeofmessege = factory.CreateType();
        expansion = factory.CreateExpansion();
    }
    public void AlertExpansion()
    {
        expansion.AlertExpansion();
    }
    public void SendMess()
    {
        typeofmessege.SendMess();
    }
}





