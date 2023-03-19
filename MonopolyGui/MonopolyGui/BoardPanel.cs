using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.VisualBasic;
using MonopolyData;
using MonopolyGui;

namespace MonopolyGui
{
    public class BoardPanel
    {
        List<IRefreshField> fields = new List<IRefreshField>();

        public List<IRefreshField> Fields { get => fields; set => fields = value; }

        public BoardPanel() 
        {
            AddAllElement();
        }

        private void AddAllElement() 
        {
            GameStatus actualGameStatus = GameStatus.Instance;
            
            Canvas canvasStart = new Canvas();
            StartFieldElement start = new StartFieldElement(canvasStart, 0,Location.South);
            Fields.Add(start);
            
            
            Canvas canvasKonopacka= new Canvas();
            StreetFieldScreenElement ulKonopacka = new StreetFieldScreenElement(canvasKonopacka, 1,Location.South);
            Fields.Add(ulKonopacka);


            Canvas canvasKasaSpoleczna1 = new Canvas();
            FieldScreenElement KasaSpoleczna = new FieldScreenElement(canvasKasaSpoleczna1, 2, Location.South);
            Fields.Add(KasaSpoleczna);



            Canvas canvasUlStalowa = new Canvas();
            StreetFieldScreenElement ulStalowa = new StreetFieldScreenElement(canvasUlStalowa, 3, Location.South);
            Fields.Add(ulStalowa);



            Canvas canvasPodatekDochodowy = new Canvas();
            FieldScreenElement PodatekDochodowy = new FieldScreenElement(canvasPodatekDochodowy, 4, Location.South);
            Fields.Add(PodatekDochodowy);


            Canvas canvasDworzecGdański = new Canvas();
            FieldScreenElement DworzecGdański = new FieldScreenElement(canvasDworzecGdański, 5, Location.South);
            Fields.Add(DworzecGdański);


            Canvas canvasUlRadzyminska = new Canvas();
            StreetFieldScreenElement ULRadzyminska = new StreetFieldScreenElement(canvasUlRadzyminska, 6, Location.South);
            Fields.Add(ULRadzyminska);


            Canvas CanvasSzansa = new Canvas();
            FieldScreenElement Szansa = new FieldScreenElement(CanvasSzansa, 7, Location.South);
            Fields.Add(Szansa);

            Canvas canvasUlJagiellonska = new Canvas();
            StreetFieldScreenElement UlJagiellonska = new StreetFieldScreenElement(canvasUlJagiellonska, 8, Location.South);
            Fields.Add(UlJagiellonska);

            Canvas canvasUlTargowa= new Canvas();
            StreetFieldScreenElement ULTargowa = new StreetFieldScreenElement(canvasUlTargowa, 9, Location.South);
            Fields.Add(ULTargowa);


            Canvas CanvasWiezienie = new Canvas();
            JailFieldScreenElement Wiezienie = new JailFieldScreenElement(CanvasWiezienie, 10, Location.South);
            Fields.Add(Wiezienie);


            Canvas canvasUlPlowiecka = new Canvas();
            StreetFieldScreenElement UlPlowiecka = new StreetFieldScreenElement(canvasUlPlowiecka, 11, Location.West);
            Fields.Add(UlPlowiecka);

            Canvas CanvasElektrownia = new Canvas();
            FieldScreenElement Elektrownia = new FieldScreenElement(CanvasElektrownia, 12, Location.West);
            Fields.Add(Elektrownia);


            Canvas canvasUlMarsa = new Canvas();
            StreetFieldScreenElement UlMarsa = new StreetFieldScreenElement(canvasUlMarsa, 13, Location.West);
            Fields.Add(UlMarsa);

            Canvas canvasUlGrochowska = new Canvas();
         
            StreetFieldScreenElement UlGrochowska = new StreetFieldScreenElement(canvasUlGrochowska, 14, Location.West);
            Fields.Add(UlGrochowska);



            Canvas canvasDworzecZachodni = new Canvas();
            FieldScreenElement DworzecZachodni = new FieldScreenElement(canvasDworzecZachodni, 15, Location.West);
            Fields.Add(DworzecZachodni);


            Canvas CanvasUlObozowa = new Canvas();
            StreetFieldScreenElement UlObozowa = new StreetFieldScreenElement(CanvasUlObozowa, 16, Location.West);
            Fields.Add(UlObozowa);


            Canvas CanvasKasaSpoleczna = new Canvas();
            FieldScreenElement KasaSpoleczna2 = new FieldScreenElement(CanvasKasaSpoleczna, 17, Location.West);
            Fields.Add(KasaSpoleczna2);

            Canvas canvasUlGorczewska = new Canvas();
            StreetFieldScreenElement UlGorczewska = new StreetFieldScreenElement(canvasUlGorczewska, 18, Location.West);
            Fields.Add(UlGorczewska);

            Canvas canvasUlWolska = new Canvas();
            StreetFieldScreenElement UlWolska = new StreetFieldScreenElement(canvasUlWolska, 19, Location.West);
            Fields.Add(UlWolska);

            Canvas CanvasParking = new Canvas();
            StartFieldElement Parking = new StartFieldElement(CanvasParking, 20,Location.West);
            Fields.Add(Parking);

            Canvas CanvasUlMickiewicza = new Canvas();
            StreetFieldScreenElement UlMickiewicza = new StreetFieldScreenElement(CanvasUlMickiewicza, 21, Location.North);
            Fields.Add(UlMickiewicza);

            Canvas CanvasSzansa2 = new Canvas();
            FieldScreenElement Szansa2 = new FieldScreenElement(CanvasSzansa2, 22, Location.North);
            Fields.Add(Szansa2);

            Canvas CanvasUlSlowackiego = new Canvas();
            StreetFieldScreenElement UlSlowackiego = new StreetFieldScreenElement(CanvasUlSlowackiego, 23, Location.North);
            Fields.Add(UlSlowackiego);

            Canvas canvasPlacWilsona = new Canvas();
            StreetFieldScreenElement PlacWilsona = new StreetFieldScreenElement(canvasPlacWilsona, 24, Location.North);
            Fields.Add(PlacWilsona);

            Canvas canvasDworzecWschodni = new Canvas();
            FieldScreenElement DworzecWschodni = new FieldScreenElement(canvasDworzecWschodni, 25, Location.North);
            Fields.Add(DworzecWschodni);

            Canvas CanvasUlSwietokrzyska = new Canvas();
            StreetFieldScreenElement UlSwetokrzyska = new StreetFieldScreenElement(CanvasUlSwietokrzyska, 26, Location.North);
            Fields.Add(UlSwetokrzyska);

            Canvas CanvasKrakowskiePrzedmiescie = new Canvas();
            StreetFieldScreenElement UlKrakowskiePrzedmiescie = new StreetFieldScreenElement(CanvasKrakowskiePrzedmiescie, 27, Location.North);
            Fields.Add(UlKrakowskiePrzedmiescie);

            Canvas CanvasWodociagi = new Canvas();
            FieldScreenElement Wodociagi = new FieldScreenElement(CanvasWodociagi, 28, Location.North);
            Fields.Add(Wodociagi);
      
            Canvas CanvasNowySwiat = new Canvas();
            StreetFieldScreenElement NowySwiat = new StreetFieldScreenElement(CanvasNowySwiat, 29, Location.North);
            Fields.Add(NowySwiat);

            Canvas CanvasIdzDoWiezienia = new Canvas();
            StartFieldElement IdzDoWiezienia = new StartFieldElement(CanvasIdzDoWiezienia, 30, Location.North);
            Fields.Add(IdzDoWiezienia);

            Canvas CanvasPlacTrzechKrzyzy= new Canvas();
            StreetFieldScreenElement PlacTrzechKrzyzy = new StreetFieldScreenElement(CanvasPlacTrzechKrzyzy, 31, Location.East);
            Fields.Add(PlacTrzechKrzyzy);

            Canvas CanvasUlMarszalkowska = new Canvas();
            StreetFieldScreenElement UlMarszalkowska = new StreetFieldScreenElement(CanvasUlMarszalkowska, 32, Location.East);
            Fields.Add(UlMarszalkowska);

            Canvas CanvasKasaSpoleczna3 = new Canvas();
            FieldScreenElement KasaSpoleczna3 = new FieldScreenElement(CanvasKasaSpoleczna3, 33, Location.East);
            Fields.Add(KasaSpoleczna3);

            Canvas CanvasAlejeJerozolimskie = new Canvas();
            StreetFieldScreenElement AlejeJerozolimskie = new StreetFieldScreenElement(CanvasAlejeJerozolimskie, 34, Location.East);
            Fields.Add(AlejeJerozolimskie);

            Canvas CanvasDworzecCentralny = new Canvas();
            FieldScreenElement DworzecCentralny = new FieldScreenElement(CanvasDworzecCentralny, 35, Location.East);
            Fields.Add(DworzecCentralny);

            Canvas CanvasSzansa3 = new Canvas();
            FieldScreenElement Szansa3 = new FieldScreenElement(CanvasSzansa3, 36, Location.East);
            Fields.Add(Szansa3);

            Canvas CanvasUlicaBelwederska = new Canvas();
            StreetFieldScreenElement UlicaBelwederska = new StreetFieldScreenElement(CanvasUlicaBelwederska, 37, Location.East);
            Fields.Add(UlicaBelwederska);

            Canvas CanvasPodatekDochody = new Canvas();
            FieldScreenElement PodatekDochodowy2 = new FieldScreenElement(CanvasPodatekDochody, 38, Location.East);
            Fields.Add(PodatekDochodowy2);

            Canvas CanvasAlejeUjazdowskie = new Canvas();
            StreetFieldScreenElement AlejeUjazdowskie = new StreetFieldScreenElement(CanvasAlejeUjazdowskie, 39, Location.East);
            Fields.Add(AlejeUjazdowskie);

        }


        public void GroupedRefresh() 
        {
            foreach(var item in Fields) 
            {
                item.Refresh();
            }
        }



    }
}
