using System;

namespace Arithmetisch
{
    /*
     * Operatoren -> dienen zur Verknüpfung bzw. Manipulation von Daten
     *
     *	(1) mathematisch arithmetische Operatoren
     *  (2) relationale Operatoren (Vergleichsoperatoren)
     *  (3) logische Operatoren
     *	(4) bitweise (logische) Operatoren
     *  (5) spezielle Operatoren
     *
     *  HINWEIS: Mittels des Konzepts des "Überladens von Operatoren"
     *           kann eine Klasse in einer objektorientierten Sprache
     *           die Funktionalität/Semantik eines Operators auf ihre
     *           "eigenen Bedürfnisse hin ändern", d.h. eine andere 
     *           Funktionalität für diesen Operatoren definieren.
     *        
     *           Bsp.: (1) Die Klasse 'System.String' aus der .NET-Klassenbibliothek
     *                     reimplementiert den '+'-Operator dahingehend, um zwei
     *                     Zeichenketten ('String'-Objekte) miteinander zu konkatenieren.
     *                     
     *                 (2) Der Strukturtyp 'System.DateTime' aus der .NET-Klassenbibliothek
     *                     überlädt den '-'-Operator, um entweder zwei 'DateTime'-Objekte
     *                     zu "subtrahieren" und als Ergebnis die Zeitspanne ('TimeSpan') zu
     *                     liefern, die zwischen den Datumswerten verstrichen ist, oder von
     *                     einem 'DateTime'-Objekt eine Zeitdauer abzuziehen, um als Ergebnis
     *                     ein entsprechendes neues Datum zu liefern.
     */

    class Program
    {
        /*
         * Mathematische Operatoren:
         * 
         *      (a) + (Addition)
         *      (b) - (Subtraktion - binäre Operation, Negation - unäre Operation)
         *      (c) * (Multiplikation)
         *      (d) / (Division - Ganzzahl- und Gleitkomma-Division)
         *      (e) % (Modulo - Rest der Ganzzahl- oder Gleitkomma-Division)
         */

        static void Main(string[] args)
        {
            // Beispiel 1 (Addition, Multiplikation)
            //
            double rechnung = 3 * 7.90 + 4 * 3.60 + 2 * (2.40 + 5.40);
            Console.WriteLine("\nRechnung: {0:F2} Euro\n", rechnung);

            // Typ-Konvertierung
            //
            // falls ein Gleitkommawert in einen Ganzzahltyp konvertiert wird,
            // werden einfach die Nachkommastellen abgeschnitten
            //
            int rechnungAlsGanzzahl = (int)rechnung;
            Console.WriteLine("Rechnung: {0} Euro (als Ganzzahl)\n", rechnungAlsGanzzahl);

            // Beispiel 2 (Division, Modulo)
            //
            double quotientGleitkomma, teilerGleitkomma = 5, restGleitkomma;
            int wertGanzzahl = 27, quotientGanzzahl, teilerGanzzahl = 5, restGanzzahl;

            // (1) Gleitkomma-Division
            //
            quotientGleitkomma = wertGanzzahl / teilerGanzzahl;
            Console.WriteLine("Quotient (Gleitkomma): {0}", quotientGleitkomma);

            // (2) Ganzzahl-Division
            //
            quotientGanzzahl = wertGanzzahl / teilerGanzzahl;
            //quotientGanzzahl = 27 / 5;
            Console.WriteLine("Quotient   (Ganzzahl): {0}\n", quotientGanzzahl);

            // (3) Modulo (Gleitkomma)
            //
            restGleitkomma = 3.9 % 1.2;
            Console.WriteLine("Rest (Gleitkomma): {0}", restGleitkomma);

            // (4) Modulo (Ganzzahl)
            //
            restGanzzahl = wertGanzzahl % teilerGanzzahl;
            Console.WriteLine("Rest   (Ganzzahl): {0}\n", restGanzzahl);

            // Beispiel 3: Wieviel Liter Benzin wird auf einer Fahrtstrecke von 345km
            //             bei einem durchschnittlichen Verbrauch von 7.5l auf 100km verbraucht?
            //
            double benzinVerbrauchInLiter = 345 / 100 * 7.5;
            //benzinVerbrauchInLiter = 345 / (100 * 7.5);

            Console.WriteLine("Verbrauch: {0} Liter (falsch)", benzinVerbrauchInLiter);

            benzinVerbrauchInLiter = 345 * 7.5 / 100;
            benzinVerbrauchInLiter = 345.0 / 100 * 7.5;
            benzinVerbrauchInLiter = 345 / (100 / 7.5);

            Console.WriteLine("Verbrauch: {0} Liter (richtig)\n", benzinVerbrauchInLiter);
        }
    }
}
