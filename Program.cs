using System;

namespace bit_packing
{
    class Program
    {

        static int Encode()
        {
            Console.Write("Sexo (M/F): ");
            char sex = Convert.ToChar(Console.ReadLine());
            Console.Write("Estado Civil (S/C): ");
            char status = Convert.ToChar(Console.ReadLine());
            Console.Write("Grado Académico (I/M/G/P): ");
            char grade = Convert.ToChar(Console.ReadLine());
            Console.Write("Edad: ");
            int age = int.Parse(Console.ReadLine());

            while (age < 7 || age > 120)
            {
                Console.Write("Edad: ");
                age = int.Parse(Console.ReadLine());
            }
            int datos = age << 4;
            if (sex == 'F')
                datos = datos | 8;
            if (status == 'C')
                datos = datos | 4; 
            if (grade == 'M')
                datos = datos | 1;
            else if (grade == 'G')
                datos = datos | 2; 
            else if (grade == 'P')
                datos = datos | 3; 
            return datos;
        }
                static void Decode(int data)
        {
            int age = data >> 4;
            Console.WriteLine("La edad es " + age);

            data = data - (age << 4);

            char sex;
            if ((data >> 3) == 1)
                sex = 'F';
            else
                sex = 'M';
            Console.WriteLine("El sexo es " + sex);

            data = data & 7;

            char status;
            if ((data >> 2) == 1)
                status = 'C';
            else
                status = 'S';
            Console.WriteLine("Estado civil es " + status);

            data = data & 3;

            char grade;
            if (data == 1)
                grade = 'M';
            else if (data == 2)
                grade = 'G';
            else if (data == 3)
                grade = 'P';
            else
                grade = 'I';
            Console.WriteLine("El grado académico es " + grade);
        }
        static void Main(string[] args)
        {
            int datos = Encode();
            Console.WriteLine();

            Console.WriteLine(datos);

            Console.WriteLine();
            Decode(datos);
        }
    }
}
