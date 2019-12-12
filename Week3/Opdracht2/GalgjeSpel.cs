using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opdracht2
{
    class GalgjeSpel
    {
        public string geradenwoord = "";
        public string geheimwoord;
        public void Init(string geheimwoordin)
        {
            geheimwoord = geheimwoordin.ToLower();
            for (int i = 0; i < geheimwoord.Length; i++)
                geradenwoord += ".";
        }
        public bool RaadLetter(char letter)
        {
            if (geheimwoord.Contains(letter))
            {
                string tempgeheim = "";

                for (int i = 0; i < geheimwoord.Length; i++)
                {
                    if (geradenwoord[i] != '.')
                        tempgeheim += geradenwoord[i];

                    else if (geheimwoord[i] == letter)
                        tempgeheim += letter;

                    else
                        tempgeheim += '.';
                }

                geradenwoord = tempgeheim;
                return true;
            }
            else
                return false;
        }
        public bool IsGeraden()
        {
            if (geradenwoord == geheimwoord)
                return true;
            else
                return false;
        }
    }
}
