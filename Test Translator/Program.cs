using NekoTranslate;
using System.Text.Json;

namespace TranslatorApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var source = "en";
            var translate = "pl";
            var text = "hello, how are you?";
            var provider = "google";

            // Translate text from English to German using Google Translate
            var translatedText = await Translator.Translate(source, translate, text, provider);

            // Parse JSON and extract the translation
            var jsonDocument = JsonDocument.Parse(translatedText);
            var transNode = jsonDocument.RootElement.GetProperty("sentences")[0].GetProperty("trans");
            var translation = transNode.GetString();

            // Output the translated text
            Console.WriteLine("provider: " + provider);
            Console.WriteLine("Translate: " + source + " -> " + translate);
            Console.WriteLine("Text: " + text + " -> " + translation);
        }
    }
}
