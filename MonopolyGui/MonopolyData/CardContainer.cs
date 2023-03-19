using MonopolyGui.Actions;
using MonopolyLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyGui
{
    public class CardContainer
    {
        List<GameAction> cardCollector;

        public CardContainer() 
        {
            cardCollector = new List<GameAction>();
            InitChances();
            InitSocialTreasure();
        }

        /// <summary>
        /// Dodaje karty szansy i ustawia im akcje
        /// </summary>
        private void InitChances() 
        {
            //Karty szansy
            cardCollector.Add(new GoToAction(null,"Przejdź na IiE",1));
            cardCollector.Add(new GoToAction(null,  "Przejdź na start. Pobierz 200", 0));
            cardCollector.Add(new GoToAction(null, "Czas wrócić z weekendu. Przejdź do akademika KAPITOL",15));
            cardCollector.Add(new GoToPrisonAction(null,"Zbyt dosłownie wziąłeś do siebie słowa \"Środowa noc, to wódy czas\". Idziesz leczyć kaca. Nie przechodzisz przez start i nie pobierasz pieniędzy"));
            cardCollector.Add(new GoToAction(null,  "Znajomi wyciągneli cię na browar. Jeśli jest niczyj to możesz kupić. W innym przypadku zapłać odpowiednią kwotę", 12));
            cardCollector.Add(new LeavePrisonAction(null,null, "Dostałeś fantastyczne pigułki na kaca. Będziesz mógł użyć ich, kiedy wylądujesz na tym polu"));
            cardCollector.Add(new PlayerGetFromBankAction(null, "Sprzedajesz wejściówkę do klubu. Pobierz 200",200));
            cardCollector.Add(new PlayerPaysToBankAction(null, "Zapłać mandat za picie w miejscu publicznym o wysokości 15",15));
            cardCollector.Add(new PlayerGetFromBankAction(null, "Za pomoc w projekcie kolegi dostajesz 150",150));
            cardCollector.Add(new GoToAction(null, "Przejdź na parking",20));
            cardCollector.Add(new HouseReconstructionAction(null,"Twoi znajomi zorganizowali ci ciąg imprez w twoich nieruchomościach. Zapłać po 25 od każdego twojego domku i 100 za każdy hotel na ich remonty",25,100));
            cardCollector.Add(new GoToAction(null, "Odprowadzasz kolegę na wydział informatyki stosowanej",19));
            cardCollector.Add(new GoXSquaresAction(null, "Osoba której doradzałeś finansowo zemściła się popychając ciebie. Przejdź o 3 pola do przodu", 3));
            cardCollector.Add(new GoToAction(null, "Przejdź na pole Edukacja techniczno-informatyczna",26));
            cardCollector.Add(new GoXSquaresAction(null, "Przegapiłeś swój przystanek. Pójdź dwa pola do przodu", 2));
            
        }

        /// <summary>
        /// Dodaje karty kasa społeczna i ustawia im akcje
        /// </summary>
        private void InitSocialTreasure() 
        {
            //Karty kasa społęczna
            cardCollector.Add(new PlayerPaysToBankAction(null,  "Zapłać mandat za przejście przez jezdnię w niedozwolonym miejscu o wysokości 50",50));
            cardCollector.Add(new PlayerPaysToBankAction(null,  "Zapłać za warunek 50", 50));
            cardCollector.Add(new PlayerGetFromBankAction(null,  "Wygrałeś hackaton. Pobierz 10", 10));
            cardCollector.Add(new PlayerPaysToBankAction(null,  "Tym razem ty stawiasz imprezę. Zapłać 100", 100));
            cardCollector.Add(new PlayerGetFromBankAction(null,  "Zatrudniłeś się w KFC. Pobierz 100", 100));
            cardCollector.Add(new PlayerGetFromBankAction(null,  "Wygrałeś zakład ze znajomymi. Pobierz 100", 100));
            cardCollector.Add(new PlayerGetFromBankAction(null,  "Koleżanka zwraca dług. Pobierz 100", 100));
            cardCollector.Add(new PlayerGetFromBankAction(null,  "Otrzymujesz 25 za porady finansowe", 25));
            cardCollector.Add(new PlayerGetFromBankAction(null,  "Znalazłeś na ulicy 20", 20));
            cardCollector.Add(new PlayerGetFromBankAction(null,  "Sprzedajesz swój kalkulator. Pobierz 50",50));
            cardCollector.Add(new PlayerGetFromBankAction(null,  "Ktoś kupił twoje notatki. Pobierz 200", 200));
            cardCollector.Add(new GoToAction(null, "Przejdź na start. Pobierz 200", 0));
            cardCollector.Add(new GoToPrisonAction(null, "Trochę cię poniosło na imprezie. Idź leczyć kaca. Nie przechodzisz przez start, nie pobierasz pieniędzy"));
            cardCollector.Add(new HouseReconstructionAction(null,"Było straszne gradobicie i powybijało okno w budynkach. Zapłać po 40 za każdy dom i po 115 za każdy hotel", 40, 115));
            cardCollector.Add(new LeavePrisonAction(null, null, "Dostałeś fantastyczne pigułki na kaca. Będziesz mógł użyć ich, kiedy wylądujesz na tym polu"));
        }


        public GameAction GetCard(int id) 
        {
            return cardCollector[id];
        }

    
    }
}
