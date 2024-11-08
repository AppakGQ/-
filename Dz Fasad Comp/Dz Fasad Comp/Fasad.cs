using System;

public class TV
{
    public void TurnOn() => Console.WriteLine("TV is on");
    public void TurnOff() => Console.WriteLine("TV is off");
    public void SetChannel(int channel) => Console.WriteLine($"TV channel set to {channel}");
}

public class AudioSystem
{
    public void TurnOn() => Console.WriteLine("Audio system is on");
    public void TurnOff() => Console.WriteLine("Audio system is off");
    public void SetVolume(int level) => Console.WriteLine($"Volume set to {level}");
}

public class DVDPlayer
{
    public void Play() => Console.WriteLine("DVD is playing");
    public void Pause() => Console.WriteLine("DVD is paused");
    public void Stop() => Console.WriteLine("DVD is stopped");
}

public class GameConsole
{
    public void TurnOn() => Console.WriteLine("Game console is on");
    public void StartGame() => Console.WriteLine("Game is starting");
}

public class HomeTheaterFacade
{
    private TV tv;
    private AudioSystem audio;
    private DVDPlayer dvd;
    private GameConsole console;

    public HomeTheaterFacade(TV tv, AudioSystem audio, DVDPlayer dvd, GameConsole console)
    {
        this.tv = tv;
        this.audio = audio;
        this.dvd = dvd;
        this.console = console;
    }

    public void WatchMovie()
    {
        tv.TurnOn();
        audio.TurnOn();
        dvd.Play();
        Console.WriteLine("Movie mode is on");
    }

    public void StopMovie()
    {
        dvd.Stop();
        audio.TurnOff();
        tv.TurnOff();
        Console.WriteLine("Movie mode is off");
    }

    public void PlayGame()
    {
        console.TurnOn();
        tv.TurnOn();
        console.StartGame();
        Console.WriteLine("Game mode is on");
    }

    public void ListenToMusic()
    {
        tv.TurnOn();
        audio.TurnOn();
        audio.SetVolume(20);
        Console.WriteLine("Music mode is on");
    }

    public void SetVolume(int level) => audio.SetVolume(level);

    public void TurnOffAll()
    {
        tv.TurnOff();
        audio.TurnOff();
        dvd.Stop();
        console.TurnOn();
        Console.WriteLine("All systems off");
    }
}

public class Fasad
{
    public static void Main()
    {
        var tv = new TV();
        var audio = new AudioSystem();
        var dvd = new DVDPlayer();
        var console = new GameConsole();

        var theater = new HomeTheaterFacade(tv, audio, dvd, console);

        theater.WatchMovie();
        theater.SetVolume(15);
        theater.StopMovie();
        theater.PlayGame();
        theater.ListenToMusic();
        theater.TurnOffAll();
    }
}
