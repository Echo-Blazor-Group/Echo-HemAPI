﻿
using Echo_HemAPI.Data.Models;

namespace Echo_HemAPI.Helper
{
    //Author: Seb
    public static class SeedCounties
    {
        public static County[] GetCounties()
        {
            //All counties in Sweden
            return new[]
            {
                new County { CountyId = 1, CountyName = "Ale" },
                new County { CountyId = 2, CountyName = "Alingsås" },
                new County { CountyId = 3, CountyName = "Alvesta" },
                new County { CountyId = 4, CountyName = "Aneby" },
                new County { CountyId = 5, CountyName = "Arboga" },
                new County { CountyId = 6, CountyName = "Arjeplog" },
                new County { CountyId = 7, CountyName = "Arvidsjaur" },
                new County { CountyId = 8, CountyName = "Arvika" },
                new County { CountyId = 9, CountyName = "Askersund" },
                new County { CountyId = 10, CountyName = "Avesta" },
                new County { CountyId = 11, CountyName = "Bengtsfors" },
                new County { CountyId = 12, CountyName = "Berg" },
                new County { CountyId = 13, CountyName = "Bjurholm" },
                new County { CountyId = 14, CountyName = "Bjuv" },
                new County { CountyId = 15, CountyName = "Boden" },
                new County { CountyId = 16, CountyName = "Bollebygd" },
                new County { CountyId = 17, CountyName = "Bollnäs" },
                new County { CountyId = 18, CountyName = "Borgholm" },
                new County { CountyId = 19, CountyName = "Borlänge" },
                new County { CountyId = 20, CountyName = "Borås" },
                new County { CountyId = 21, CountyName = "Botkyrka" },
                new County { CountyId = 22, CountyName = "Boxholm" },
                new County { CountyId = 23, CountyName = "Bromölla" },
                new County { CountyId = 24, CountyName = "Bräcke" },
                new County { CountyId = 25, CountyName = "Burlöv" },
                new County { CountyId = 26, CountyName = "Båstad" },
                new County { CountyId = 27, CountyName = "Dals-Ed" },
                new County { CountyId = 28, CountyName = "Danderyd" },
                new County { CountyId = 29, CountyName = "Degerfors" },
                new County { CountyId = 30, CountyName = "Dorotea" },
                new County { CountyId = 31, CountyName = "Eda" },
                new County { CountyId = 32, CountyName = "Ekerö" },
                new County { CountyId = 33, CountyName = "Eksjö" },
                new County { CountyId = 34, CountyName = "Emmaboda" },
                new County { CountyId = 35, CountyName = "Enköping" },
                new County { CountyId = 36, CountyName = "Eskilstuna" },
                new County { CountyId = 37, CountyName = "Eslöv" },
                new County { CountyId = 38, CountyName = "Essunga" },
                new County { CountyId = 39, CountyName = "Fagersta" },
                new County { CountyId = 40, CountyName = "Falkenberg" },
                new County { CountyId = 41, CountyName = "Falköping" },
                new County { CountyId = 42, CountyName = "Falun" },
                new County { CountyId = 43, CountyName = "Filipstad" },
                new County { CountyId = 44, CountyName = "Finspång" },
                new County { CountyId = 45, CountyName = "Flen" },
                new County { CountyId = 46, CountyName = "Forshaga" },
                new County { CountyId = 47, CountyName = "Färgelanda" },
                new County { CountyId = 48, CountyName = "Gagnef" },
                new County { CountyId = 49, CountyName = "Gislaved" },
                new County { CountyId = 50, CountyName = "Gnesta" },
                new County { CountyId = 51, CountyName = "Gnosjö" },
                new County { CountyId = 52, CountyName = "Gotland" },
                new County { CountyId = 53, CountyName = "Grums" },
                new County { CountyId = 54, CountyName = "Grästorp" },
                new County { CountyId = 55, CountyName = "Gullspång" },
                new County { CountyId = 56, CountyName = "Gällivare" },
                new County { CountyId = 57, CountyName = "Gävle" },
                new County { CountyId = 58, CountyName = "Göteborg" },
                new County { CountyId = 59, CountyName = "Götene" },
                new County { CountyId = 60, CountyName = "Habo" },
                new County { CountyId = 61, CountyName = "Hagfors" },
                new County { CountyId = 62, CountyName = "Hallsberg" },
                new County { CountyId = 63, CountyName = "Hallstahammar" },
                new County { CountyId = 64, CountyName = "Halmstad" },
                new County { CountyId = 65, CountyName = "Hammarö" },
                new County { CountyId = 66, CountyName = "Haninge" },
                new County { CountyId = 67, CountyName = "Haparanda" },
                new County { CountyId = 68, CountyName = "Heby" },
                new County { CountyId = 69, CountyName = "Hedemora" },
                new County { CountyId = 70, CountyName = "Helsingborg" },
                new County { CountyId = 71, CountyName = "Herrljunga" },
                new County { CountyId = 72, CountyName = "Hjo" },
                new County { CountyId = 73, CountyName = "Hofors" },
                new County { CountyId = 74, CountyName = "Huddinge" },
                new County { CountyId = 75, CountyName = "Hudiksvall" },
                new County { CountyId = 76, CountyName = "Hultsfred" },
                new County { CountyId = 77, CountyName = "Hylte" },
                new County { CountyId = 78, CountyName = "Håbo" },
                new County { CountyId = 79, CountyName = "Hällefors" },
                new County { CountyId = 80, CountyName = "Härjedalen" },
                new County { CountyId = 81, CountyName = "Härnösand" },
                new County { CountyId = 82, CountyName = "Härryda" },
                new County { CountyId = 83, CountyName = "Hässleholm" },
                new County { CountyId = 84, CountyName = "Höganäs" },
                new County { CountyId = 85, CountyName = "Högsby" },
                new County { CountyId = 86, CountyName = "Hörby" },
                new County { CountyId = 87, CountyName = "Höör" },
                new County { CountyId = 88, CountyName = "Jokkmokk" },
                new County { CountyId = 89, CountyName = "Järfälla" },
                new County { CountyId = 90, CountyName = "Jönköping" },
                new County { CountyId = 91, CountyName = "Kalix" },
                new County { CountyId = 92, CountyName = "Kalmar" },
                new County { CountyId = 93, CountyName = "Karlsborg" },
                new County { CountyId = 94, CountyName = "Karlshamn" },
                new County { CountyId = 95, CountyName = "Karlskoga" },
                new County { CountyId = 96, CountyName = "Karlskrona" },
                new County { CountyId = 97, CountyName = "Karlstad" },
                new County { CountyId = 98, CountyName = "Katrineholm" },
                new County { CountyId = 99, CountyName = "Kil" },
                new County { CountyId = 100, CountyName = "Kinda" },
                new County { CountyId = 101, CountyName = "Kiruna" },
                new County { CountyId = 102, CountyName = "Klippan" },
                new County { CountyId = 103, CountyName = "Knivsta" },
                new County { CountyId = 104, CountyName = "Kramfors" },
                new County { CountyId = 105, CountyName = "Kristianstad" },
                new County { CountyId = 106, CountyName = "Kristinehamn" },
                new County { CountyId = 107, CountyName = "Krokom" },
                new County { CountyId = 108, CountyName = "Kumla" },
                new County { CountyId = 109, CountyName = "Kungsbacka" },
                new County { CountyId = 110, CountyName = "Kungsör" },
                new County { CountyId = 111, CountyName = "Kungälv" },
                new County { CountyId = 112, CountyName = "Kävlinge" },
                new County { CountyId = 113, CountyName = "Köping" },
                new County { CountyId = 114, CountyName = "Laholm" },
                new County { CountyId = 115, CountyName = "Landskrona" },
                new County { CountyId = 116, CountyName = "Laxå" },
                new County { CountyId = 117, CountyName = "Lekeberg" },
                new County { CountyId = 118, CountyName = "Leksand" },
                new County { CountyId = 119, CountyName = "Lerum" },
                new County { CountyId = 120, CountyName = "Lessebo" },
                new County { CountyId = 121, CountyName = "Lidingö" },
                new County { CountyId = 122, CountyName = "Lidköping" },
                new County { CountyId = 123, CountyName = "Lilla Edet" },
                new County { CountyId = 124, CountyName = "Lindesberg" },
                new County { CountyId = 125, CountyName = "Linköping" },
                new County { CountyId = 126, CountyName = "Ljungby" },
                new County { CountyId = 127, CountyName = "Ljusdal" },
                new County { CountyId = 128, CountyName = "Ljusnarsberg" },
                new County { CountyId = 129, CountyName = "Lomma" },
                new County { CountyId = 130, CountyName = "Ludvika" },
                new County { CountyId = 131, CountyName = "Luleå" },
                new County { CountyId = 132, CountyName = "Lund" },
                new County { CountyId = 133, CountyName = "Lycksele" },
                new County { CountyId = 134, CountyName = "Lysekil" },
                new County { CountyId = 135, CountyName = "Malmö" },
                new County { CountyId = 136, CountyName = "Malung-Sälen" },
                new County { CountyId = 137, CountyName = "Malå" },
                new County { CountyId = 138, CountyName = "Mariestad" },
                new County { CountyId = 139, CountyName = "Mark" },
                new County { CountyId = 140, CountyName = "Markaryd" },
                new County { CountyId = 141, CountyName = "Mellerud" },
                new County { CountyId = 142, CountyName = "Mjölby" },
                new County { CountyId = 143, CountyName = "Mora" },
                new County { CountyId = 144, CountyName = "Motala" },
                new County { CountyId = 145, CountyName = "Mullsjö" },
                new County { CountyId = 146, CountyName = "Munkedal" },
                new County { CountyId = 147, CountyName = "Munkfors" },
                new County { CountyId = 148, CountyName = "Mölndal" },
                new County { CountyId = 149, CountyName = "Mönsterås" },
                new County { CountyId = 150, CountyName = "Mörbylånga" },
                new County { CountyId = 151, CountyName = "Nacka" },
                new County { CountyId = 152, CountyName = "Nora" },
                new County { CountyId = 153, CountyName = "Norberg" },
                new County { CountyId = 154, CountyName = "Nordanstig" },
                new County { CountyId = 155, CountyName = "Nordmaling" },
                new County { CountyId = 156, CountyName = "Norrköping" },
                new County { CountyId = 157, CountyName = "Norrtälje" },
                new County { CountyId = 158, CountyName = "Norsjö" },
                new County { CountyId = 159, CountyName = "Nybro" },
                new County { CountyId = 160, CountyName = "Nykvarn" },
                new County { CountyId = 161, CountyName = "Nyköping" },
                new County { CountyId = 162, CountyName = "Nynäshamn" },
                new County { CountyId = 163, CountyName = "Nässjö" },
                new County { CountyId = 164, CountyName = "Ockelbo" },
                new County { CountyId = 165, CountyName = "Olofström" },
                new County { CountyId = 166, CountyName = "Orsa" },
                new County { CountyId = 167, CountyName = "Orust" },
                new County { CountyId = 168, CountyName = "Osby" },
                new County { CountyId = 169, CountyName = "Oskarshamn" },
                new County { CountyId = 170, CountyName = "Ovanåker" },
                new County { CountyId = 171, CountyName = "Oxelösund" },
                new County { CountyId = 172, CountyName = "Pajala" },
                new County { CountyId = 173, CountyName = "Partille" },
                new County { CountyId = 174, CountyName = "Perstorp" },
                new County { CountyId = 175, CountyName = "Piteå" },
                new County { CountyId = 176, CountyName = "Ragunda" },
                new County { CountyId = 177, CountyName = "Robertsfors" },
                new County { CountyId = 178, CountyName = "Ronneby" },
                new County { CountyId = 179, CountyName = "Rättvik" },
                new County { CountyId = 180, CountyName = "Sala" },
                new County { CountyId = 181, CountyName = "Salem" },
                new County { CountyId = 182, CountyName = "Sandviken" },
                new County { CountyId = 183, CountyName = "Sigtuna" },
                new County { CountyId = 184, CountyName = "Simrishamn" },
                new County { CountyId = 185, CountyName = "Sjöbo" },
                new County { CountyId = 186, CountyName = "Skara" },
                new County { CountyId = 187, CountyName = "Skellefteå" },
                new County { CountyId = 188, CountyName = "Skinnskatteberg" },
                new County { CountyId = 189, CountyName = "Skurup" },
                new County { CountyId = 190, CountyName = "Skövde" },
                new County { CountyId = 191, CountyName = "Smedjebacken" },
                new County { CountyId = 192, CountyName = "Sollefteå" },
                new County { CountyId = 193, CountyName = "Sollentuna" },
                new County { CountyId = 194, CountyName = "Solna" },
                new County { CountyId = 195, CountyName = "Sorsele" },
                new County { CountyId = 196, CountyName = "Sotenäs" },
                new County { CountyId = 197, CountyName = "Staffanstorp" },
                new County { CountyId = 198, CountyName = "Stenungsund" },
                new County { CountyId = 199, CountyName = "Stockholm" },
                new County { CountyId = 200, CountyName = "Storfors" },
                new County { CountyId = 201, CountyName = "Storuman" },
                new County { CountyId = 202, CountyName = "Strängnäs" },
                new County { CountyId = 203, CountyName = "Strömstad" },
                new County { CountyId = 204, CountyName = "Strömsund" },
                new County { CountyId = 205, CountyName = "Sundbyberg" },
                new County { CountyId = 206, CountyName = "Sundsvall" },
                new County { CountyId = 207, CountyName = "Sunne" },
                new County { CountyId = 208, CountyName = "Surahammar" },
                new County { CountyId = 209, CountyName = "Svalöv" },
                new County { CountyId = 210, CountyName = "Svedala" },
                new County { CountyId = 211, CountyName = "Svenljunga" },
                new County { CountyId = 212, CountyName = "Säffle" },
                new County { CountyId = 213, CountyName = "Säter" },
                new County { CountyId = 214, CountyName = "Sävsjö" },
                new County { CountyId = 215, CountyName = "Söderhamn" },
                new County { CountyId = 216, CountyName = "Söderköping" },
                new County { CountyId = 217, CountyName = "Södertälje" },
                new County { CountyId = 218, CountyName = "Sölvesborg" },
                new County { CountyId = 219, CountyName = "Tanum" },
                new County { CountyId = 220, CountyName = "Tibro" },
                new County { CountyId = 221, CountyName = "Tidaholm" },
                new County { CountyId = 222, CountyName = "Tierp" },
                new County { CountyId = 223, CountyName = "Timrå" },
                new County { CountyId = 224, CountyName = "Tingsryd" },
                new County { CountyId = 225, CountyName = "Tjörn" },
                new County { CountyId = 226, CountyName = "Tomelilla" },
                new County { CountyId = 227, CountyName = "Torsby" },
                new County { CountyId = 228, CountyName = "Torsås" },
                new County { CountyId = 229, CountyName = "Tranemo" },
                new County { CountyId = 230, CountyName = "Tranås" },
                new County { CountyId = 231, CountyName = "Trelleborg" },
                new County { CountyId = 232, CountyName = "Trollhättan" },
                new County { CountyId = 233, CountyName = "Trosa" },
                new County { CountyId = 234, CountyName = "Tyresö" },
                new County { CountyId = 235, CountyName = "Täby" },
                new County { CountyId = 236, CountyName = "Töreboda" },
                new County { CountyId = 237, CountyName = "Uddevalla" },
                new County { CountyId = 238, CountyName = "Ulricehamn" },
                new County { CountyId = 239, CountyName = "Umeå" },
                new County { CountyId = 240, CountyName = "Upplands-Bro" },
                new County { CountyId = 241, CountyName = "Upplands Väsby" },
                new County { CountyId = 242, CountyName = "Uppsala" },
                new County { CountyId = 243, CountyName = "Uppvidinge" },
                new County { CountyId = 244, CountyName = "Vadstena" },
                new County { CountyId = 245, CountyName = "Vaggeryd" },
                new County { CountyId = 246, CountyName = "Valdemarsvik" },
                new County { CountyId = 247, CountyName = "Vallentuna" },
                new County { CountyId = 248, CountyName = "Vansbro" },
                new County { CountyId = 249, CountyName = "Vara" },
                new County { CountyId = 250, CountyName = "Varberg" },
                new County { CountyId = 251, CountyName = "Vaxholm" },
                new County { CountyId = 252, CountyName = "Vellinge" },
                new County { CountyId = 253, CountyName = "Vetlanda" },
                new County { CountyId = 254, CountyName = "Vilhelmina" },
                new County { CountyId = 255, CountyName = "Vimmerby" },
                new County { CountyId = 256, CountyName = "Vindeln" },
                new County { CountyId = 257, CountyName = "Vingåker" },
                new County { CountyId = 258, CountyName = "Vårgårda" },
                new County { CountyId = 259, CountyName = "Vänersborg" },
                new County { CountyId = 260, CountyName = "Vännäs" },
                new County { CountyId = 261, CountyName = "Värmdö" },
                new County { CountyId = 262, CountyName = "Värnamo" },
                new County { CountyId = 263, CountyName = "Västervik" },
                new County { CountyId = 264, CountyName = "Västerås" },
                new County { CountyId = 265, CountyName = "Växjö" },
                new County { CountyId = 266, CountyName = "Ydre" },
                new County { CountyId = 267, CountyName = "Ystad" },
                new County { CountyId = 268, CountyName = "Åmål" },
                new County { CountyId = 269, CountyName = "Ånge" },
                new County { CountyId = 270, CountyName = "Åre" },
                new County { CountyId = 271, CountyName = "Årjäng" },
                new County { CountyId = 272, CountyName = "Åsele" },
                new County { CountyId = 273, CountyName = "Åstorp" },
                new County { CountyId = 274, CountyName = "Åtvidaberg" },
                new County { CountyId = 275, CountyName = "Älmhult" },
                new County { CountyId = 276, CountyName = "Älvdalen" },
                new County { CountyId = 277, CountyName = "Älvkarleby" },
                new County { CountyId = 278, CountyName = "Älvsbyn" },
                new County { CountyId = 279, CountyName = "Ängelholm" },
                new County { CountyId = 280, CountyName = "Öckerö" },
                new County { CountyId = 281, CountyName = "Ödeshög" },
                new County { CountyId = 282, CountyName = "Örebro" },
                new County { CountyId = 283, CountyName = "Örkelljunga" },
                new County { CountyId = 284, CountyName = "Örnsköldsvik" },
                new County { CountyId = 285, CountyName = "Östersund" },
                new County { CountyId = 286, CountyName = "Österåker" },
                new County { CountyId = 287, CountyName = "Östhammar" },
                new County { CountyId = 288, CountyName = "Östra Göinge" },
                new County { CountyId = 289, CountyName = "Överkalix" },
                new County { CountyId = 290, CountyName = "Övertorneå" }
        };


        }
    }
}
