using System;
using System.Globalization;

namespace RelationalUndLogisch
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * Vergleichsoperatoren -> liefern beim Vergleich von Werten
             *                         einen logischen Wert ('bool'),
             *                         also 'true' oder 'false' zurück
             *
             *  (a) >  (größer als)
             *  (b) >= (größer oder gleich)
             *  (c) == (gleich, äquivalent)
             *  (d) <  (kleiner als)
             *  (e) <= (kleiner oder gleich)
             *  (f) != (ungleich, nicht äquivalent)
             */

            // Beispiel 1
            //
            bool vergleich = (17 > 4);
            Console.WriteLine("\nVergleich: {0}", vergleich);

            vergleich = 21 <= 20;
            Console.WriteLine("Vergleich: {0}", vergleich);

            int i = 42;

            // liegt der aktuelle Wert von 'i'
            // zwischen 40 und 50?
            //
            // dies ist in C# nicht möglich
            //
            //vergleich = 40 <= i <= 50;

            vergleich = (i >= 40) && (i <= 50);


            /*
             * Logische Operatoren -> verknüpfen logische Operanten ('bool'-Werte)
             *                        wieder zu einem logischen Ergebnis
             *
             *  (a) && (logisches AND)
             *  (b) || (logisches OR)
             *  (c)  ! (logisches NOT) -> unärer Operator
             *  (d)  ^ (logischer XOR, Antivalenz)
             *
             *  Operator-Priorität bzw. Vorrangsregeln:
             *
             *		erst !, dann &&, zuletzt ||,
             *      d.h. ohne explizite Klammerung wird zuerst
             *      das logische NOT ausgewertet, danach das
             *      logische AND und erst zuletzt das logische OR
             *
             * 
             *    &&  logisches UND 
             *
             *    Op1\Op2 |  false  true
             *    -----------------------     
             *      false |  false  false   Ergebnisse der
             *      true  |  false  true    &&-Operation
             *
             *    ||  logisches ODER
             *
             *    Op1\Op2 |  false  true
             *    -----------------------     
             *      false |  false  true    Ergebnisse der
             *      true  |  true   true    ||-Operation
             *
             *    ^   exklusives ODER (XOR, Antivalenz, 
             *                         d.h. die Operatoren müssen verschieden sein)
             *
             *    Op1\Op2 |  false  true
             *    -----------------------     
             *      false |  false  true    Ergebnisse der
             *      true  |  true   false   ^-Operation
             *
             *    !   logisches NICHT (nur für einen Operanden, d.h. unär)
             *
             *    !true = false  
             *    !false = true
             * 
             */

            vergleich = (40 <= i && i <= 50);
            Console.WriteLine("\nVergleich: {0}", vergleich);


            /*
             * Beispiel: Benutzereingabe
             * 
	         * Body-Mass-Index 'bmi': gewicht[kg] / groesse[m]²
             *
             *     wenn bmi <  20 => duenn = true
             *     wenn bmi >= 20 => vielleicht normal
             *     wenn bmi >= 25 => dick = true
             */
            double bmi, gewicht = 0;

            Console.Write("\nEingabe Gewicht (in kg): ");

            string eingabe = Console.ReadLine();

            // Compiler-Error
            //
            // eine Zeichenkette ('String') kann NICHT
            // direkt in einen numerischen Typ konvertiert werden
            //
            //gewicht = (double)eingabe;

            // Demo: Fehlerbehandlungskonzept objektorientierter Programmiersprachen
            //       (Ausnahmen/Exceptions und 'try-catch-finally'-Blöcke)
            //
            //       (siehe auch Demoprojekt "PDemo04_AusnahmeBehandlung") 
            //
            try
            {
                // im 'try'-Block werden Anweisungen platziert, bei denen
                // unter Umständen zu einem Fehler, also zu einer 'Exception'
                // kommen kann

                // eine Zeichenkette kann entweder mit der Klasse 'Convert'
                // oder mit der 'Parse()'- bzw. 'TryParse()'-Methode (in diesem Fall
                // des Typs 'System.Double') in eine Zahl umgewandelt werden
                //
                //gewicht = Convert.ToDouble(eingabe);
                gewicht = double.Parse(eingabe);

                Console.WriteLine("\nIch werde NUR ausgeführt, wenn es oben zu keiner 'Exception' kam\n");
            }
            // falls mehrere 'catch'-Blöcke existieren, 
            // muss die Reihenfolge von "Konkret" zu "Allgemeiner" erfolgen
            //
            catch (FormatException ex)
            {
                // Fehlerbehandlungsmaßnahmen im Falle einer 'FormatException'
                //
                Console.WriteLine(
                    "\nFehler: {0} Grund: {1}\n", ex.GetType(), ex.Message);

                // 'return' bedeutet "Rücksprung zum Aufrufer der Methode"
                //
                return;
            }
            catch (OverflowException ex)
            {
                // Fehlerbehandlungsmaßnahmen im Falle einer 'OverflowException'
                //
                Console.WriteLine(
                    "\nFehler: {0} Grund: {1}\n", ex.GetType(), ex.Message);

                return;
            }
            catch (Exception)
            {
                // Fehlerbehandlungsmaßnahmen im Fall IRGENDEINES anderen Fehlers
                //
                return;
            }
            finally
            {
                // der 'finally'-Block wird IMMER abgearbeitet,
                // unabhängig davon, ob ein Fehler, also eine 'Exception'
                // aufgetreten ist, oder nicht
                //
                // im 'finally'-Block werden in der Regel "Aufräumarbeiten" erledigt,
                // z.B. den Zugriff auf eine Datei beenden oder eine DB-Verbindung schließen
                //
                Console.WriteLine("\nIch werde IMMER ausgeführt;-)\n");
            }

            Console.Write("    Eingabe Größe (im m): ");

            eingabe = Console.ReadLine();

            // mit Hilfe der Klasse 'CultureInfo' können kulturabhängige Regeln 
            // miteinbezogen werden
            //
            CultureInfo cultureInfoUSAViaId = new CultureInfo(1033 /* culture ID */);
            CultureInfo cultureInfoUSAViaName = new CultureInfo("en-US");

            // prinzipiell kann das ganze Programm, genauer der aktuelle Thread 
            // auf eine andere Kultur umgestellt werden
            //
            //System.Threading.Thread.CurrentThread.CurrentCulture = cultureInfoUSAViaId;

            // im Falle der 'TryParse()' kommt es zu keinen Ausnahmen/Exceptions,
            // sondern die Methode liefert 'true' zurück, falls kein Fehler bei der Umwandlung
            // aufgetreten ist, ansonsten 'false'
            //
            //double groesse;

            //bool hatGeklappt = double.TryParse(eingabe, out groesse);
            bool hatGeklappt = double.TryParse(
                eingabe,
                NumberStyles.Number,
                cultureInfoUSAViaId,
                out double groesse);

            if (!hatGeklappt)
            {
                Console.WriteLine("\nUngültiger Wert für Größe!\n");

                return;
            }

            // Berechnung des BMI
            //
            bmi = gewicht / (groesse * groesse);

            // alternativ mit Potenzierungsmethode 'Pow()' der Klasse 'Math'
            //
            bmi = gewicht / Math.Pow(groesse, 2);

            Console.Write("\nBerechneter BMI: {0:F2} ", bmi);

            // Auswertung des BMI
            //
            //  wenn bmi < 20            => duenn = true
            //  wenn bmi >= 20 und < 25  => normal = true
            //  wenn bmi >= 25           => dick = true
            //
            bool dick; //, normal, duenn;
            bool normal;
            bool duenn;

            duenn = bmi < 20;
            dick = bmi >= 25;

            //normal = (bmi >= 20 && bmi < 25);
            normal = !duenn && !dick;

            normal = !(duenn || dick); // (*)

            Console.WriteLine(
                "Auswertung: dünn: {0} normal: {1} dick: {2}\n",
                duenn, normal, dick);

            /* 
             * de Morgan'sche Regeln für logische Operatoren:
             *
             *   Gegeben: bool a,b;
             *   Dann gilt:
             * 
             *       !(a && b)  == !a || !b
             *       !(a || b)  == !a && !b (*)
             */


            // Beispiel: Zufallszahlen
            //
            //      Liegt das Gehalt zwischen 3000 und 4000 Euro,
            //      einschliesslich der Grenzen?
            //


            // Erzeugen eines Objekts der Klasse 'System.Random'
            //
            // (1) Deklaration einer Referenz bzw. eines Objektverweises
            //     in der Regel vom Typ der Klasse des zu erzeugenden Objekts
            //
            //     -> 'Random zufall;'
            //
            // (2) mit Hilfe des Operators 'new' wird auf dem Speicherbereich "Heap" 
            //     der vom Objekt benötigte Speicher angefordert bzw. allokiert
            //
            // (3) mittels des Aufrufs des Konstruktors 'Random()'
            //     der Klasse 'Random' wird das Objekt initialisiert,
            //     d.h. den Datenelementen des Objekts initiale Werte zugewiesen
            //
            // (4) die (Speicher-)Adresse des allokierten Speicherbereichs 
            //     wird als Ergebnis von 'new' dem Objektverweis 'zufall'
            //     als Wert zugewiesen und fortan kann über die Referenz 'zufall'
            //     mit dem 'Random'-Objekt agiert werden
            //

            Random zufall = new Random();

            // der Wertebereich der Zufallszahl
            // soll zwischen 2500 und 4500 liegen
            //
            int zufallsWert = zufall.Next(2500, 4501);

            // alternativ
            //
            zufallsWert = 2500 + zufall.Next() % 2001;

            // liegt der Wert zwischen 3000 und 4000?
            //
            vergleich = zufallsWert >= 3000 && zufallsWert <= 4000;

            Console.WriteLine(
                "Zufallswert: {0} innerhalb => {1}", 
                zufallsWert, vergleich);

            // liegt der Wert außerhalb obigen Bereichs?
            //
            // falsche Berechnung
            //
            vergleich = zufallsWert < 3000 && zufallsWert > 4000;

            vergleich = !(zufallsWert >= 3000 && zufallsWert <= 4000);

            vergleich = zufallsWert < 3000 || zufallsWert > 4000;

            Console.WriteLine(
                "Zufallswert: {0} außerhalb => {1}",
                zufallsWert, vergleich);

            /*
             * "Short Circuit Evaluation"
             * (Optimierung des Programmablaufplans durch den Compiler)
             *
             *	if (a < b && x == y) ... -> falls der linke Ausdruck (a < b)
             *                              bereits zu 'false' ausgewertet wird,
             *                              dann wird der rechte Ausdruck (x == y)
             *                              gar nicht mehr ausgewertet
             *
             *  if (17 > 4 || i < j) ... -> dto.
             *
             * Achtung: if (a < b && object.method()) ...
             *
             * if (a < b & x == y)       -> hier wird der Compiler gezwungen, 
             *                              sämtliche Auswertungen vorzunehmen
             */

            Console.WriteLine();
        }
    }
}
