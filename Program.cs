using System;
using System.Data.SqlClient;

namespace mars_attack
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // GetDate with 1 result
            GetData(1);

            // GetDate with 2 results
            GetData(2);

            // GetDate with 3 result
            GetData(3);

            Pause();
        }

        private static void Pause()
        {
            Console.WriteLine();
            Console.WriteLine("Press a key to continue...");
            Console.ReadKey();
        }

        private static void GetData(int nbResult)
        {
            Console.WriteLine($"Nb de résultat attendu: {nbResult}");
            Console.WriteLine("======================================");

            using SqlConnection sqlConnection = new SqlConnection("Server=localhost; Database=AdventureWorks2016; User Id=mars_attack_user; Password=film2merde; MultipleActiveResultSets=true");
            using SqlCommand sqlCommand = new SqlCommand("p_get_mars_attack", sqlConnection);
            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("nb_result", nbResult);
            sqlConnection.Open();

            using SqlDataReader sqlReader = sqlCommand.ExecuteReader();

            int result = 1;

            // Boucle sur les result
            do
            {
                int line = 0;

                // Boucle sur les lignes d'un result
                while (sqlReader.Read())
                {
                    Console.Write($"{result}|{++line}: ");

                    // Boucle sur les colonnes
                    for (int i = 0; i < sqlReader.FieldCount; i++)
                    {
                        Console.Write($"{sqlReader[i]}\t");
                    }

                    Console.WriteLine();
                }

                Console.WriteLine();
                Console.WriteLine();

                result++;
            } while (sqlReader.NextResult());
        }
    }
}