using System;
using System.Collections.Generic;
using System.Linq;

namespace Calculator.ConsoleClient {
    class Program {
        static readonly int[] opcionesValidasGuardar = { 1, 2, 3, 4, 5 };
        static void Main(string[] args) {
            try {
                var salir = "n";

                var calculadora = new CalculatorClient();
                string resultado = "";
                do {
                    Console.Clear();
                    Console.WriteLine("****************************************************************");
                    Console.WriteLine("Calculadore Ditech - Oscar Contreras");
                    Console.WriteLine("Digite la mopcion deseada:");

                    Console.WriteLine("1:Suma");
                    Console.WriteLine("2:Resta");
                    Console.WriteLine("3:Division");
                    Console.WriteLine("4:Multiplicacion");
                    Console.WriteLine("5:Raiz Cuadrada");
                    Console.WriteLine("6:Listar operaciones almacenadas");

                    var opcionDigitada = Console.ReadLine();
                    switch (opcionDigitada) {
                        case "1":
                            Console.WriteLine("Digite los numeros separados por coma. Ejemplo: 1,2,3");
                            var numbers = Console.ReadLine();
                            var arrayNumbers = numbers.Split(",");
                            List<int> listNumbers =  new List<int>();
                            foreach(var numberss in arrayNumbers) {
                                listNumbers.Add(int.Parse(numberss));
                            }
                            resultado = calculadora.Sum(listNumbers);
                            SaveOperation(resultado, opcionDigitada, calculadora);
                            break;
                        case "2":
                            Console.WriteLine("Digite el minuendo: ");
                            var minuendo = Console.ReadLine();
                            Console.WriteLine("Digite el sustraendo: ");
                            var subtrahendo = Console.ReadLine();
                            resultado = calculadora.Sub(int.Parse(minuendo),int.Parse(subtrahendo));
                            SaveOperation(resultado, opcionDigitada, calculadora);
                            break;
                        case "3":
                            Console.WriteLine("Digite el dividendo: ");
                            var dividendo = Console.ReadLine();
                            Console.WriteLine("Digite el divisor: ");
                            var divisor = Console.ReadLine();
                            resultado = calculadora.Div(int.Parse(dividendo), int.Parse(divisor));
                            SaveOperation(resultado, opcionDigitada, calculadora);
                            break;
                        case "4":
                            Console.WriteLine("Digite los numeros separados por coma. Ejemplo: 1,2,3");
                            numbers = Console.ReadLine();
                            arrayNumbers = numbers.Split(",");
                            listNumbers = new List<int>();
                            foreach (var numberm in arrayNumbers) {
                                listNumbers.Add(int.Parse(numberm));
                            }
                            resultado = calculadora.Mult(listNumbers);
                            SaveOperation(resultado, opcionDigitada, calculadora);
                            break;
                        case "5":
                            Console.WriteLine("Digite el numero al cual se le calculara la raiz cuadrada: ");
                            var number = Console.ReadLine();
                            resultado = calculadora.Sqrt(int.Parse(number));
                            SaveOperation(resultado, opcionDigitada, calculadora);
                            break;
                        case "6":
                            resultado = calculadora.Query();
                            SaveOperation(resultado, opcionDigitada, calculadora);
                            break;
                        default:
                            Console.WriteLine("Opcion incorrecta");
                            break;
                    }
                    Console.WriteLine("Desea salir de la aplicacion? s/n");
                    salir = Console.ReadLine();
                } while (salir.ToLower() != "s");
            } catch(Exception ex) {
                Console.WriteLine($"Error: {ex.Message}");
            } finally {
                Console.ReadKey();
            }
        }

        static void SaveOperation(string resultado, string opcionDigitada, CalculatorClient calculadora) {
            Console.WriteLine("El resultado de la operacion es:");
            Console.WriteLine(resultado);
            if (opcionesValidasGuardar.Contains(int.Parse(opcionDigitada))) {
                Console.WriteLine("Desea guardar la operacion realizada? s/n");
                var guardar = Console.ReadLine();
                if (guardar == "s" || guardar == "S") {
                    calculadora.Save();
                }
            }
        }
    }
}
