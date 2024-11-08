using System;
using System.Collections.Generic;

public abstract class FileSystemComponent
{
    public string Name { get; protected set; }
    public abstract void Display(int depth = 0);
    public abstract int GetSize();
}

public class File : FileSystemComponent
{
    private int size;

    public File(string name, int size)
    {
        Name = name;
        this.size = size;
    }

    public override void Display(int depth = 0)
    {
        Console.WriteLine(new string('-', depth) + Name + " (File, " + size + " KB)");
    }

    public override int GetSize() => size;
}

public class Directory : FileSystemComponent
{
    private List<FileSystemComponent> components = new List<FileSystemComponent>();

    public Directory(string name)
    {
        Name = name;
    }

    public void Add(FileSystemComponent component)
    {
        if (!components.Contains(component))
            components.Add(component);
    }

    public void Remove(FileSystemComponent component)
    {
        if (components.Contains(component))
            components.Remove(component);
    }

    public override void Display(int depth = 0)
    {
        Console.WriteLine(new string('-', depth) + Name + " (Directory)");
        foreach (var component in components)
            component.Display(depth + 2);
    }

    public override int GetSize()
    {
        int totalSize = 0;
        foreach (var component in components)
            totalSize += component.GetSize();
        return totalSize;
    }
}

public class Program
{
    public static void Main()
    {
        var file1 = new File("File1.txt", 10);
        var file2 = new File("File2.txt", 20);
        var file3 = new File("File3.txt", 30);

        var dir1 = new Directory("Folder1");
        var dir2 = new Directory("Folder2");
        var dir3 = new Directory("Folder3");

        dir1.Add(file1);
        dir1.Add(dir2);
        dir2.Add(file2);
        dir2.Add(file3);
        dir3.Add(file1);

        var root = new Directory("Root");
        root.Add(dir1);
        root.Add(dir3);

        root.Display();
        Console.WriteLine("Total Size: " + root.GetSize() + " KB");
    }
}
