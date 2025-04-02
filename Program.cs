using System;
using System.Speech.Synthesis;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chatbot
{
    class Program
    {
        // Creating a speech synthesizer to make the bot talk
        static SpeechSynthesizer synthesizer = new SpeechSynthesizer();

        // Method to display an ASCII art logo at the start
        static void DisplayAsciiLogo()
        {
            Console.ForegroundColor = ConsoleColor.Blue; // Set text color to blue
            Console.WriteLine(@"
                                .-------------------------------------------.
                                |  ____ _           _   ____        _     _ |
                                | / ___| |__   __ _| |_| __ )  ___ | |_  | ||
                                || |   | '_ \ / _` | __|  _ \ / _ \| __| | ||
                                || |___| | | | (_| | |_| |_) | (_) | |_  |_||
                                | \____|_| |_|\__,_|\__|____/ \___/ \__| (*)|
                                '-------------------------------------------'
                                :/_/_/_/_////////////.|.\\\\\\\\\\_\_\_\_\_\:          
                               ");
            Console.ResetColor(); // Reset the console color after displaying the logo
        }

        static void Main()
        {
            // Show the chatbot's fancy ASCII logo
            DisplayAsciiLogo();

            // Set the console window title
            Console.Title = "Cybersecurity ChatBot";

            // Greet the user with a welcome message (both in text and speech)
            Console.WriteLine("Hello! Welcome to the Cybersecurity Awareness ChatBot.");
            Speak("Hello! Welcome to the Cybersecurity Awareness ChatBot.");

            // Ask for the user's name
            Console.Write("\nPlease enter your name: ");
            string name = GetUserInput();

            // Personalize the greeting with the user's name
            Speak($"Hello {name}, how can I help you today?");

            Console.ForegroundColor = ConsoleColor.Green; // Set bot response color
            Console.WriteLine($"\nHello {name}, how can I help you today?");
            Console.ResetColor(); // Reset color after bot's response

            // Keep the chatbot running until the user decides to exit
            while (true)
            {
                Console.Write("\nYou: ");
                string userInput = GetUserInput();

                // Check if the user wants to exit the chat
                if (userInput.ToLower() == "exit")
                {
                    Speak(" Goodbye! Stay safe online.");

                    Console.ForegroundColor = ConsoleColor.Green; // Set bot response color
                    Console.WriteLine("__________________________");//Displays an underscores above the bot's goodbye message
                    Console.WriteLine("Goodbye! Stay safe online.");
                    Console.WriteLine("__________________________");//Displays an underscores below the bot's goodbye message
                    Console.ResetColor(); // Reset color after bot's response

                    break; // End the conversation
                }

                // Get a chatbot response based on what the user says
                string botResponse = GetResponse(userInput);
                Speak(botResponse);

                Console.ForegroundColor = ConsoleColor.Green; // Set bot response color
                Console.WriteLine($"Bot: {botResponse}");
                Console.ResetColor(); // Reset color after bot's response
            }
        }

        // Method to handle user input and ensure it's not empty
        static string GetUserInput()
        {
            Console.ForegroundColor = ConsoleColor.Blue; // Set text color to blue
            string input = Console.ReadLine()?.Trim(); // Read user input and remove extra spaces
            Console.ResetColor(); // Reset the text color

            // Keep asking until the user enters something
            while (string.IsNullOrEmpty(input))
            {
                Speak("Invalid input. Please type something.");
                Console.ForegroundColor = ConsoleColor.Red; // Change text color to red for error message
                Console.WriteLine("Invalid input. Please type something.");
                Console.ResetColor();
                input = Console.ReadLine()?.Trim(); // Read again
            }

            return input; // Return the valid input
        }

        // Method to make the chatbot "talk" using text-to-speech
        static void Speak(string text)
        {
            synthesizer.Speak(text);
        }

        // Method to generate a chatbot response based on user input
        static string GetResponse(string input)
        {
            input = input.ToLower(); // Convert input to lowercase for case-insensitive matching

            // Predefined responses to common cybersecurity-related questions
            var responses = new Dictionary<string, string>
            {
                { "how are you", "I'm just a bot, but I'm here to help!" },
                { "purpose", "I'm here to teach you about cybersecurity awareness." },
                { "what can i ask", "You can ask about password safety, phishing, and safe browsing." },
                { "password", "Use strong passwords with at least 12 characters, including letters, numbers, and symbols." },
                { "phishing", "Be careful of emails or messages asking for personal information. Verify the source before clicking links." },
                { "safe browsing", "Use HTTPS websites, avoid downloading files from untrusted sources, and keep your software updated." }
            };

            // Check if the user's input contains any of the predefined keywords
            foreach (var pair in responses)
            {
                if (input.Contains(pair.Key))
                {
                    return pair.Value; // Return the matching response
                }
            }

            // If the input doesn't match anything,Bot ask the user to rephrase
            return "Sorry, I didn't quite understand that. Could you rephrase!";
        }
    }
}