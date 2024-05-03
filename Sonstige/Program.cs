using System;

namespace Sonstige
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
	         * (1) Inkrement- und Dekrement-Operator
	         *     (sowohl in Präfix- als auch in Postfix-Notation)
	         *
	         *  (a) Inkrement: ++ (erhöht den Wert einer (Ganzzahl-)Variablen um 1)
	         *  (b) Dekrement: -- (erniedrigt den Wert einer (Ganzzahl-)Variablen um 1)
	         *
	         * Wenn die Präfix-Notation ('++variable') gewählt wird, so erfolgt die Inkrement- bzw.
	         * Dekrement-Operation VOR allen anderen Operationen innerhalb einer zusammengesetzten
	         * bzw. geschachtelten Anweisung, ansonsten, im Falle der Postfix-Notation ('variable--'),
	         * NACH allen anderen Operationen.
             */

            int a = 0, b = 0;

            Console.WriteLine("\na = {0} b = {1}", a, b);

            a++; // Postfix-Notation
            ++b; // Präfix-Notation

            Console.WriteLine("a = {0} b = {1}", a, b);

            a = b++;
            Console.WriteLine("a = {0} b = {1}", a, b);

            a = --b;
            Console.WriteLine("a = {0} b = {1}", a, b);

            Console.WriteLine("a = {0} b = {1}", a++, ++b);

            a = a + 1;

            // Kurzschreibweisen
            //
            a += 1;
            a -= b; // a = a - b;
            a /= 2; // a = a / 2;
            b *= 4; // b = b * 4;


            /*
             * (2) Zuweisungsoperator 
             */
            int i, j, k;
            i = j = k = 42;

            Console.WriteLine("\ni = {0} j = {1} k = {2}\n", i, j, k);

            // es können durchaus auch mehrere Zuweisungen 
            // in einer einzigen Anweisung erfolgen
            //
            a = 2 + (b *= 3);

            /*
             * (3) Bedingungsoperator
             * 
             * Der ternäre Operator '(Bedingung) ? wert1 : wert2' 
             * dient als Kurzform einer bedingten Anweisung mit Alternativpfad ('if-else'-Statement)
             */
            int max = (a > b) ? a : b;
            Console.WriteLine("max({0},{1}) = {2}\n", a, b, max);

            Console.WriteLine("min({0},{1}) = {2}\n", a, b, (a < b) ? a : b);

            if (a > b)
            {
                max = a;
            }
            else
            {
                max = b;
            }

            /*
             * (4) 'sizeof()'-Operator
             * 
             * Der 'sizeof()'-Operator liefert in C# den Speicherbedarf eines Werttyps ('struct') in Byte
             * 
             * Hinweis: Im prozeduralen Teil C der Programmiersprache C++ wird dieser Operator benutzt,
             *          um den Speicherbedarf von zusammengesetzten Typen ('struct') oder von Variablen
             *          zu ermitteln.
             * 
             *          Dies geht in C# nicht, ist jedoch auch nicht notwendig.
             */

            Console.WriteLine(" sizeof(double) = {0} Byte", sizeof(double));
            Console.WriteLine("sizeof(decimal) = {0} Byte\n", sizeof(decimal));


            /*
             * (5) 'typeof()'-Operator
             * 
             * Mit Hilfe des 'typeof()'-Operators - im Zusammenhang mit der 'GetType()'-Methode
             * der .NET-Wurzelklasse 'Object' - kann entweder der Typ einer Variablen ermittelt (a),
             * oder festgestellt werden, was sich für ein Typ von Objekt hinter einen Objektverweis
             * verbirgt (b) 
             * 
             * Bemerkungen zu (b):
             * 
             *      - die Klasse 'object' (System.Object) ist die Basisklasse ("Mutterklasse") 
             *        aller Klassen in .NET (siehe später Projektmappe 'PDemo01_Object')
             *        
             *      - das Prinzip der Polymorphie besagt, das der Typ einer Referenz nicht
             *        notwendigerweise identisch mit dem Typ des Objekts sein muss, 
             *        auf welches die Referenz verweist (siehe später Projektmappe 'Vererbung')
             */

            // (a)
            //
            if (a.GetType() == typeof(int))
            {
                Console.WriteLine("Die Variable 'a' ist vom Datentyp 'int'");
            }

            // (b1)
            //
            Random zufall = new Random();

            if (zufall.GetType() == typeof(Random))
            {
                Console.WriteLine(
                    "Die Referenz 'zufall' verweist auf ein Objekt vom Typ der Klasse 'Random'");
            }

            // (b2)
            //
            object objZufall = new Random();

            if (objZufall.GetType() == typeof(Random))
            {
                Console.WriteLine(
                    "Die Referenz 'objZufall' verweist auf ein Objekt vom Typ der Klasse 'Random'");
            }

            Console.WriteLine();

            //objZufall = null;

            if (objZufall is Random)
            {
                Console.WriteLine(
                    "Die Referenz 'objZufall' verweist auf ein Objekt vom Typ der Klasse 'Random'");
            }
        }
    }
}
