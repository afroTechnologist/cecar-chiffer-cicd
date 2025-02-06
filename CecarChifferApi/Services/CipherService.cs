using System;
using System.Text;
using CecarChifferApi.Interfaces;

namespace CecarChifferApi.Services
{
    public class CipherService : ICipherService
    {
        // Metod för att kryptera text
        public string Encrypt(string input, int shift)
        {
            // Om texten är tom, returnera den direkt
            if (string.IsNullOrEmpty(input)) 
                return input;

            // Kontrollera att shift-värdet är giltigt (mellan 0 och 25)
            if (shift < 0 || shift > 25) 
                throw new ArgumentOutOfRangeException(nameof(shift), "Shift måste vara mellan 0 och 25");

            // Skapa en ny text-builder för resultatet
            StringBuilder resultat = new StringBuilder();

            // Gå igenom varje bokstav i input-texten
            foreach (char bokstav in input)
            {
                // Om det är en bokstav ska den förskjutas
                if (char.IsLetter(bokstav))
                {
                    // Bestäm om det är stor eller liten bokstav
                    char startBokstav = char.IsUpper(bokstav) ? 'A' : 'a';
                    
                    // Beräkna den nya positionen för bokstaven
                    int position = bokstav - startBokstav; // Gör om till position (0-25)
                    position = (position + shift) % 26;    // Lägg till shift och "wrappa runt"
                    char nyBokstav = (char)(position + startBokstav); // Gör om tillbaka till bokstav
                    
                    resultat.Append(nyBokstav);
                }
                else
                {
                    // Om det inte är en bokstav (t.ex. mellanslag eller punkt)
                    // lägg till den oförändrad
                    resultat.Append(bokstav);
                }
            }

            return resultat.ToString();
        }

        // Metod för att dekryptera text
        public string Decrypt(string input, int shift)
        {
            // Dekryptering är samma som kryptering fast åt andra hållet
            // Så vi använder samma logik men med negativt shift
            // Vi lägger till 26 för att undvika negativa tal
            return Encrypt(input, (26 - shift) % 26);
        }
    }
}