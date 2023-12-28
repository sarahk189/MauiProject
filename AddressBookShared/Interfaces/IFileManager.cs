namespace AddressBookShared.Interfaces;

public interface IFileManager
{
    /// <summary>
    /// Save content to the specific file path.
    /// </summary>
    /// <param name="filePath">Enter the file path with extension (ex. c:\projects\myfile.json) </param>
    /// <param name="content">Enter your content as a string</param>
    /// <returns>returns true if saved and false if failed</returns>
    bool SaveContentToFile(string filePath, string content);

    /// <summary>
    /// Get content as a string from a specific file path.
    /// </summary>
    /// <param name="filePath">Enter the file path with extension (ex. c:\projects\myfile.json) </param>
    /// <returns>returns file content as string if file exists else returns null.</returns>
    string GetContentFromFile(string filePath);
}
