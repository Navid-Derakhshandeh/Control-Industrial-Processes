using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyModbus;

namespace Internal_DSL
{

    class Program
    {
        
        static void Main(string[] args)
        {

                
        ModbusClient modbusClient7;
        modbusClient7 = new ModbusClient("COM11");
        modbusClient7.UnitIdentifier = 1;
        modbusClient7.Baudrate = 9600;
        modbusClient7.Parity = System.IO.Ports.Parity.None;
        modbusClient7.StopBits = System.IO.Ports.StopBits.Two;
        modbusClient7.Connect();
        int[] readinputreg = modbusClient7.ReadInputRegisters(9, 10);
            
        int[] readholdingreg = modbusClient7.ReadHoldingRegisters(0, 10);

        Console.WriteLine("You Have Connected To PLC");
        DateTime DT1 = DateTime.Now;

        Console.WriteLine(DT1.ToString("MM / dd / yyyy HH: mm:ss"));

            ConsoleKeyInfo conkey;
            do
            {


                try
                {

                    Console.WriteLine("Please Enter Your Command");
                    string h = Console.ReadLine();
                    string h1 = "Temp";
                    string h2 = "OpenValve";
                    if (h == h1)
                    {
                    int SensorTemp = readholdingreg[5];
                    Console.WriteLine("Your temp Equal by : {0}", SensorTemp);


                    int T = Int32.Parse(Console.ReadLine());
                    modbusClient7.WriteSingleRegister(9, T);
                    double T1 = SensorTemp + T;
                    Console.WriteLine("Your Temp Equal By : {0}", T1);

                    }
                    else if (h == h2)
                    {
                    modbusClient7.WriteSingleCoil(4, true);

                    }
                    else
                    {    
                    Console.WriteLine("Your Command Not Found");
                    }
                }
                catch (DivideByZeroException ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(ex.StackTrace);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(ex.StackTrace);
                }
                finally
                {
                    Console.WriteLine("Enter Any Key That You Want, For Run Program Again.");
                }
                conkey = Console.ReadKey();
            } while (conkey.Key != ConsoleKey.Escape);


        }
    }
}
