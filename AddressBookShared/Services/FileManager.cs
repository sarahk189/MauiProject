using AddressBookShared.Interfaces;
using System.Diagnostics;

namespace AddressBookShared.Services;

public class FileManager : IFileManager
{
    public string GetContentFromFile(string filePath)
    {
        try
        {
            if (File.Exists(filePath))
            {
                return File.ReadAllText(filePath);
            }
        }
        catch (Exception ex) { Debug.WriteLine("FileManager - ReadContentFromFile: " + ex.Message); }
        return null!;
    }

 
    public bool SaveContentToFile(string filePath, string content)
    {
        try
        {
            using var sw = new StreamWriter(filePath);
            sw.Write(content);
            return true;
        }
        catch (Exception ex) { Debug.WriteLine("FileManager - SaveContentToFile: " + ex.Message); }
        return false;
    }
}
