using System.Text;

NotesManager manager = new NotesManager();

bool running = true;
while (true)
{
    Console.WriteLine("=== МЕНЮ ===");
    Console.WriteLine("1. Створити нову нотатку");
    Console.WriteLine("2. Переглянути всі нотатки");
    Console.WriteLine("3. Відкрити нотатку");
    Console.WriteLine("4. Редагувати нотатку");
    Console.WriteLine("5. Видалити нотатку");
    Console.WriteLine("6. Інформація про файл");
    Console.WriteLine("7. Вийти");
    Console.Write("Ваш вибір: ");

    string choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            manager.CreateNotes();
            break;
        case "2":
            manager.ViewAllNotes();
            break;
        case "3":
            Console.Write("Введіть назву нотатки: ");
            manager.ViewNote(Console.ReadLine());
            break;
        case "4":
            Console.Write("Введіть назву нотатки: ");
            manager.EditNote(Console.ReadLine());
            break;
        case "5":
            Console.Write("Введіть назву нотатки: ");
            manager.DeleteNote(Console.ReadLine());
            break;
        case "6":
            Console.Write("Введіть назву нотатки: ");
            manager.ShowFileInfo(Console.ReadLine());
            break;
        case "7":
            Console.WriteLine("До зустрічі!");
            running = false;
            break;
        default:
            Console.WriteLine("Невідомий вибір. Спробуйте ще раз.");
            break;

    }
}

class NotesManager
{
    private string folderPath = @"D:/Notes/";

    public void CreateNotes()
    {
        Console.WriteLine("Enter name of note: ");
        string name = Console.ReadLine();
        Console.WriteLine("Enter your content of note: ");
        string content = Console.ReadLine();
        
        DirectoryInfo directory = new DirectoryInfo(folderPath);
        if (!directory.Exists)
        {
            directory.Create();
        }
        string filePath = Path.Combine(folderPath, name + ".txt");
        File.WriteAllText(filePath, content);
        Console.WriteLine("Note created");
    }

    public void ViewAllNotes()
    {
        string[] files = Directory.GetFiles(folderPath);
        Console.WriteLine("Your files: ");
        foreach (string file in files)
        {
            Console.WriteLine(file);
        }
    }

    public void ViewNote(string name)
    {
        string[] file = Directory.GetFiles(folderPath, name + ".txt");
        if (file.Length == 0)
        {
            Console.WriteLine("File is not found");
            return;
        }
        Console.WriteLine(file[0]);
        string content = File.ReadAllText(file[0]);
        Console.WriteLine(content);
    }

    public void DeleteNote(string name)
    {
        string[] file = Directory.GetFiles(folderPath, name + ".txt");
        if (file.Length == 0)
        {
            Console.WriteLine("File not found");
            return;
        }

        foreach (string f in file)
        {
            try
            {
                File.Delete(f);
                Console.WriteLine("File is deleted");
            }
            catch (Exception e)
            {
                Console.WriteLine("File is not deleted");
            }
        }
    }

    public void EditNote(string name)
    {
        string[] file = Directory.GetFiles(folderPath, name + ".txt");
        if (file.Length == 0)
        {
            Console.WriteLine("File not found");
            return;
        }
        Console.WriteLine("Enter text to append to the note:  ");
        string content = Console.ReadLine();
        File.AppendAllText(Path.Combine(folderPath, name + ".txt"), content);
    }

    public void ShowFileInfo(string name)
    {
        string[] files = Directory.GetFiles(folderPath, name + ".txt");

        if (files.Length == 0)
        {
            Console.WriteLine("File not found");
            return;
        }

        FileInfo info = new FileInfo(files[0]);
        Console.WriteLine("📄 File Info:");
        Console.WriteLine($"Name: {info.Name}");
        Console.WriteLine($"Path: {info.FullName}");
        Console.WriteLine($"Size: {info.Length} bytes");
        Console.WriteLine($"Created: {info.CreationTime}");
        Console.WriteLine($"Last Modified: {info.LastWriteTime}");
        Console.WriteLine($"Extension: {info.Extension}");
    }
    
}
    



