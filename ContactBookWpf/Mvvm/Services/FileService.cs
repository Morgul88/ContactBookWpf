
using System.Diagnostics;
using System.IO;

namespace ContactBookWpf.Mvvm.Services;

/// <summary>
/// Fileservice klass. Hanterar min filservice
/// </summary>
public class FileService
{
    private readonly string _filePath;

    /// <summary>
    /// Konstruktor för FileService
    /// </summary>
    /// <param name="filePath"></param>
    public FileService(string filePath)
    {
        _filePath = filePath;
    }

    /// <summary>
    /// Tar fil från datorn och läser fil genom Streamreader
    /// </summary>
    /// <returns></returns>
    public string GetContentFromFile()
    {
        try
        {
            if (File.Exists(_filePath))
            {
                using var sr = new StreamReader(_filePath);
                {
                    return sr.ReadToEnd();
                }
            }
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;
    }

    /// <summary>
    /// Skapar en fil på min dator genom StreamWriter
    /// </summary>
    /// <param name="content"></param>
    /// <returns></returns>
    public bool SaveContentToFile(string content)
    {

        try
        {

            using (var sw = new StreamWriter(_filePath))
            {
                sw.WriteLine(content);
            }
            return true;
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return false;
    }
}
